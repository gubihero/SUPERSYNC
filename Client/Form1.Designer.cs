namespace SuperSimpleSync
{
    partial class Form1
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
            this.cDirMap = new System.Windows.Forms.TreeView();
            this.cDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cSync = new System.Windows.Forms.Button();
            this.cDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cDirMap
            // 
            this.cDirMap.Location = new System.Drawing.Point(26, 182);
            this.cDirMap.Name = "cDirMap";
            this.cDirMap.Size = new System.Drawing.Size(491, 410);
            this.cDirMap.TabIndex = 0;
            this.cDirMap.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // cDir
            // 
            this.cDir.Location = new System.Drawing.Point(142, 36);
            this.cDir.Name = "cDir";
            this.cDir.Size = new System.Drawing.Size(198, 22);
            this.cDir.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Directory";
            // 
            // cSync
            // 
            this.cSync.Location = new System.Drawing.Point(396, 36);
            this.cSync.Name = "cSync";
            this.cSync.Size = new System.Drawing.Size(75, 23);
            this.cSync.TabIndex = 5;
            this.cSync.Text = "Sync";
            this.cSync.UseVisualStyleBackColor = true;
            this.cSync.Click += new System.EventHandler(this.cSync_Click);
            // 
            // cDel
            // 
            this.cDel.Location = new System.Drawing.Point(546, 182);
            this.cDel.Name = "cDel";
            this.cDel.Size = new System.Drawing.Size(75, 23);
            this.cDel.TabIndex = 6;
            this.cDel.Text = "Delete";
            this.cDel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 559);
            this.Controls.Add(this.cDel);
            this.Controls.Add(this.cSync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cDir);
            this.Controls.Add(this.cDirMap);
            this.Name = "Form1";
            this.Text = "SUPER SYNC!!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView cDirMap;
        private System.Windows.Forms.TextBox cDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cSync;
        private System.Windows.Forms.Button cDel;
    }
}