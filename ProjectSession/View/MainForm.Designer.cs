namespace ProjectSession
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dealSet_button = new System.Windows.Forms.Button();
            this.demand_set_button = new System.Windows.Forms.Button();
            this.supplyset_button = new System.Windows.Forms.Button();
            this.lands_button = new System.Windows.Forms.Button();
            this.houses_button = new System.Windows.Forms.Button();
            this.apartments_button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.childFormPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-7, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 413);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(122)))));
            this.panel2.Controls.Add(this.dealSet_button);
            this.panel2.Controls.Add(this.demand_set_button);
            this.panel2.Controls.Add(this.supplyset_button);
            this.panel2.Controls.Add(this.lands_button);
            this.panel2.Controls.Add(this.houses_button);
            this.panel2.Controls.Add(this.apartments_button);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.ForeColor = System.Drawing.Color.Coral;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 407);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dealSet_button
            // 
            this.dealSet_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.dealSet_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.dealSet_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dealSet_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dealSet_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dealSet_button.Location = new System.Drawing.Point(0, 245);
            this.dealSet_button.Margin = new System.Windows.Forms.Padding(50);
            this.dealSet_button.Name = "dealSet_button";
            this.dealSet_button.Size = new System.Drawing.Size(178, 35);
            this.dealSet_button.TabIndex = 8;
            this.dealSet_button.Text = "Сделки";
            this.dealSet_button.UseVisualStyleBackColor = false;
            this.dealSet_button.Click += new System.EventHandler(this.dealSet_button_Click);
            // 
            // demand_set_button
            // 
            this.demand_set_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.demand_set_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.demand_set_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.demand_set_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.demand_set_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.demand_set_button.Location = new System.Drawing.Point(0, 210);
            this.demand_set_button.Margin = new System.Windows.Forms.Padding(50);
            this.demand_set_button.Name = "demand_set_button";
            this.demand_set_button.Size = new System.Drawing.Size(178, 35);
            this.demand_set_button.TabIndex = 7;
            this.demand_set_button.Text = "Потребность";
            this.demand_set_button.UseVisualStyleBackColor = false;
            this.demand_set_button.Click += new System.EventHandler(this.demand_set_button_Click);
            // 
            // supplyset_button
            // 
            this.supplyset_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.supplyset_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.supplyset_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplyset_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supplyset_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.supplyset_button.Location = new System.Drawing.Point(0, 175);
            this.supplyset_button.Margin = new System.Windows.Forms.Padding(50);
            this.supplyset_button.Name = "supplyset_button";
            this.supplyset_button.Size = new System.Drawing.Size(178, 35);
            this.supplyset_button.TabIndex = 6;
            this.supplyset_button.Text = "Предолжения";
            this.supplyset_button.UseVisualStyleBackColor = false;
            this.supplyset_button.Click += new System.EventHandler(this.supplyset_button_Click);
            // 
            // lands_button
            // 
            this.lands_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.lands_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.lands_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lands_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lands_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lands_button.Location = new System.Drawing.Point(0, 140);
            this.lands_button.Margin = new System.Windows.Forms.Padding(50);
            this.lands_button.Name = "lands_button";
            this.lands_button.Size = new System.Drawing.Size(178, 35);
            this.lands_button.TabIndex = 5;
            this.lands_button.Text = "Участки";
            this.lands_button.UseVisualStyleBackColor = false;
            this.lands_button.Click += new System.EventHandler(this.lands_button_Click);
            // 
            // houses_button
            // 
            this.houses_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.houses_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.houses_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.houses_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.houses_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.houses_button.Location = new System.Drawing.Point(0, 105);
            this.houses_button.Margin = new System.Windows.Forms.Padding(50);
            this.houses_button.Name = "houses_button";
            this.houses_button.Size = new System.Drawing.Size(178, 35);
            this.houses_button.TabIndex = 4;
            this.houses_button.Text = "Дома";
            this.houses_button.UseVisualStyleBackColor = false;
            this.houses_button.Click += new System.EventHandler(this.houses_button_Click);
            // 
            // apartments_button
            // 
            this.apartments_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.apartments_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.apartments_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apartments_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.apartments_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.apartments_button.Location = new System.Drawing.Point(0, 70);
            this.apartments_button.Margin = new System.Windows.Forms.Padding(50);
            this.apartments_button.Name = "apartments_button";
            this.apartments_button.Size = new System.Drawing.Size(178, 35);
            this.apartments_button.TabIndex = 3;
            this.apartments_button.Text = "Квартиры";
            this.apartments_button.UseVisualStyleBackColor = false;
            this.apartments_button.Click += new System.EventHandler(this.apartments_button_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(0, 35);
            this.button3.Margin = new System.Windows.Forms.Padding(50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Риэлторы";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(111)))), ((int)(((byte)(211)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(178, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Клиенты";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // childFormPanel
            // 
            this.childFormPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.childFormPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(84)))));
            this.childFormPanel.Location = new System.Drawing.Point(169, 36);
            this.childFormPanel.Name = "childFormPanel";
            this.childFormPanel.Size = new System.Drawing.Size(886, 416);
            this.childFormPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(95)))), ((int)(((byte)(207)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1055, 36);
            this.panel3.TabIndex = 2;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(453, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Риэлторское агенство ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1055, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.childFormPanel);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное окно";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel childFormPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button lands_button;
        private System.Windows.Forms.Button houses_button;
        private System.Windows.Forms.Button apartments_button;
        private System.Windows.Forms.Button supplyset_button;
        private System.Windows.Forms.Button demand_set_button;
        private System.Windows.Forms.Button dealSet_button;
    }
}