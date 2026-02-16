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
            string[] parts = response.Split('|');

            switch (parts[0])
            {
                case "NOT_FOUND":
                    MessageBox.Show("Не найден пользователь с таким логином");
                    break;

                case "WRONG_PASSWORD":
                    MessageBox.Show("Найден пользователь, но пароль не подходит");
                    break;

                case "SUCCESS":
                    //MessageBox.Show("Удачный вход");
                    var user = new SessionUser
                    {
                        Id = int.Parse(parts[1]),
                        Login = parts[2],
                        SecurityLevel = int.Parse(parts[3])
                    };
                    OpenMainForm(user);
                    break;
            }
        }

        private void OpenMainForm(SessionUser user)
        {
            MainForm main = new MainForm(user);

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

        private void lblReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegForm regForm = new RegForm();
            regForm.FormClosing += (s, args) =>
            {
                this.Show();
                txtPassword.Clear();
            };
            regForm.Show();

            this.Hide();
        }
    }
}
