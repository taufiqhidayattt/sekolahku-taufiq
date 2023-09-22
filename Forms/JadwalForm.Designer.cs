
namespace sekolahku_jude.Forms
{
    partial class JadwalForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.KelasGrid = new System.Windows.Forms.DataGridView();
            this.JadwalGrid = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KelasNameText = new System.Windows.Forms.TextBox();
            this.KelasIdText = new System.Windows.Forms.TextBox();
            this.HariCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KelasGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JadwalGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.KelasGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.JadwalGrid);
            this.splitContainer1.Panel2.Controls.Add(this.SaveButton);
            this.splitContainer1.Panel2.Controls.Add(this.NewButton);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(762, 360);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 6;
            // 
            // KelasGrid
            // 
            this.KelasGrid.AllowUserToAddRows = false;
            this.KelasGrid.AllowUserToDeleteRows = false;
            this.KelasGrid.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.KelasGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KelasGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KelasGrid.Location = new System.Drawing.Point(0, 0);
            this.KelasGrid.Name = "KelasGrid";
            this.KelasGrid.Size = new System.Drawing.Size(324, 360);
            this.KelasGrid.TabIndex = 1;
            // 
            // JadwalGrid
            // 
            this.JadwalGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JadwalGrid.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.JadwalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JadwalGrid.Location = new System.Drawing.Point(0, 121);
            this.JadwalGrid.Name = "JadwalGrid";
            this.JadwalGrid.Size = new System.Drawing.Size(434, 210);
            this.JadwalGrid.TabIndex = 8;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(359, 334);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewButton.Location = new System.Drawing.Point(0, 334);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 5;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.KelasNameText);
            this.panel1.Controls.Add(this.KelasIdText);
            this.panel1.Controls.Add(this.HariCombo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 117);
            this.panel1.TabIndex = 1;
            // 
            // KelasNameText
            // 
            this.KelasNameText.Location = new System.Drawing.Point(69, 42);
            this.KelasNameText.Name = "KelasNameText";
            this.KelasNameText.ReadOnly = true;
            this.KelasNameText.Size = new System.Drawing.Size(121, 20);
            this.KelasNameText.TabIndex = 5;
            // 
            // KelasIdText
            // 
            this.KelasIdText.Location = new System.Drawing.Point(69, 14);
            this.KelasIdText.Name = "KelasIdText";
            this.KelasIdText.ReadOnly = true;
            this.KelasIdText.Size = new System.Drawing.Size(47, 20);
            this.KelasIdText.TabIndex = 4;
            // 
            // HariCombo
            // 
            this.HariCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HariCombo.FormattingEnabled = true;
            this.HariCombo.Location = new System.Drawing.Point(69, 70);
            this.HariCombo.Name = "HariCombo";
            this.HariCombo.Size = new System.Drawing.Size(121, 21);
            this.HariCombo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hari";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kelas ID";
            // 
            // JadwalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(765, 365);
            this.Controls.Add(this.splitContainer1);
            this.Name = "JadwalForm";
            this.Text = "JadwalForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KelasGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JadwalGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView KelasGrid;
        private System.Windows.Forms.DataGridView JadwalGrid;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox KelasNameText;
        private System.Windows.Forms.TextBox KelasIdText;
        private System.Windows.Forms.ComboBox HariCombo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}