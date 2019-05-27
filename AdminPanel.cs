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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StartPanel form = new StartPanel();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddBook form = new FormAddBook();
            this.Hide();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAddAuthor form = new FormAddAuthor();
            this.Hide();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAddPublisher form = new FormAddPublisher();
            this.Hide();
            form.Show();
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormRemoveUser form = new FormRemoveUser();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddGanre form = new FormAddGanre();
            this.Hide();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormBorrowedBooks form = new FormBorrowedBooks();
            this.Hide();
            form.Show();
        }
    }
}
