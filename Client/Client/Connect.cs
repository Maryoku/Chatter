using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    class Connect: Form
    {
        Client client;

        Label IPLabel;
        TextBox IPAddress;
        Label LoginLabel;
        TextBox Login;
        Button ConnectButton;

        public Connect()
        {
            IPLabel = new Label
            {
                Location = new Point(5, 5),
                Size = new Size(ClientSize.Width - 10, 15),
                Text = "Ввведите IP для подключения:"
            };
            IPAddress = new TextBox
            {
                Location = new Point(5, IPLabel.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 15),
            };
            LoginLabel = new Label
            {
                Location = new Point(5, IPAddress.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 15),
                Text = "Ввведите nickname:"
            };
            Login = new TextBox
            {
                Location = new Point(5, LoginLabel.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 15),
            };
            ConnectButton = new Button
            {
                Location = new Point(5, Login.Bottom + 5),
                Size = new Size(ClientSize.Width / 2 - 10, 30),
                //Enabled = false,
                Text = "Подключиться"
            };

            Controls.Add(IPLabel);
            Controls.Add(IPAddress);
            Controls.Add(LoginLabel);
            Controls.Add(Login);
            Controls.Add(ConnectButton);

            ConnectButton.Click += new EventHandler(ConnectButton_Click);
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            client = new Client(IPAddress.Text, Login.Text);

            Form Chatty = new Chatty(client, Login.Text);
            Chatty.Show();
            //this.Hide();
        }
    }
}
