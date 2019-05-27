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
    public partial class FormRemoveUser : Form
    {
        Reader reader = new Reader();

        public FormRemoveUser()
        {
            InitializeComponent();
        }

        private void FormRemoveUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Не сте маркирали акаунт за изтриване!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (textBox1.Text != "")
                    {
                        if (MessageBox.Show("Сигурни ли сте че искате да изтриете посочения акаунт?", "Message", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            using (DBModels lib = new DBModels())
                            {
                                var entry = lib.Entry(reader);
                                if (entry.State == System.Data.Entity.EntityState.Detached)
                                    lib.Readers.Attach(reader);
                                lib.Readers.Remove(reader);
                                lib.SaveChanges();
                                PopulateDataGridView();

                                MessageBox.Show("Информацията е изтрита успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
                                textBox5.Clear();
                                textBox6.Clear();


                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Записът който се опитвате да изтриете, не може да бъде изтрит, защото участва в други записи!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true;textBox6.ReadOnly = true; 
            buttonDelete.Enabled = true;
            radioButtonDelete.Checked = true;
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    reader.ReaderID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ReaderID"].Value);
                    using (DBModels lib = new DBModels())
                    {
                        reader = lib.Readers.Where(x => x.ReaderID == reader.ReaderID).FirstOrDefault();
                        textBox1.Text = reader.Firstname;
                        textBox2.Text = reader.Lastname;
                        textBox3.Text = reader.Phone;
                        textBox4.Text = reader.Email;
                        textBox5.Text = reader.DateOfRegistration.ToString();
                        textBox6.Text = reader.Username;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Няма потребители!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }


        private void FormRemoveUser_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
            toolTipDelete.SetToolTip(this.buttonDelete, "Изтрии");
            toolTipRefresh.SetToolTip(this.buttonRefresh, "Обнови");
            toolTipSearch.SetToolTip(this.buttonSearch, "Търси");
            toolTipBack.SetToolTip(this.buttonBack, "Назад");

            buttonSearch.Enabled = false;
            buttonDelete.Enabled = false;
        }

        void PopulateDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (DBModels lib = new DBModels())
            {
                dataGridView1.DataSource = lib.Readers.ToList<Reader>();
            }
        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            AdminPanel formAdmin = new AdminPanel();
            this.Hide();
            formAdmin.Show();
        }


        private void radioButtonDelete_Click(object sender, EventArgs e)
        {
           
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            textBox1.ReadOnly = true; textBox2.ReadOnly = true; textBox3.ReadOnly = true; textBox4.ReadOnly = true; textBox5.ReadOnly = true; textBox6.ReadOnly = true;
            buttonDelete.Enabled = true; buttonSearch.Enabled = false;

        }

        private void radioButtonSearch_Click(object sender, EventArgs e)
        {
           
            textBox1.ReadOnly = false; textBox2.ReadOnly = false; textBox3.ReadOnly = false; textBox4.ReadOnly = false;textBox6.ReadOnly = false;
            buttonDelete.Enabled = false; buttonSearch.Enabled = true;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
           
            using (DBModels lib = new DBModels())
            {
                var query = from reader in lib.Readers
                            where  reader.Firstname.ToLower() == textBox1.Text.Trim().ToLower() ||
                            reader.Lastname.ToLower() == textBox2.Text.Trim().ToLower() ||
                            reader.Phone.ToLower() == textBox3.Text.Trim().ToLower() ||
                            reader.Email.ToLower() == textBox4.Text.Trim().ToLower() ||
                            reader.Username.ToLower() == textBox6.Text.Trim().ToLower()
                            select reader;

                dataGridView1.DataSource = query.ToList();

            }
        }

    
    }
}
