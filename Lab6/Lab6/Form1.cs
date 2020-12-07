using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string GetMD5(string value)
        {
            var provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var data = Encoding.UTF8.GetBytes(value);
            data = provider.ComputeHash(data);
            return Encoding.UTF8.GetString(data);
        }

        private void Create_Click(object sender, EventArgs e)
        {
            var db = new DataClasses1DataContext();
            var query = from c in db.Users
                        where (c.Login == regLogin.Text)
                        select c;

            if (query.Count() == 0)
            {
                if (!(String.IsNullOrWhiteSpace(regPassword.Text)) && !(String.IsNullOrWhiteSpace(regLogin.Text)))
                {
                    if (regPassword.Text.Contains(regPassword.Text.FirstOrDefault(c => Char.IsLower(c)))
                        && regPassword.Text.Contains(regPassword.Text.FirstOrDefault(c => Char.IsUpper(c)))
                        && regPassword.Text.Contains(regPassword.Text.FirstOrDefault(c => Char.IsDigit(c))))
                    {
                        var hash = GetMD5(regPassword.Text);
                        debugLabel.Text = hash;

                        var data = new Users
                        {
                            Login = regLogin.Text,
                            Password = hash
                        };

                        db.Users.InsertOnSubmit(data);
                        db.SubmitChanges();
                    }
                    else
                    {
                        MessageBox.Show("Придумайте другой пароль", "Логин и пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля", "Логин и пароль");
                }
            }
            else
            {
                MessageBox.Show("Такой логин уже используется", "Логин и пароль");
            }
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            var db = new DataClasses1DataContext();
            var hash = GetMD5(password.Text);

            var query = from c in db.Users
                        where (c.Login == login.Text && c.Password == hash)
                        select c;

            if (query.Count() == 1)
            {
                MessageBox.Show("Найдено совпадение!", "Логин и пароль");
            }
            else
            {
                MessageBox.Show("Совпадений не найдено!", "Логин и пароль");
            }
        }
    }
}
