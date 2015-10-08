namespace Lantern
{
    partial class LoadSurvivor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadSurvivor));
            this.nameInput = new System.Windows.Forms.TextBox();
            this.NameGroup = new System.Windows.Forms.GroupBox();
            this.confirmBut = new System.Windows.Forms.Button();
            this.cancelBut = new System.Windows.Forms.Button();
            this.NameGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(6, 19);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(144, 20);
            this.nameInput.TabIndex = 1;
            this.nameInput.Text = " ";
            // 
            // NameGroup
            // 
            this.NameGroup.Controls.Add(this.nameInput);
            this.NameGroup.Location = new System.Drawing.Point(12, 12);
            this.NameGroup.Name = "NameGroup";
            this.NameGroup.Size = new System.Drawing.Size(156, 48);
            this.NameGroup.TabIndex = 3;
            this.NameGroup.TabStop = false;
            this.NameGroup.Text = "Name (Case Sensitive)";
            // 
            // confirmBut
            // 
            this.confirmBut.Location = new System.Drawing.Point(12, 66);
            this.confirmBut.Name = "confirmBut";
            this.confirmBut.Size = new System.Drawing.Size(75, 23);
            this.confirmBut.TabIndex = 4;
            this.confirmBut.Text = "Load";
            this.confirmBut.UseVisualStyleBackColor = true;
            this.confirmBut.Click += new System.EventHandler(this.confirmBut_Click);
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(93, 66);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(75, 23);
            this.cancelBut.TabIndex = 5;
            this.cancelBut.Text = "Cancel";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // LoadSurvivor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 96);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.confirmBut);
            this.Controls.Add(this.NameGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadSurvivor";
            this.Text = "Load";
            this.NameGroup.ResumeLayout(false);
            this.NameGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.GroupBox NameGroup;
        private System.Windows.Forms.Button confirmBut;
        private System.Windows.Forms.Button cancelBut;
    }
}