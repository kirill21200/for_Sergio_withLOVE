namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.open = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.TextBox();
            this.artist = new System.Windows.Forms.TextBox();
            this.album = new System.Windows.Forms.TextBox();
            this.year = new System.Windows.Forms.TextBox();
            this.comment = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.audioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.audioBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mainPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(6, 21);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(113, 29);
            this.open.TabIndex = 0;
            this.open.Text = "Открыть";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(125, 21);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(159, 29);
            this.play.TabIndex = 1;
            this.play.Text = "Воспроизведение";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(290, 21);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(132, 29);
            this.stop.TabIndex = 2;
            this.stop.Text = "Остановить";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // title
            // 
            this.title.Location = new System.Drawing.Point(6, 56);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(416, 22);
            this.title.TabIndex = 3;
            // 
            // artist
            // 
            this.artist.Location = new System.Drawing.Point(6, 84);
            this.artist.Name = "artist";
            this.artist.Size = new System.Drawing.Size(416, 22);
            this.artist.TabIndex = 4;
            // 
            // album
            // 
            this.album.Location = new System.Drawing.Point(6, 112);
            this.album.Name = "album";
            this.album.Size = new System.Drawing.Size(416, 22);
            this.album.TabIndex = 5;
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(6, 140);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(416, 22);
            this.year.TabIndex = 6;
            // 
            // comment
            // 
            this.comment.Location = new System.Drawing.Point(6, 168);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(416, 22);
            this.comment.TabIndex = 7;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.groupBox1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(452, 211);
            this.mainPanel.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stop);
            this.groupBox1.Controls.Add(this.open);
            this.groupBox1.Controls.Add(this.artist);
            this.groupBox1.Controls.Add(this.comment);
            this.groupBox1.Controls.Add(this.title);
            this.groupBox1.Controls.Add(this.play);
            this.groupBox1.Controls.Add(this.album);
            this.groupBox1.Controls.Add(this.year);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 199);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление";
            // 
            // audioBindingSource
            // 
            this.audioBindingSource.DataMember = "Audio";
            // 
            // audioBindingSource1
            // 
            this.audioBindingSource1.DataMember = "Audio";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 211);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox artist;
        private System.Windows.Forms.TextBox album;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource audioBindingSource;
        private System.Windows.Forms.BindingSource audioBindingSource1;
    }
}

