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
    public partial class FormAddPublisher : Form
    {
        Publisher publisher = new Publisher();

        public FormAddPublisher()
        {
            InitializeComponent();
        }

        private void FormAddPublisher_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        void PopulateDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (DBModels lib = new DBModels())
            {
                dataGridView1.DataSource = lib.Publishers.ToList<Publisher>();
            }
        }

        private void FormAddPublisher_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            toolTipSaveEdit.SetToolTip(this.buttonSaveUpdate, "Запази");
            toolTipDelete.SetToolTip(this.buttonDelete, "Изтрии");
            toolTipRefresh.SetToolTip(this.buttonRefresh, "Обнови");
            toolTipSearch.SetToolTip(this.buttonSearch, "Търси");
            toolTipAddBooks.SetToolTip(this.buttonAddBooks, "Добавяне на книги");
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
        }

        private void buttonSaveUpdate_Click(object sender, EventArgs e)
        {
            publisher.Name = textBox1.Text.Trim();
            publisher.Address = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Не сте въвели информация!", "Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                using (DBModels lib = new DBModels())
                {
                    if (publisher.PublisherID == 0)// Insert
                        lib.Publishers.Add(publisher);
                    else//update
                        lib.Entry(publisher).State = System.Data.Entity.EntityState.Modified;
                        lib.SaveChanges();
                        publisher.PublisherID = 0;
                }

                PopulateDataGridView();
                MessageBox.Show("Информацията е записана успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
              
                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Не сте маркирали ред за изтриване!", "Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                if (textBox1.Text != "")
                {
                    if (MessageBox.Show("Сигурни ли сте че искате да изтриете посочения запис?", "Message", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        using (DBModels lib = new DBModels())
                        {
                            var entry = lib.Entry(publisher);
                            if (entry.State == System.Data.Entity.EntityState.Detached)
                                lib.Publishers.Attach(publisher);
                            lib.Publishers.Remove(publisher);
                            lib.SaveChanges();
                            PopulateDataGridView();

                            MessageBox.Show("Информацията е изтрита успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            publisher.PublisherID = 0;
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.Show();
        }


        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    publisher.PublisherID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PublisherID"].Value);
                    using (DBModels lib = new DBModels())
                    {
                        publisher = lib.Publishers.Where(x => x.PublisherID == publisher.PublisherID).FirstOrDefault();
                        textBox1.Text = publisher.Name;
                        textBox2.Text = publisher.Address;
                    }

                    buttonDelete.Enabled = true;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Няма въведени издатели!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (DBModels lib = new DBModels())
            {
                var query = from publisher in lib.Publishers
                            where publisher.Name.ToLower() == textBox1.Text.Trim().ToLower() || publisher.Address.ToLower() == textBox2.Text.Trim().ToLower()
                            select publisher;

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
