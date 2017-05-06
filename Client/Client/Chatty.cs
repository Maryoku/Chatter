using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Chatty : Form
    {
        Client client;

        Label LogLabel;
        TextBox Login;
        static RichTextBox ChatWindow; //???
        RichTextBox MessageWindow;
        Button Send;
        
        public Chatty()
        {
            client = new Client();

            Size = new Size(300, 300);

            LogLabel = new Label
            {
                Location = new Point(5, 5),
                Size = new Size(ClientSize.Width - 10, 15),
                Text = "Ввведите свой nickname:"
            };
            Login = new TextBox
            {
                Location = new Point(5, LogLabel.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 15),
            };
            ChatWindow = new RichTextBox
            {
                Location = new Point(5, Login.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 80),
                Enabled = false
            };
            MessageWindow = new RichTextBox
            {
                Location = new Point(5, ChatWindow.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 80)
            };
            Send = new Button
            {
                Location = new Point(5, MessageWindow.Bottom + 5),
                Size = new Size(ClientSize.Width / 2 - 10, 30),
                Enabled = false,
                Text = "Отправить"
            };

            Controls.Add(LogLabel);
            Controls.Add(Login);
            Controls.Add(ChatWindow);
            Controls.Add(MessageWindow);
            Controls.Add(Send);

            Send.Click += new EventHandler(Send_Click);
            Login.TextChanged += new EventHandler(Login_Change);
            ChatWindow.TextChanged += new EventHandler(ChatWindow_TextChanged);
        }

        public static void Get_NewMsg(string msg)
        {
            ChatWindow.AppendText(msg + "\n");
        }

        private void Login_Change(object sender, EventArgs e)
        {
            Send.Enabled = true;
        }

        private void ChatWindow_TextChanged(object sender, EventArgs e)
        {
            ChatWindow.SelectionStart = ChatWindow.Text.Length;
            ChatWindow.ScrollToCaret();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if(MessageWindow.Text != "" && MessageWindow.Text != " ")
            {
                client.SendMessage(Login.Text + ": " + MessageWindow.Text);
            }
            MessageWindow.Clear();
        }

    }
}
