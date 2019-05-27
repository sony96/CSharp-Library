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
    public partial class FormAddGanre : Form
    {
        Ganre ganre = new Ganre();

        public FormAddGanre()
        {
            InitializeComponent();
            toolTipSaveEdit.SetToolTip(this.buttonSaveUpdate, "Запази");
            toolTipDelete.SetToolTip(this.buttonDelete, "Изтрии");
            toolTipRefresh.SetToolTip(this.buttonRefresh, "Обнови");
            toolTipSearch.SetToolTip(this.buttonSearch, "Търси");
            toolTipAddBooks.SetToolTip(this.buttonAddBooks, "Добавяне на книги");
            toolTipBack.SetToolTip(this.buttonBack, "Назад");
        }

        private void FormAddGanre_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        void PopulateDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (DBModels lib = new DBModels())
            {
                dataGridView1.DataSource = lib.Ganres.ToList<Ganre>();
            }
        }

        private void FormAddGanre_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void buttonSaveUpdate_Click(object sender, EventArgs e)
        {
            ganre.GanreName = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Не сте въвели информация!", "Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                using (DBModels lib = new DBModels())
                {
                    if (ganre.GanreID == 0)// Insert
                        lib.Ganres.Add(ganre);
                    else //update
                        lib.Entry(ganre).State = System.Data.Entity.EntityState.Modified;
                        lib.SaveChanges();
                        ganre.GanreID = 0;
                }

                PopulateDataGridView();
                MessageBox.Show("Информацията е записана успешно!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                textBox1.Clear();
           
                
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
                            var entry = lib.Entry(ganre);
                            if (entry.State == System.Data.Entity.EntityState.Detached)
                                lib.Ganres.Attach(ganre);
                            lib.Ganres.Remove(ganre);
                            lib.SaveChanges();
                            PopulateDataGridView();

                            MessageBox.Show("Информацията е изтрита успешно!");

                            ganre.GanreID = 0;
                            textBox1.Clear();
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
                    ganre.GanreID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["GanreID"].Value);
                    using (DBModels lib = new DBModels())
                    {
                        ganre = lib.Ganres.Where(x => x.GanreID == ganre.GanreID).FirstOrDefault();
                        textBox1.Text = ganre.GanreName;
                    }

                    buttonDelete.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Няма въведени жанрове!");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (DBModels lib = new DBModels())
            {
                var query = from ganre in lib.Ganres
                            where  ganre.GanreName.ToLower() == textBox1.Text.Trim().ToLower()
                            select ganre;

                dataGridView1.DataSource = query.ToList();

            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            textBox1.Clear();
        }

        private void buttonAddBooks_Click(object sender, EventArgs e)
        {
            FormAddBook form = new FormAddBook();
            this.Hide();
            form.Show();
        }
    }
}
