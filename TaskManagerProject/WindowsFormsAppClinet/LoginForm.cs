using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppClinet
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            string response = await Program.Connection.SendAsync($"LOGIN|{login}|{password}");

            switch (response)
            {
                case "NOT_FOUND":
                    MessageBox.Show("Не найден пользователь с таким логином");
                    break;

                case "WRONG_PASSWORD":
                    MessageBox.Show("Найден пользователь, но пароль не подходит");
                    break;

                case "SUCCESS":
                    //MessageBox.Show("Удачный вход");
                    OpenMainForm();
                    break;
            }
        }

        private void OpenMainForm()
        {
            MainForm main = new MainForm();

            main.FormClosing += (s, args) =>
            {
                this.Show();
                txtPassword.Clear();
            };
            main.Show();

            this.Hide();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Connection.Close();
        }
    }
}
