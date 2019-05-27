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
    public partial class FormAddAuthor : Form
    {
        Author author = new Author();
        public FormAddAuthor()
        {
            InitializeComponent();
        }

        private void FormAddAuthor_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            toolTipSaveEdit.SetToolTip(this.buttonSaveUpdate, "Запази");
            toolTipDelete.SetToolTip(this.buttonDelete, "Изтрии");
            toolTipRefresh.SetToolTip(this.buttonRefresh, "Обнови");
            toolTipSearch.SetToolTip(this.buttonSearch, "Търси");
            toolTipAddBooks.SetToolTip(this.buttonAddBooks, "Добавяне на книги");
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
            
        }

        void PopulateDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (DBModels lib = new DBModels())
            {
                dataGridView1.DataSource = lib.Authors.ToList<Author>();
            }
        }

        private void buttonSaveUpdate_Click(object sender, EventArgs e)
        {
            
            author.FirstName = textBox1.Text.Trim();
            author.LastName = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Не сте въвели информация!","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                using (DBModels lib = new DBModels())
                {
                    if (author.AuthorID == 0)// Insert
                        lib.Authors.Add(author);
                    else//update
                        lib.Entry(author).State = System.Data.Entity.EntityState.Modified;
                    lib.SaveChanges();
                    author.AuthorID = 0;
                }

                PopulateDataGridView();
                MessageBox.Show("Информацията е записана успешно!");

                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Не сте маркирали ред за изтриване!","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                if (textBox1.Text != "")
                {
                    if (MessageBox.Show("Сигурни ли сте че искате да изтриете посочения запис?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (DBModels lib = new DBModels())
                        {
                            var entry = lib.Entry(author);
                            if (entry.State == System.Data.Entity.EntityState.Detached)
                                lib.Authors.Attach(author);
                            lib.Authors.Remove(author);
                            lib.SaveChanges();
                            PopulateDataGridView();

                            MessageBox.Show("Информацията е изтрита успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            author.AuthorID = 0;
                            textBox1.Clear();
                            textBox2.Clear();

                        }
                    }
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPanel formAdmin = new AdminPanel();
            this.Hide();
            formAdmin.Show();
        }

        private void FormAddAuthor_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {

                    author.AuthorID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthorID"].Value);
                    using (DBModels lib = new DBModels())
                    {
                        author = lib.Authors.Where(x => x.AuthorID == author.AuthorID).FirstOrDefault();
                        textBox1.Text = author.FirstName;
                        textBox2.Text = author.LastName;
                    }

                    buttonDelete.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Няма въведени автори!", "Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (DBModels lib = new DBModels())
            {
                var query = from author in lib.Authors
                            where author.FirstName == textBox1.Text.Trim().ToLower() || author.LastName == textBox2.Text.Trim().ToLower()
                                select author;

                 dataGridView1.DataSource = query.ToList();

            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void buttonAddBooks_Click(object sender, EventArgs e)
        {
            FormAddBook form = new FormAddBook();
            this.Hide();
            form.Show();
        }

       
    }
}
