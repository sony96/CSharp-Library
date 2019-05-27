namespace Libb
{
    partial class FormUserPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserPanel));
            this.buttonLogout = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublisherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GanreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.radioButtonSection = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonTitle = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.radioButtonGanre = new System.Windows.Forms.RadioButton();
            this.radioButtonPublisher = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.radioButtonAuthor = new System.Windows.Forms.RadioButton();
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton60days = new System.Windows.Forms.RadioButton();
            this.radioButton30days = new System.Windows.Forms.RadioButton();
            this.radioButton15days = new System.Windows.Forms.RadioButton();
            this.buttonBorrow = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowBookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBorrowing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfReturning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTipBorrow = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipRefresh = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSearch = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipLogout = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogout.Image")));
            this.buttonLogout.Location = new System.Drawing.Point(16, 33);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(40, 40);
            this.buttonLogout.TabIndex = 0;
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookID,
            this.Title,
            this.AuthorID,
            this.PublisherID,
            this.GanreID,
            this.Section,
            this.Count});
            this.dataGridView1.Location = new System.Drawing.Point(465, 252);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(896, 440);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
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
            this.Count.HeaderText = "Налични бройки";
            this.Count.Name = "Count";
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
            this.groupBox6.Location = new System.Drawing.Point(465, 79);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(896, 156);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Критерии за  търсене по:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(6, 92);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(40, 40);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(673, 43);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(156, 20);
            this.textBox5.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.Location = new System.Drawing.Point(396, 92);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(40, 40);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
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
            this.radioButtonSection.CheckedChanged += new System.EventHandler(this.radioButtonSection_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 3;
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
            this.radioButtonTitle.CheckedChanged += new System.EventHandler(this.radioButtonTitle_CheckedChanged_1);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(349, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(156, 20);
            this.textBox3.TabIndex = 3;
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
            this.radioButtonGanre.CheckedChanged += new System.EventHandler(this.radioButtonGanre_CheckedChanged);
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
            this.radioButtonPublisher.CheckedChanged += new System.EventHandler(this.radioButtonPublisher_CheckedChanged_1);
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
            this.radioButtonAuthor.CheckedChanged += new System.EventHandler(this.radioButtonAuthor_CheckedChanged_1);
            // 
            // labelUserInfo
            // 
            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserInfo.ForeColor = System.Drawing.Color.Red;
            this.labelUserInfo.Location = new System.Drawing.Point(12, 9);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(87, 24);
            this.labelUserInfo.TabIndex = 9;
            this.labelUserInfo.Text = "UserInfo";
            // 
            // groupBox14
            // 
            this.groupBox14.BackColor = System.Drawing.Color.Bisque;
            this.groupBox14.Controls.Add(this.groupBox2);
            this.groupBox14.Controls.Add(this.buttonBorrow);
            this.groupBox14.Controls.Add(this.groupBox8);
            this.groupBox14.Location = new System.Drawing.Point(16, 79);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(433, 156);
            this.groupBox14.TabIndex = 10;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Заемане";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FloralWhite;
            this.groupBox2.Controls.Add(this.radioButton60days);
            this.groupBox2.Controls.Add(this.radioButton30days);
            this.groupBox2.Controls.Add(this.radioButton15days);
            this.groupBox2.Location = new System.Drawing.Point(29, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 47);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заемане за период от:";
            // 
            // radioButton60days
            // 
            this.radioButton60days.AutoSize = true;
            this.radioButton60days.Location = new System.Drawing.Point(214, 19);
            this.radioButton60days.Name = "radioButton60days";
            this.radioButton60days.Size = new System.Drawing.Size(58, 17);
            this.radioButton60days.TabIndex = 5;
            this.radioButton60days.TabStop = true;
            this.radioButton60days.Text = "60 дни";
            this.radioButton60days.UseVisualStyleBackColor = true;
            // 
            // radioButton30days
            // 
            this.radioButton30days.AutoSize = true;
            this.radioButton30days.Location = new System.Drawing.Point(122, 19);
            this.radioButton30days.Name = "radioButton30days";
            this.radioButton30days.Size = new System.Drawing.Size(58, 17);
            this.radioButton30days.TabIndex = 4;
            this.radioButton30days.TabStop = true;
            this.radioButton30days.Text = "30 дни";
            this.radioButton30days.UseVisualStyleBackColor = true;
            // 
            // radioButton15days
            // 
            this.radioButton15days.AutoSize = true;
            this.radioButton15days.Location = new System.Drawing.Point(39, 19);
            this.radioButton15days.Name = "radioButton15days";
            this.radioButton15days.Size = new System.Drawing.Size(58, 17);
            this.radioButton15days.TabIndex = 3;
            this.radioButton15days.TabStop = true;
            this.radioButton15days.Text = "15 дни";
            this.radioButton15days.UseVisualStyleBackColor = true;
            // 
            // buttonBorrow
            // 
            this.buttonBorrow.Image = ((System.Drawing.Image)(resources.GetObject("buttonBorrow.Image")));
            this.buttonBorrow.Location = new System.Drawing.Point(375, 92);
            this.buttonBorrow.Name = "buttonBorrow";
            this.buttonBorrow.Size = new System.Drawing.Size(40, 40);
            this.buttonBorrow.TabIndex = 1;
            this.buttonBorrow.UseVisualStyleBackColor = true;
            this.buttonBorrow.Click += new System.EventHandler(this.buttonBorrow_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox6);
            this.groupBox8.Location = new System.Drawing.Point(14, 26);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(401, 53);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Заглавие на книга";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(15, 19);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(369, 20);
            this.textBox6.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ReaderID,
            this.BorrowBookID,
            this.DateOfBorrowing,
            this.DateOfReturning});
            this.dataGridView2.Location = new System.Drawing.Point(16, 252);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(433, 440);
            this.dataGridView2.TabIndex = 11;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // ReaderID
            // 
            this.ReaderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReaderID.HeaderText = "Читател";
            this.ReaderID.Name = "ReaderID";
            this.ReaderID.Visible = false;
            // 
            // BorrowBookID
            // 
            this.BorrowBookID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BorrowBookID.DataPropertyName = "BookID";
            this.BorrowBookID.HeaderText = "Книга";
            this.BorrowBookID.Name = "BorrowBookID";
            // 
            // DateOfBorrowing
            // 
            this.DateOfBorrowing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateOfBorrowing.DataPropertyName = "DateOfBorrowing";
            this.DateOfBorrowing.HeaderText = "Дата на заемане";
            this.DateOfBorrowing.Name = "DateOfBorrowing";
            // 
            // DateOfReturning
            // 
            this.DateOfReturning.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DateOfReturning.DataPropertyName = "DateOfReturning";
            this.DateOfReturning.HeaderText = "Дата на връщане";
            this.DateOfReturning.Name = "DateOfReturning";
            // 
            // FormUserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1373, 704);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.labelUserInfo);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormUserPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserPanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUserPanel_FormClosing);
            this.Load += new System.EventHandler(this.FormUserPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.RadioButton radioButtonSection;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonTitle;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton radioButtonGanre;
        private System.Windows.Forms.RadioButton radioButtonPublisher;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioButtonAuthor;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button buttonBorrow;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowBookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBorrowing;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfReturning;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton60days;
        private System.Windows.Forms.RadioButton radioButton30days;
        private System.Windows.Forms.RadioButton radioButton15days;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublisherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GanreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.ToolTip toolTipBorrow;
        private System.Windows.Forms.ToolTip toolTipRefresh;
        private System.Windows.Forms.ToolTip toolTipSearch;
        private System.Windows.Forms.ToolTip toolTipLogout;
    }
}