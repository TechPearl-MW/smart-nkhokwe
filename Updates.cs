using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace desktop_app.Forms
{
    public partial class Updates : Form
    {
        // Color scheme - Dark green theme
        private readonly Color PrimaryColor = Color.FromArgb(0, 100, 50);      // Dark green
        private readonly Color SecondaryColor = Color.FromArgb(0, 120, 60);    // Medium green
        private readonly Color AccentColor = Color.FromArgb(0, 150, 80);       // Light green
        private readonly Color DarkBackground = Color.FromArgb(20, 30, 25);    // Very dark green
        private readonly Color LightBackground = Color.FromArgb(30, 40, 35);   // Dark green background
        private readonly Color TextColor = Color.FromArgb(220, 220, 220);      // Light gray text
        private readonly Color UserBubbleColor = Color.FromArgb(0, 80, 40);    // User message color
        private readonly Color AIBubbleColor = Color.FromArgb(40, 60, 50);     // AI message color

        // Simulated real-time sensor data
        private double temperature = 27.5;
        private double humidity = 65.2;
        private double moistureContent = 13.8;
        private double maizeLevel = 2.4; // meters from top
        private string grainLevel = "Medium";

        private const string OPENAI_API_KEY = "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";
        private const string OPENAI_API_URL = "https://api.openai.com/v1/chat/completions";

        // UI Components
        private Panel root;
        private Panel header;
        private Label titleLabel;
        private Button closeButton;

        private Panel chatContainer;
        private FlowLayoutPanel chatPanel;

        private Panel inputPanel;
        private TextBox inputBox;
        private Button sendButton;

        private System.Timers.Timer dataUpdateTimer;
        private HttpClient httpClient;

        // Placeholder emulation
        private readonly string PlaceholderText = "Ask about your silo… / Funsani za khokwe yanu…";
        private readonly Color PlaceholderColor = Color.Gray;
        private readonly Color InputTextColor = Color.White;
        private bool hasRealInputText = false;

        public Updates()
        {
            // Initialize the form first
            InitializeForm();

            // Set up the chat UI
            InitializeChatUI();

            // Initialize HTTP client
            InitializeHttpClient();

            // Set up events
            this.Load += Updates_Load;
        }

        private void InitializeForm()
        {
            // Basic form setup
            this.Text = "Smart Silo AI Assistant";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = DarkBackground;
            this.ForeColor = TextColor;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void InitializeHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);

            // Only add authorization if API key is provided
            if (!OPENAI_API_KEY.Equals("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") && !string.IsNullOrEmpty(OPENAI_API_KEY))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {OPENAI_API_KEY}");
            }
        }

        private void Updates_Load(object sender, EventArgs e)
        {
            // Intro message
            AddMessage("AI Assistant 🤖",
                "👋 Moni! I'm here to help you monitor your silo (khokwe). Ask me about temperature, humidity, moisture content, or maize level.\n\n" +
                "Ndili pano kukuthandizani ndi khokwe yanu ya zolima zanu. Funsani za kutentha, chinyezi, kanyowedwe, kapena mlingo wa chimanga.",
                isUser: false);

            // Start timer for real-time data updates
            SetupDataTimer();

            // Focus on input box
            inputBox.Focus();
        }

        private void SetupDataTimer()
        {
            dataUpdateTimer = new System.Timers.Timer(5000); // Update every 5 seconds
            dataUpdateTimer.Elapsed += UpdateSensorData;
            dataUpdateTimer.AutoReset = true;
            dataUpdateTimer.Enabled = true;
        }

        private void UpdateSensorData(object sender, ElapsedEventArgs e)
        {
            var rand = new Random();

            temperature += (rand.NextDouble() - 0.5) * 0.5;
            humidity += (rand.NextDouble() - 0.5) * 1.0;
            moistureContent += (rand.NextDouble() - 0.5) * 0.3;
            maizeLevel -= 0.01; // Slowly decreasing maize level

            // Keep values within reasonable ranges
            temperature = Math.Max(20, Math.Min(35, temperature));
            humidity = Math.Max(50, Math.Min(80, humidity));
            moistureContent = Math.Max(12, Math.Min(16, moistureContent));
            maizeLevel = Math.Max(0, Math.Min(5, maizeLevel));

            // Update grain level based on maize level
            if (maizeLevel <= 1) grainLevel = "Full";
            else if (maizeLevel <= 3) grainLevel = "Medium";
            else grainLevel = "Low";
        }

        private void InitializeChatUI()
        {
            // Root container
            root = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = DarkBackground,
                Padding = new Padding(10)
            };
            this.Controls.Add(root);

            // Header
            header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = PrimaryColor,
                Padding = new Padding(10)
            };
            root.Controls.Add(header);

            titleLabel = new Label
            {
                Dock = DockStyle.Left,
                AutoSize = true,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Text = "Smart Silo Assistant",
                TextAlign = ContentAlignment.MiddleLeft
            };
            header.Controls.Add(titleLabel);

            // Close button
            closeButton = new Button
            {
                Dock = DockStyle.Right,
                Text = "✕",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Width = 40,
                Height = 40
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 80, 40);
            closeButton.Click += (s, e) => this.Close();
            header.Controls.Add(closeButton);

            // Chat container (holds messages and input bar)
            chatContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = LightBackground,
                Margin = new Padding(0, 10, 0, 0)
            };
            root.Controls.Add(chatContainer);

            // Chat messages panel
            chatPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BackColor = LightBackground,
                Padding = new Padding(10),
                AutoScrollMinSize = new Size(0, 100)
            };
            chatContainer.Controls.Add(chatPanel);

            // Input panel at bottom
            inputPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = PrimaryColor,
                Padding = new Padding(10)
            };
            chatContainer.Controls.Add(inputPanel);

            // Input box (custom placeholder emulation) - THIS IS WHERE YOU TYPE YOUR PROMPTS!
            inputBox = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = PlaceholderColor,
                Text = PlaceholderText,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(40, 50, 45)
            };
            inputPanel.Controls.Add(inputBox);

            // Placeholder behavior
            inputBox.GotFocus += (s, e) =>
            {
                if (!hasRealInputText && inputBox.Text == PlaceholderText)
                {
                    inputBox.Text = string.Empty;
                    inputBox.ForeColor = InputTextColor;
                }
            };

            inputBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(inputBox.Text))
                {
                    hasRealInputText = false;
                    inputBox.Text = PlaceholderText;
                    inputBox.ForeColor = PlaceholderColor;
                }
                else
                {
                    hasRealInputText = true;
                }
            };

            // Send button - CLICK THIS TO SEND YOUR PROMPT!
            sendButton = new Button
            {
                Text = "Send",
                Dock = DockStyle.Right,
                Width = 80,
                BackColor = AccentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Margin = new Padding(10, 0, 0, 0)
            };
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 170, 90);
            inputPanel.Controls.Add(sendButton);

            // Handle click & Enter key
            sendButton.Click += SendButton_Click;
            inputBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && !e.Shift)
                {
                    SendButton_Click(s, e);
                    e.Handled = e.SuppressKeyPress = true;
                }
            };
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            string userText = inputBox.Text.Trim();

            // Ignore if it's still placeholder or empty
            if (string.IsNullOrEmpty(userText) || userText == PlaceholderText)
                return;

            AddMessage("You", userText, isUser: true);

            inputBox.Clear();
            hasRealInputText = false;
            inputBox.Text = PlaceholderText;
            inputBox.ForeColor = PlaceholderColor;

            inputBox.Enabled = false;
            sendButton.Enabled = false;

            // Show typing indicator
            var typingIndicator = AddTypingIndicator();

            try
            {
                await RespondWithAI(userText);
            }
            catch (Exception ex)
            {
                // Fallback to simple responses if API fails
                Console.WriteLine("AI error: " + ex.Message);
                RespondWithSimpleLogic(userText);
            }
            finally
            {
                // Remove typing indicator
                if (typingIndicator != null && chatPanel.Controls.Contains(typingIndicator))
                {
                    chatPanel.Controls.Remove(typingIndicator);
                }
                inputBox.Enabled = true;
                sendButton.Enabled = true;
                inputBox.Focus();
            }
        }

        private Panel AddTypingIndicator()
        {
            Panel typingContainer = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(chatPanel.Width - 40, 0),
                Margin = new Padding(10, 5, 10, 5),
                BackColor = Color.Transparent
            };

            Label typingLabel = new Label
            {
                AutoSize = true,
                Text = "AI Assistant 🤖 is thinking…",
                Padding = new Padding(12, 8, 12, 8),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(180, 180, 180),
                BackColor = Color.FromArgb(50, 60, 55)
            };

            // Rounded corners for typing indicator
            typingLabel.Paint += (s, ev) =>
            {
                using (var path = GetRoundRect(typingLabel.DisplayRectangle, 12))
                {
                    typingLabel.Region = new Region(path);
                }
            };

            typingContainer.Controls.Add(typingLabel);
            chatPanel.Controls.Add(typingContainer);
            chatPanel.ScrollControlIntoView(typingContainer);

            return typingContainer;
        }

        private async Task RespondWithAI(string userText)
        {
            // Check if API key is set
            if (OPENAI_API_KEY.Equals("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") || string.IsNullOrEmpty(OPENAI_API_KEY))
            {
                RespondWithSimpleLogic(userText);
                return;
            }

            try
            {
                // Prepare the prompt with current sensor data
                string systemPrompt = $@"You are an AI assistant for a smart silo (khokwe) monitoring system in Malawi. 
You help farmers monitor their grain storage conditions. Respond in both English and Chichewa when appropriate.

Current sensor readings:
- Temperature: {temperature:F1}°C
- Humidity: {humidity:F1}%
- Moisture Content: {moistureContent:F1}%
- Grain Level: {grainLevel} ({maizeLevel:F1}m from top)
- Grain Type: Maize

Important thresholds:
- Temperature alert if > 30°C
- Humidity alert if > 70%
- Moisture alert if > 14% (risk of mold)
- Grain level: Full (<1m), Medium (1-3m), Low (>3m)

Provide helpful, educational responses about grain storage best practices. 
Use simple language and be culturally appropriate for Malawian farmers.";

                var requestData = new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new { role = "system", content = systemPrompt },
                        new { role = "user", content = userText }
                    },
                    max_tokens = 500,
                    temperature = 0.7
                };

                var json = JsonSerializer.Serialize(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(OPENAI_API_URL, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<OpenAIResponse>(responseContent);

                if (responseObject?.choices != null && responseObject.choices.Length > 0)
                {
                    string aiResponse = responseObject.choices[0].message.content;
                    AddMessage("AI Assistant 🤖", aiResponse, isUser: false);
                }
                else
                {
                    throw new Exception("Invalid response from AI service");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenAI call failed: " + ex.Message);
                // Fallback to simple logic
                RespondWithSimpleLogic(userText);
            }
        }

        private void RespondWithSimpleLogic(string userText)
        {
            string lower = userText.ToLower();
            string responseEn = "";
            string responseNy = "";

            if (lower.Contains("hello") || lower.Contains("hi") || lower.Contains("moni"))
            {
                responseEn = "Hello! How can I help you with your silo today?";
                responseNy = "Moni! Ndingakuthandizeni bwanji ndi khokwe yanu lero?";
            }
            else if (lower.Contains("temperature") || lower.Contains("kutentha"))
            {
                string status = temperature > 30 ? " (slightly high)" : temperature < 25 ? " (slightly low)" : " (good)";
                responseEn = $"The temperature inside the silo is {temperature:F1} °C{status}.";
                responseNy = $"Kutentha mkati mwa khokwe ndi {temperature:F1} °C.";
            }
            else if (lower.Contains("humidity") || lower.Contains("chinyezi") || lower.Contains("unyowa"))
            {
                string status = humidity > 70 ? " (high)" : humidity < 60 ? " (low)" : " (good)";
                responseEn = $"The humidity inside the silo is {humidity:F1}%{status}.";
                responseNy = $"Chinyezi mkati mwa khokwe ndi {humidity:F1}%.";
            }
            else if (lower.Contains("moisture") || lower.Contains("kanyowedwe") || lower.Contains("mkaka"))
            {
                string status = moistureContent > 14.5 ? " (too high - risk of mold)" : moistureContent < 13 ? " (low)" : " (good)";
                responseEn = $"The maize moisture content is {moistureContent:F1}%{status}. For safe storage, it should not exceed 14%.";
                responseNy = $"Kanyowedwe ka chimanga ndi {moistureContent:F1}%. Kuti chisungidwe bwino, chisakhale choposa 14%.";
            }
            else if (lower.Contains("maize") || lower.Contains("level") || lower.Contains("distance") ||
                     lower.Contains("chimanga") || lower.Contains("gawo"))
            {
                double percentage = 100 - ((maizeLevel / 5.0) * 100); // 0m from top -> 100% full
                string status = percentage > 80 ? " (almost full)" : percentage < 20 ? " (low)" : " (good)";
                responseEn = $"The silo is approximately {percentage:F0}% full; {maizeLevel:F1} meters from the top{status}.";
                responseNy = $"Silo ndi pafupifupi {percentage:F0}% yadzaza; {maizeLevel:F1} mita kuchokera pamwamba.";
            }
            else if (lower.Contains("advice") || lower.Contains("store") || lower.Contains("khokwe") || lower.Contains("ndemanga"))
            {
                responseEn = "Storage advice: Keep the silo well sealed, ensure moisture is below 14%, check regularly for pests, and monitor temperature daily.";
                responseNy = "Malangizo: Sungani khokwe yosindikizika bwino, onetsetsani kuti kanyowedwe kuli pansi pa 14%, yang'anani nthawi zonse tizilombo, komanso kuyang'anira kutentha tsiku ndi tsiku.";
            }
            else if (lower.Contains("thank") || lower.Contains("thanks") || lower.Contains("zikomo"))
            {
                responseEn = "You're welcome! Feel free to ask if you need more assistance.";
                responseNy = "Walandiridwa! Ngati muli ndi mafunso ena, ingofunsani.";
            }
            else
            {
                responseEn = "I'm not sure I understand. You can ask me about temperature, humidity, moisture content, or maize level in your silo.";
                responseNy = "Pepani, sindikumvetsa bwino. Mungafunse za kutentha, chinyezi, kanyowedwe, kapena mlingo wa chimanga mu khokwe yanu.";
            }

            AddMessage("AI Assistant 🤖", responseEn + "\n\n" + responseNy, isUser: false);
        }

        private void AddMessage(string sender, string text, bool isUser)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => AddMessage(sender, text, isUser)));
                return;
            }

            // Optional: sender label for AI messages
            if (!isUser)
            {
                Label senderLabel = new Label
                {
                    Text = sender,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = AccentColor,
                    Margin = new Padding(10, 10, 10, 5)
                };
                chatPanel.Controls.Add(senderLabel);
            }

            // Bubble container
            Panel messageContainer = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size(chatPanel.ClientSize.Width - 40, 0),
                Margin = new Padding(10, 5, 10, 10),
                BackColor = Color.Transparent
            };

            // Message label (bubble)
            Label messageLabel = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(chatPanel.ClientSize.Width - 80, 0),
                Text = text,
                Padding = new Padding(14),
                Font = new Font("Segoe UI", 10),
                ForeColor = TextColor,
                BackColor = isUser ? UserBubbleColor : AIBubbleColor,
                BorderStyle = BorderStyle.None
            };

            // Rounded corners for bubble
            messageLabel.Paint += (s, ev) =>
            {
                using (var path = GetRoundRect(messageLabel.DisplayRectangle, 14))
                {
                    messageLabel.Region = new Region(path);
                }
            };

            // Alignment
            if (isUser)
            {
                messageContainer.Dock = DockStyle.None;
                messageLabel.TextAlign = ContentAlignment.MiddleRight;
                messageContainer.Padding = new Padding(0);
            }
            else
            {
                messageContainer.Dock = DockStyle.None;
                messageLabel.TextAlign = ContentAlignment.MiddleLeft;
                messageContainer.Padding = new Padding(0);
            }

            messageContainer.Controls.Add(messageLabel);
            chatPanel.Controls.Add(messageContainer);

            // Ensure latest is visible
            chatPanel.ScrollControlIntoView(messageContainer);
        }

        private GraphicsPath GetRoundRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            var path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left
            path.AddArc(arc, 180, 90);
            // top right
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            // bottom right
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // bottom left
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            dataUpdateTimer?.Stop();
            dataUpdateTimer?.Dispose();
            httpClient?.Dispose();
        }
    }


    // Classes for JSON deserialization
    public class OpenAIResponse
    {
        public Choice[] choices { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
    }
}