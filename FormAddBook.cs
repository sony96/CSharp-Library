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
    public partial class FormAddBook : Form
    {
        Book book = new Book();
        Author author = new Author();
        Publisher publisher = new Publisher();
        Ganre ganre = new Ganre();

        char[] section = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        public FormAddBook()
        {
            InitializeComponent();
        }

        private void FormAddBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void FormAddBook_Load(object sender, EventArgs e)
        {
            toolTipDelete.SetToolTip(this.buttonDelete, "Изтрии");
            toolTipRefresh.SetToolTip(this.buttonRefresh, "Обнови");
            toolTipSearch.SetToolTip(this.buttonSearch, "Търси");
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
            toolTipAddAuthor.SetToolTip(this.buttonAddAuthor, "Добави Автор");
            toolTipAddPublisher.SetToolTip(this.buttonAddPublisher, "Добави Издател");
            toolTipGanre.SetToolTip(this.buttonAddGanre, "Добави Жанр");
            toolTipAddBook.SetToolTip(this.buttonSaveUpdate, "Добави Книгата");
               

            buttonDelete.Enabled = false;
            buttonSearch.Enabled = false;

            using (DBModels lib = new DBModels())
            {
                var result = from table in lib.Authors
                             select new
                             {
                                 AuthorID = table.AuthorID,
                                 Name = table.FirstName + " " + table.LastName
                             };

                comboBox1.DataSource = result.ToList();
                comboBox1.ValueMember = "AuthorID";
                comboBox1.DisplayMember = "Name";

                var publisher = lib.Publishers.Select(a => new { a.PublisherID, a.Name });
                comboBox3.DataSource = publisher.ToList();
                comboBox3.ValueMember = "PublisherID";
                comboBox3.DisplayMember = "Name";

                var ganre = lib.Ganres.Select(a => new { a.GanreID, a.GanreName });
                comboBox4.DataSource = ganre.ToList();
                comboBox4.ValueMember = "GanreID";
                comboBox4.DisplayMember = "GanreName";

                foreach (char element in section)
                {
                    comboBox5.Items.Add(element);
                }

                PopulateDataGridView();
            }
        }

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            AdminPanel formAdmin = new AdminPanel();
            this.Hide();
            formAdmin.Show();

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
                              select new {BookID = book.BookID, title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                dataGridView1.DataSource = results.ToList();
            }

        }

        private void buttonSaveUpdate_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) &&
                comboBox1.ValueMember != null && 
                comboBox3.ValueMember != null && 
                comboBox4.ValueMember != null && 
                !string.IsNullOrEmpty(textBox2.Text))
            {
                book.Title = textBox1.Text.Trim();
                book.AuthorID = Convert.ToInt32(comboBox1.SelectedValue);
                book.PublisherID = Convert.ToInt32(comboBox3.SelectedValue);
                book.GanreID = Convert.ToInt32(comboBox4.SelectedValue);
                book.Section = comboBox5.SelectedItem.ToString();
                book.Count = Convert.ToInt32(textBox2.Text);

                using (DBModels lib = new DBModels())
                {
                    if (book.BookID == 0)// Insert

                        lib.Books.Add(book);
                    else //update
                        lib.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    lib.SaveChanges();
                    book.BookID = 0;
                }

                PopulateDataGridView();
                MessageBox.Show("Информацията е записана успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox1.Clear();
                textBox7.Clear();
            }
            else
            {
                MessageBox.Show("Не сте въвели информация, във всички полета!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Не сте маркирали ред за изтриване!", "Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                if (textBox3.Text != "")
                {
                    try
                    {
                        if (MessageBox.Show("Сигурни ли сте че искате да изтриете посочения запис?", "Внимание!", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            using (DBModels lib = new DBModels())
                            {
                                var entry = lib.Entry(book);
                                if (entry.State == System.Data.Entity.EntityState.Detached)
                                    lib.Books.Attach(book);
                                lib.Books.Remove(book);
                                lib.SaveChanges();
                                PopulateDataGridView();

                                MessageBox.Show("Информацията е изтрита успешно!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                buttonSaveUpdate.Text = "Запази";
                                book.BookID = 0;
                                textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
                            }
                        }
                    }
                    catch {
                        MessageBox.Show("Книгата е заета от читател/и.\nТрябва да бъде върната от всички, за да може да се изтрие от системата!","Внимание",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            radioButtonDelete.Checked = true;
           
            textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true; textBox6.ReadOnly = true; textBox7.ReadOnly = true; textBox8.ReadOnly = true;
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    book.BookID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BookID"].Value.ToString());
                    using (DBModels lib = new DBModels())
                    {
                        
                        book = lib.Books.Where(x => x.BookID == book.BookID).FirstOrDefault();
                        author = lib.Authors.Where(x => x.AuthorID == book.AuthorID).FirstOrDefault();
                        publisher = lib.Publishers.Where(x => x.PublisherID == book.PublisherID).FirstOrDefault();
                        ganre = lib.Ganres.Where(x => x.GanreID == book.GanreID).FirstOrDefault();
                        textBox3.Text = book.Title;
                        textBox4.Text = author.FirstName + " " + author.LastName;
                        textBox5.Text = publisher.Name;
                        textBox6.Text = ganre.GanreName;
                        textBox7.Text = book.Section;
                        textBox8.Text = book.Count.ToString();             
                    }
                    buttonDelete.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Няма въведени книги!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void radioButtonDelete_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true; textBox6.ReadOnly = true; textBox7.ReadOnly = true; textBox8.ReadOnly = true;
            radioButtonSearch.Checked = false;
            buttonDelete.Enabled = true;
        }

        private void radioButtonSearch_Click(object sender, EventArgs e)
        {
            textBox3.ReadOnly = false; textBox4.ReadOnly = false; textBox5.ReadOnly = false; textBox6.ReadOnly = false; textBox7.ReadOnly = false; textBox8.ReadOnly = false;
            buttonDelete.Enabled = false; buttonSearch.Enabled = true;
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            using (DBModels lib = new DBModels())
            {

                var query = from book in lib.Books
                            join author in lib.Authors on book.AuthorID equals author.AuthorID
                            join publisher in lib.Publishers on book.PublisherID equals publisher.PublisherID
                            join ganre in lib.Ganres on book.GanreID equals ganre.GanreID
                            where (book.Title.ToLower() == textBox3.Text.Trim().ToLower())
                            || (author.FirstName.ToLower() + " " + author.LastName.ToLower() == textBox4.Text.ToLower()
                            || author.FirstName.ToLower() == textBox4.Text.ToLower()
                            || author.LastName.ToLower() == textBox4.Text.ToLower())
                            || (book.Section == textBox7.Text)
                            || (publisher.Name.ToLower() == textBox5.Text.ToLower())
                            || (ganre.GanreName.ToLower() == textBox6.Text.ToLower())
                            || (book.Count.ToString() == textBox8.Text)
                            select new { BookID = book.BookID, title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };

                dataGridView1.DataSource = query.ToList();

            }
        }

        void ClearTextBoxes()
        {
            textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
        }
        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            PopulateDataGridView();
            ClearTextBoxes();

        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            FormAddAuthor form = new FormAddAuthor();
            this.Hide();
            form.Show();
        }

        private void buttonAddPublisher_Click(object sender, EventArgs e)
        {
            FormAddPublisher form = new FormAddPublisher();
            this.Hide();
            form.Show();
        }

        private void buttonAddGanre_Click(object sender, EventArgs e)
        {
            FormAddGanre form = new FormAddGanre();
            this.Hide();
            form.Show();
        }
    }
}
