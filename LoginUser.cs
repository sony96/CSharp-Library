using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libb
{
    public partial class LoginUser : Form
    {
        string hashPass;

        public LoginUser()
        {
            InitializeComponent();
        }

        private void LoginUser_Load(object sender, EventArgs e)
        {
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
            toolTipLogin.SetToolTip(this.buttonLogin, "Вход");
        }

        private void LoginUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            bool flag = false;

            hashPass = GenerateSHA256String(textBox2.Text.Trim());
            using (DBModels context = new DBModels())
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    try
                    {
                        var user = context.Readers.FirstOrDefault(u => u.Username == textBox1.Text);
                        var pass = context.Readers.FirstOrDefault(u => u.Password == hashPass);
                        if (user.Username == textBox1.Text && user.Password == hashPass)
                        {
                            flag = true;
                        }
                        else
                        {

                            MessageBox.Show("Няма такъв акаунт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        if (flag == true)
                        {
                            
                            FormUserPanel form = new FormUserPanel();
                            form.RecieveUserInfo(user.ReaderID, user.Firstname, user.Lastname);
                            this.Hide();
                            form.Show();
                            
                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не съществува такъв акаунт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                    MessageBox.Show("Оставили сте празни полета!");

            }

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            StartPanel form = new StartPanel();
            this.Hide();
            form.Show();
        }

        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }



        private void labelRegistration_Click(object sender, EventArgs e)
        {
            FormUserRegistration form = new FormUserRegistration();
            this.Hide();
            form.Show();
        }
    }
}
