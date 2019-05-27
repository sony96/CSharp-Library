namespace Libb
{
    partial class StartPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPanel));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.входЗаПотребителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отностноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublisherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GanreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioButtonTitle = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.radioButtonAuthor = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.radioButtonPublisher = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.radioButtonGanre = new System.Windows.Forms.RadioButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.radioButtonSection = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.входЗаПотребителиToolStripMenuItem,
            this.отностноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(965, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.adminToolStripMenuItem.Text = "Админ панел";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // входЗаПотребителиToolStripMenuItem
            // 
            this.входЗаПотребителиToolStripMenuItem.Name = "входЗаПотребителиToolStripMenuItem";
            this.входЗаПотребителиToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.входЗаПотребителиToolStripMenuItem.Text = "Вход за потребители";
            this.входЗаПотребителиToolStripMenuItem.Click += new System.EventHandler(this.входЗаПотребителиToolStripMenuItem_Click);
            // 
            // отностноToolStripMenuItem
            // 
            this.отностноToolStripMenuItem.Name = "отностноToolStripMenuItem";
            this.отностноToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.отностноToolStripMenuItem.Text = "Отностно";
            this.отностноToolStripMenuItem.Click += new System.EventHandler(this.отностноToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookID,
            this.Title,
            this.AuthorID,
            this.PublisherID,
            this.GanreID,
            this.Section,
            this.Count});
            this.dataGridView1.Location = new System.Drawing.Point(24, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(913, 338);
            this.dataGridView1.TabIndex = 1;
            // 
            // BookID
            // 
            this.BookID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BookID.DataPropertyName = "BookID";
            this.BookID.HeaderText = "BookID";
            this.BookID.Name = "BookID";
            this.BookID.Visible = false;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Заглавие на книга";
            this.Title.Name = "Title";
            // 
            // AuthorID
            // 
            this.AuthorID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthorID.DataPropertyName = "AuthorID";
            this.AuthorID.HeaderText = "Автор";
            this.AuthorID.Name = "AuthorID";
            // 
            // PublisherID
            // 
            this.PublisherID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PublisherID.DataPropertyName = "PublisherID";
            this.PublisherID.HeaderText = "Издател";
            this.PublisherID.Name = "PublisherID";
            // 
            // GanreID
            // 
            this.GanreID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GanreID.DataPropertyName = "GanreID";
            this.GanreID.HeaderText = "Жанр";
            this.GanreID.Name = "GanreID";
            // 
            // Section
            // 
            this.Section.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Секция";
            this.Section.Name = "Section";
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "Бройки";
            this.Count.Name = "Count";
            // 
            // radioButtonTitle
            // 
            this.radioButtonTitle.AutoSize = true;
            this.radioButtonTitle.Location = new System.Drawing.Point(25, 19);
            this.radioButtonTitle.Name = "radioButtonTitle";
            this.radioButtonTitle.Size = new System.Drawing.Size(73, 17);
            this.radioButtonTitle.TabIndex = 1;
            this.radioButtonTitle.Text = "Заглавие";
            this.radioButtonTitle.UseVisualStyleBackColor = true;
            this.radioButtonTitle.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Linen;
            this.buttonSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(397, 97);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(40, 40);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(187, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 3;
            // 
            // radioButtonAuthor
            // 
            this.radioButtonAuthor.AutoSize = true;
            this.radioButtonAuthor.Location = new System.Drawing.Point(187, 20);
            this.radioButtonAuthor.Name = "radioButtonAuthor";
            this.radioButtonAuthor.Size = new System.Drawing.Size(55, 17);
            this.radioButtonAuthor.TabIndex = 3;
            this.radioButtonAuthor.Text = "Автор";
            this.radioButtonAuthor.UseVisualStyleBackColor = true;
            this.radioButtonAuthor.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(349, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(156, 20);
            this.textBox3.TabIndex = 3;
            // 
            // radioButtonPublisher
            // 
            this.radioButtonPublisher.AutoSize = true;
            this.radioButtonPublisher.Location = new System.Drawing.Point(349, 20);
            this.radioButtonPublisher.Name = "radioButtonPublisher";
            this.radioButtonPublisher.Size = new System.Drawing.Size(68, 17);
            this.radioButtonPublisher.TabIndex = 2;
            this.radioButtonPublisher.Text = "Издател";
            this.radioButtonPublisher.UseVisualStyleBackColor = true;
            this.radioButtonPublisher.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(511, 43);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(156, 20);
            this.textBox4.TabIndex = 3;
            // 
            // radioButtonGanre
            // 
            this.radioButtonGanre.AutoSize = true;
            this.radioButtonGanre.Location = new System.Drawing.Point(511, 19);
            this.radioButtonGanre.Name = "radioButtonGanre";
            this.radioButtonGanre.Size = new System.Drawing.Size(54, 17);
            this.radioButtonGanre.TabIndex = 4;
            this.radioButtonGanre.Text = "Жанр";
            this.radioButtonGanre.UseVisualStyleBackColor = true;
            this.radioButtonGanre.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(673, 43);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(156, 20);
            this.textBox5.TabIndex = 3;
            // 
            // radioButtonSection
            // 
            this.radioButtonSection.AutoSize = true;
            this.radioButtonSection.Location = new System.Drawing.Point(673, 19);
            this.radioButtonSection.Name = "radioButtonSection";
            this.radioButtonSection.Size = new System.Drawing.Size(62, 17);
            this.radioButtonSection.TabIndex = 5;
            this.radioButtonSection.Text = "Секция";
            this.radioButtonSection.UseVisualStyleBackColor = true;
            this.radioButtonSection.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Bisque;
            this.groupBox6.Controls.Add(this.buttonRefresh);
            this.groupBox6.Controls.Add(this.textBox5);
            this.groupBox6.Controls.Add(this.buttonSearch);
            this.groupBox6.Controls.Add(this.radioButtonSection);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.radioButtonTitle);
            this.groupBox6.Controls.Add(this.textBox3);
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Controls.Add(this.radioButtonGanre);
            this.groupBox6.Controls.Add(this.radioButtonPublisher);
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.radioButtonAuthor);
            this.groupBox6.Location = new System.Drawing.Point(58, 27);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(858, 143);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Критерии за  търсене по:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Linen;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(812, 97);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(40, 40);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // StartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(965, 556);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Manager ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartPanel_FormClosing);
            this.Load += new System.EventHandler(this.StartPanel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem входЗаПотребителиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublisherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GanreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.RadioButton radioButtonTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioButtonAuthor;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton radioButtonPublisher;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton radioButtonGanre;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.RadioButton radioButtonSection;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolStripMenuItem отностноToolStripMenuItem;
    }
}

