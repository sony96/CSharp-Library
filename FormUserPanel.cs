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
    public partial class FormUserPanel : Form
    {
        int currentUserID, bookCount, titleID;
        string userName;
        string userLastName;
        bool isBookBorrow = false;

        Book book = new Book();
        Borrowing borrow = new Borrowing();
        Author author = new Author();
        Ganre ganre = new Ganre();
        Publisher publisher = new Publisher();

        DateTime after15days;
        DateTime after30days;
        DateTime after60days;
     

        public FormUserPanel()
        {
            InitializeComponent();

        }

        public void RecieveUserInfo(int id, string Name, string LastName)
        {
            currentUserID = id;
            userName = Name;
            userLastName = LastName;
        }

        private void FormUserPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartPanel form = new StartPanel();
            this.Hide();
            form.Show();
        }

        private void FormUserPanel_Load(object sender, EventArgs e)
        {
            labelUserInfo.Text = "Здравейте " + userName + " " + userLastName;
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            PopulateDataGridView();

            toolTipLogout.SetToolTip(this.buttonLogout, "Назад");
            toolTipBorrow.SetToolTip(this.buttonBorrow, "Заемане");
            toolTipRefresh.SetToolTip(this.buttonRefresh, "Обнови");
            toolTipSearch.SetToolTip(this.buttonSearch, "Търси");

            DateTime today = DateTime.Now;
            after15days = today.AddDays(15);
            after30days = today.AddDays(30);
            after60days = today.AddDays(60);
        }

        void PopulateDataGridView()
        {
            dataGridView2.AutoGenerateColumns = false;
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

            dataGridView2.AutoGenerateColumns = false;

            using (DBModels lib = new DBModels())
            {
                var result = from borrow in lib.Borrowings
                             join reader in lib.Readers on borrow.ReaderID equals reader.ReaderID
                             join book in lib.Books on borrow.BookID equals book.BookID
                             where (borrow.ReaderID == currentUserID) && (borrow.ReaderID == reader.ReaderID) && (borrow.BookID == book.BookID)
                             select new { ReaderID = reader.Firstname + " " + reader.Lastname, BookID = book.Title, DateOfBorrowing = borrow.DateOfBorrowing, DateOfReturning = borrow.DateOfReturning };
                dataGridView2.DataSource = result.ToList();
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            if (radioButtonTitle.Checked == false && radioButtonAuthor.Checked == false && radioButtonPublisher.Checked == false && radioButtonGanre.Checked == false && radioButtonSection.Checked == false)
            {
                MessageBox.Show("Не сте избрали критерии, по който да търсите!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                if (radioButtonTitle.Checked)
                {
                    using (DBModels lib = new DBModels())
                    {
                        PopulateDataGridView();
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
                                    select new { title = book.Title, AuthorID = author.FirstName + " " + author.LastName, PublisherID = publisher.Name, ganreID = ganre.GanreName, book.Section, book.Count };
                        dataGridView1.AutoGenerateColumns = false;
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


        private void radioButtonTitle_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            ClearTextBoxes();
        }

        private void radioButtonAuthor_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = false; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            ClearTextBoxes();
        }

        private void radioButtonPublisher_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = false; textBox4.ReadOnly = true; textBox5.ReadOnly = true;
            ClearTextBoxes();
        }

        private void radioButtonGanre_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = false; textBox5.ReadOnly = true;
            ClearTextBoxes();
        }

        private void radioButtonSection_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = false;
            ClearTextBoxes();
        }

        public void ClearTextBoxes()
        {
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            ClearTextBoxes();
        }

    


      

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true; textBox6.ReadOnly = true;
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    book.Title = dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
                    using (DBModels lib = new DBModels())
                    {
                        book = lib.Books.Where(x => x.Title == book.Title).FirstOrDefault();
                        borrow.ReaderID = currentUserID;
                        borrow.BookID = book.BookID;
                        borrow.DateOfBorrowing = DateTime.Now;
                        textBox6.Text = book.Title;

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Няма въведени книги!","Вниамние",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }



        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            bool returnDateConfirmed = false;

            if (!string.IsNullOrEmpty(textBox6.Text))
            {

                bookCount = int.Parse(book.Count.ToString());

                if (radioButton15days.Checked)
                {
                    borrow.DateOfReturning = after15days;
                    returnDateConfirmed = true;
                }
                else if (radioButton30days.Checked)
                {
                    borrow.DateOfReturning = after30days;
                    returnDateConfirmed = true;
                }
                else if (radioButton60days.Checked)
                {
                    borrow.DateOfReturning = after60days;
                    returnDateConfirmed = true;
                }


                using (DBModels lib = new DBModels())
                {

                    book = lib.Books.Where(x => x.Title.ToLower() == textBox6.Text.ToLower()).FirstOrDefault();
                    titleID = book.BookID;

                    var queryTitle = from borrow in lib.Borrowings
                                     where (borrow.BookID == titleID) && (borrow.ReaderID == currentUserID)
                                     select borrow.BookID;

                    if (queryTitle.Count() != 0)
                    {
                        isBookBorrow = true;
                    }
                    else
                    {
                        isBookBorrow = false;
                    }

                }


                if (isBookBorrow == false && returnDateConfirmed == true)
                {

                    if (bookCount != 0)
                    {
                        book.Count--;

                        if ((radioButton15days.Checked = true) || (radioButton30days.Checked = true) || (radioButton60days.Checked = true))
                        {

                            using (DBModels lib = new DBModels())
                            {

                                lib.Books.Attach(book);
                                lib.Entry(book).State = System.Data.Entity.EntityState.Modified;
                                lib.SaveChanges();

                            }

                            using (DBModels lib = new DBModels())
                            {
                                lib.Borrowings.Add(borrow);
                                lib.SaveChanges();
                                MessageBox.Show("Книгата която избрахте е записана към вашия архив!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                textBox6.Clear();
                                PopulateDataGridView();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не сте избрали период за заемане на книгата!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Няма повече налични бройки от тази книга!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Вече сте заели книгата!","Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Не сте избрали книга!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         
        }
    }
}

