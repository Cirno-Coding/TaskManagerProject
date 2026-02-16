using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppClinet
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
                return ShowError("Введите логин");

            if (txtPassword.Text.Length < 6)
                return ShowError("Пароль минимум 6 символов");

            if (txtPassword.Text != txtPasswordProof.Text)
                return ShowError("Пароль не совпадают");

            if (!IsValidEmail(txtEmail.Text))
                return ShowError("Некорректный email");

            return true;
        }

        private bool ShowError(string message)
        {
            MessageBox.Show(message);
            return false;
        }

        private async void btnReg_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            if (ValidateForm())
            {
                string response = await Program.Connection.SendAsync($"REGISTER|{login}|{password}|{email}");
                switch (response)
                {
                    case "SUCCESS":
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;

                    case "USER_EXISTS":
                        MessageBox.Show("Пользователь уже существует");
                        break;

                    default:
                        MessageBox.Show("Ошибка регистрации");
                        break;
                }
            }
        }
    }
}
