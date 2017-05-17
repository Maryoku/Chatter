using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Chatty : Form
    {
        Client client;
        string login;
        static RichTextBox ChatWindow;
        RichTextBox MessageWindow;
        Button Send;

        public Chatty(Client client, string login)
        {
            this.client = client;
            this.login = login;

            Size = new Size(280, 300);

            ChatWindow = new RichTextBox
            {
                Location = new Point(5, 5),
                Size = new Size(250, 80),
                Enabled = false
            };
            MessageWindow = new RichTextBox
            {
                Location = new Point(5, ChatWindow.Bottom + 5),
                Size = new Size(250, 80)
            };
            Send = new Button
            {
                Location = new Point(5, MessageWindow.Bottom + 5),
                Size = new Size(ClientSize.Width / 2 - 10, 30),
                Text = "Отправить"
            };

            Controls.Add(ChatWindow);
            Controls.Add(MessageWindow);
            Controls.Add(Send);

            Send.Click += new EventHandler(Send_Click);
            ChatWindow.TextChanged += new EventHandler(ChatWindow_TextChanged);
            Client.MessageReceived += Get_NewMsg;
        }

        public static void Get_NewMsg(string msg)
        {
            ChatWindow.AppendText(msg + "\n");
        }

        private void ChatWindow_TextChanged(object sender, EventArgs e)
        {
            ChatWindow.SelectionStart = ChatWindow.Text.Length;
            ChatWindow.ScrollToCaret();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            client.SendMessage(login + ": " + MessageWindow.Text);

        }

    }
}
