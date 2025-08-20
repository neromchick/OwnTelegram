using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox2.PasswordChar = '*';
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                label3.Text = "Введите логин и пароль.";
                label3.Visible = true;
                return;
            }

            using var client = new HttpClient();
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            try
            {
                var response = await client.PostAsync("http://localhost:5000/api/auth/register", content);
                if (response.IsSuccessStatusCode)
                {
                    label3.Text = "Регистрация успешна!";
                }
                else
                {
                    label3.Text = "Пользователь уже существует.";
                }
                label3.Visible = true;
            }
            catch
            {
                label3.Text = "Ошибка подключения.";
                label3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
