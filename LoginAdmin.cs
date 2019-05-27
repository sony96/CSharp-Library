using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libb
{
    public partial class LoginAdmin : Form
    {
   

        public LoginAdmin()
        {
            InitializeComponent();
        }

        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool flag = false;
        
            using (DBModels context = new DBModels())
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    try
                    {
                        var user = context.Admins.FirstOrDefault(u => u.Username == textBox1.Text);
                        var pass = context.Admins.FirstOrDefault(u => u.Password == textBox2.Text);
                        if (user.Username == textBox1.Text && pass.Password == textBox2.Text)
                        {
                            flag = true;
                        }
                        else
                        {
                            MessageBox.Show("Няма такъв акаунт!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        if (flag == true)
                        {
                            AdminPanel form = new AdminPanel();
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
                    MessageBox.Show("Оставили сте празни полета!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            StartPanel form = new StartPanel();
            this.Hide();
            form.Show();
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
            toolTipLogin.SetToolTip(this.buttonLogin, "Вход");
        }

        private void LoginAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
