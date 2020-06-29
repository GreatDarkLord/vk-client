﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Model;
using VkNet.Enums.Filters;

namespace Vkapp
{
    public partial class LoginForm : Form
    {
        VkApi api = new VkApi();
      
        public LoginForm()
        {
            InitializeComponent();
        }
        public LoginForm(VkApi vkapi)
        {
            api = vkapi;
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            EmailTextbox.Text = "79003557072";
            PasswordlTextbox.Text = "Aveemperor404";
           // LoginAsync();
        }


        private async void LoginAsync()
        {

            try
            {
                await api.AuthorizeAsync(new ApiAuthParams
                {
                    ApplicationId = 7429505,
                    Login = EmailTextbox.Text,
                    Password = PasswordlTextbox.Text,
                    Settings = Settings.Groups
                });
            }
            catch(VkNet.Exception.VkAuthorizationException)
            {
                AuthErrorLabel.ForeColor = Color.Red;
                AuthErrorLabel.Text = "Неверный логин или пароль";
                return;
            }
            
            MainForm mainForm = new MainForm(api, this);
           
            mainForm.Show();
            Hide();
        }
        private async void Auth_Click(object sender, EventArgs e)
        {

            LoginAsync();
            AuthErrorLabel.Visible = true;
            AuthErrorLabel.ForeColor = Color.Black;
            AuthErrorLabel.Text = "Проверка данных...";
          



        }

        private void PassViev_CheckedChanged(object sender, EventArgs e)
        {
            PasswordlTextbox.UseSystemPasswordChar = !PassViev.Checked;
        }
    }
}
