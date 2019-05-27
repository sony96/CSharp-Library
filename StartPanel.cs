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
    public partial class StartPanel : Form
    {
        
        public StartPanel()
        {
            InitializeComponent();
        }

        private void StartPanel_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            PopulateDataGridView();
        }

    

        void PopulateDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (DBModels lib = new DBModels())
            {
                var results = from book in lib.Books
                              join author in lib.Authors on book.AuthorID equals author.AuthorID
                              join publisher in lib.Publishers on book.PublisherID equals publisher.PublisherID
                              join ganre in lib.Ganres on book.GanreID equals ganre.GanreID
                              where (book.AuthorID == author.AuthorID) && (book.PublisherID == publisher.PublisherID) && (book.GanreID == ganre.GanreID)
                              select new { title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                dataGridView1.DataSource = results.ToList();
            }

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginAdmin form = new LoginAdmin();
            this.Hide();
            form.Show();
        }

        private void StartPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void входЗаПотребителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginUser form = new LoginUser();
            this.Hide();
            form.Show();
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (radioButtonTitle.Checked == false && radioButtonAuthor.Checked == false && radioButtonPublisher.Checked == false && radioButtonGanre.Checked == false && radioButtonSection.Checked == false)
            {
                MessageBox.Show("Не сте избрали критерии, по който да търсите!");
            }
            else
            {
                if (radioButtonTitle.Checked)
                {
                    PopulateDataGridView();
                    using (DBModels lib = new DBModels())
                    {
                        var query = from book in lib.Books
                                    join author in lib.Authors on book.AuthorID equals author.AuthorID
                                    join publisher in lib.Publishers on book.PublisherID equals publisher.PublisherID
                                    join ganre in lib.Ganres on book.GanreID equals ganre.GanreID
                                    where (book.Title.ToLower() == textBox1.Text.Trim().ToLower())
                                    select new { title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                        dataGridView1.DataSource = query.ToList();
                    }
                }

                else if (radioButtonAuthor.Checked)
                {
                    PopulateDataGridView();
                    using (DBModels lib = new DBModels())
                    {
                        var query = from book in lib.Books
                                    join author in lib.Authors on book.AuthorID equals author.AuthorID
                                    join publisher in lib.Publishers on book.PublisherID equals publisher.PublisherID
                                    join ganre in lib.Ganres on book.GanreID equals ganre.GanreID
                                    where author.FirstName.ToLower() + " " + author.LastName.ToLower() == textBox2.Text.ToLower()
                                    || author.FirstName.ToLower() == textBox2.Text.ToLower()
                                    || author.LastName.ToLower() == textBox2.Text.ToLower()
                                    select new { title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                        dataGridView1.DataSource = query.ToList();
                    }
                }

                else if (radioButtonPublisher.Checked)
                {
                    PopulateDataGridView();
                    using (DBModels lib = new DBModels())
                    {
                        var query = from book in lib.Books
                                    join author in lib.Authors on book.AuthorID equals author.AuthorID
                                    join publisher in lib.Publishers on book.PublisherID equals publisher.PublisherID
                                    join ganre in lib.Ganres on book.GanreID equals ganre.GanreID
                                    where publisher.Name.ToLower() == textBox3.Text.ToLower()
                                    select new { title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                        dataGridView1.DataSource = query.ToList();
                    }
                }

                else if (radioButtonGanre.Checked)
                {
                    PopulateDataGridView();
                    using (DBModels lib = new DBModels())
                    {
                        var query = from book in lib.Books
                                    join author in lib.Authors on book.AuthorID equals author.AuthorID
                                    join publisher in lib.Publishers on book.PublisherID equals publisher.PublisherID
                                    join ganre in lib.Ganres on book.GanreID equals ganre.GanreID
                                    where ganre.GanreName.ToLower() == textBox4.Text.ToLower()
                                    select new { title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                        dataGridView1.DataSource = query.ToList();
                    }
                }

                else if (radioButtonSection.Checked)
                {
                    PopulateDataGridView();
                    using (DBModels lib = new DBModels())
                    {
                        var query = from book in lib.Books
                                    join author in lib.Authors on book.AuthorID equals author.AuthorID
                                    join publisher in lib.Publishers on book.PublisherID equals publisher.PublisherID
                                    join ganre in lib.Ganres on book.GanreID equals ganre.GanreID
                                    where book.Section.ToLower() == textBox5.Text.ToLower()
                                    select new { title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                        dataGridView1.DataSource = query.ToList();
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            ClearTextBoxes();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = false; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            ClearTextBoxes();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = false; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            ClearTextBoxes();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = false; textBox5.ReadOnly = true;
            ClearTextBoxes();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = false;
            ClearTextBoxes();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
        }

        public void ClearTextBoxes() {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
        }
        private void отностноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Library Manager\nРазработена от Радослав Колев, Фак. номер: 61562191\n");
        }
    }
}
