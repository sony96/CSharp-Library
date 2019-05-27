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
    public partial class FormBorrowedBooks : Form
    {
        Borrowing borrow = new Borrowing();
        Book book = new Book();
        Reader reader = new Reader();
        public FormBorrowedBooks()
        {
            InitializeComponent();
        }

        private void FormBorrowedBooks_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        void PopulateDataGridView()
        {
            using (DBModels lib = new DBModels())
            {
                var result = from borrow in lib.Borrowings
                             join reader in lib.Readers on borrow.ReaderID equals reader.ReaderID
                             join book in lib.Books on borrow.BookID equals book.BookID
                             where (borrow.ReaderID == reader.ReaderID) && (borrow.BookID == book.BookID)
                             orderby borrow.DateOfReturning
                             select new {ID = borrow.ID, ReaderID = reader.Firstname + " " + reader.Lastname, BookID = book.Title, DateOfBorrowing = borrow.DateOfBorrowing, DateOfReturning = borrow.DateOfReturning, reader.Phone, reader.Email };
                dataGridView1.DataSource = result.ToList();
            }
        }

        private void FormBorrowedBooks_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            toolTipReturn.SetToolTip(this.buttonReturn, "Връщане на книга");
            toolTipRefresh.SetToolTip(this.buttonRefresh, "Обнови");
            toolTipSearch.SetToolTip(this.buttonSearch, "Търси");
            toolTipBack.SetToolTip(this.buttonBack, "Назад");

            textBox1.ReadOnly = true; textBox2.ReadOnly = true;
            buttonReturn.Enabled = false; buttonSearch.Enabled = false;
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            radioButtonReturn.Enabled = true;
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    using (DBModels lib = new DBModels())
                    {
                        borrow.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                        borrow = lib.Borrowings.Where(x => x.ID == borrow.ID).FirstOrDefault();
                        book = lib.Books.Where(x => x.BookID == borrow.BookID).FirstOrDefault();
                        reader = lib.Readers.Where(x => x.ReaderID == borrow.ReaderID).FirstOrDefault();

                         textBox1.Text = book.Title.ToString();
                         textBox2.Text = reader.Firstname + " "+reader.Lastname;
               
                    }
                }
            }
            catch (Exception)
            {
           
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            string bookTitle = textBox1.Text;
            string readerName = textBox2.Text;
            int bookID, readerID;

            if (bookTitle != "")
            {
                try
                {
                    using (DBModels lib = new DBModels())
                    {
                        book = lib.Books.Where(x => x.Title.ToLower() == bookTitle.ToLower()).FirstOrDefault();
                        bookID = book.BookID;
                    }
                    using (DBModels lib = new DBModels())
                    {
                        var result = from borrow in lib.Borrowings
                                     join reader in lib.Readers on borrow.ReaderID equals reader.ReaderID
                                     join book in lib.Books on borrow.BookID equals book.BookID
                                     where borrow.BookID == bookID
                                     orderby borrow.DateOfReturning
                                     select new { ID = borrow.ID, ReaderID = reader.Firstname + " " + reader.Lastname, BookID = book.Title, DateOfBorrowing = borrow.DateOfBorrowing, DateOfReturning = borrow.DateOfReturning, reader.Phone, reader.Email };
                        dataGridView1.DataSource = result.ToList();
                        dataGridView1.AutoGenerateColumns = false;

                    }
                }
                catch
                {
                    MessageBox.Show("Няма книга с това заглавие!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

            if (readerName != "")
            {
                try
                {
                    using (DBModels lib = new DBModels())
                    {
                        reader = lib.Readers.Where(x => x.Firstname.ToLower() + " " + x.Lastname.ToLower() == readerName.ToLower() ||
                                                    x.Firstname.ToLower() == readerName.ToLower() ||
                                                    x.Lastname.ToLower() == readerName.ToLower()).FirstOrDefault();
                        readerID = reader.ReaderID;
                    }



                    using (DBModels lib = new DBModels())
                    {
                        var result = from borrow in lib.Borrowings
                                     join reader in lib.Readers on borrow.ReaderID equals reader.ReaderID
                                     join book in lib.Books on borrow.BookID equals book.BookID
                                     where borrow.ReaderID == readerID
                                     orderby borrow.DateOfReturning
                                     select new { ID = borrow.ID, ReaderID = reader.Firstname + " " + reader.Lastname, BookID = book.Title, DateOfBorrowing = borrow.DateOfBorrowing, DateOfReturning = borrow.DateOfReturning, reader.Phone, reader.Email };
                        dataGridView1.DataSource = result.ToList();
                        dataGridView1.AutoGenerateColumns = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Няма читател с такова име!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            textBox1.Clear(); textBox2.Clear();
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false; textBox2.ReadOnly = false;
            buttonSearch.Enabled = false; buttonReturn.Enabled = true;
            
        }

        private void radioButtonSearch_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false; textBox2.ReadOnly = false;
            buttonReturn.Enabled = false; buttonSearch.Enabled = true;
     
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            using (DBModels lib = new DBModels())
            {
                try
                {
                    var reader = lib.Readers.First(r => r.Firstname.ToLower() + " " + r.Lastname.ToLower() == textBox2.Text.ToLower() ||
                                                    r.Firstname.ToLower() == textBox2.Text.ToLower() ||
                                                    r.Lastname.ToLower() == textBox2.Text.ToLower());
                

                    var book = lib.Books.First(b => b.Title.ToLower() == textBox1.Text.ToLower());

                   
                    {
                        var row = lib.Borrowings.First(z => z.ReaderID == reader.ReaderID && z.BookID == book.BookID);

                        lib.Borrowings.Attach(row);
                        lib.Borrowings.Remove(row);
                        lib.SaveChanges();
                        PopulateDataGridView();
                    }

                    {
                        book = lib.Books.First(z => z.BookID == book.BookID);
                        book.Count++;
                        lib.Books.Attach(book);
                        lib.Entry(book).State = System.Data.Entity.EntityState.Modified;
                        lib.SaveChanges();
                    }
                    MessageBox.Show("Книгата е върната успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Отавили сте празно поле или сте въвели невярна информация","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

                }          
            }
        }
    }
}
