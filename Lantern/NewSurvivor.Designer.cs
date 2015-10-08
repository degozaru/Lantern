namespace Lantern
{
    partial class NewSurvivor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSurvivor));
            this.NameGroup = new System.Windows.Forms.GroupBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.GenderGroup = new System.Windows.Forms.GroupBox();
            this.isFemale = new System.Windows.Forms.RadioButton();
            this.isMale = new System.Windows.Forms.RadioButton();
            this.confirmBut = new System.Windows.Forms.Button();
            this.cancelBut = new System.Windows.Forms.Button();
            this.NameGroup.SuspendLayout();
            this.GenderGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameGroup
            // 
            this.NameGroup.Controls.Add(this.nameInput);
            this.NameGroup.Location = new System.Drawing.Point(0, 0);
            this.NameGroup.Name = "NameGroup";
            this.NameGroup.Size = new System.Drawing.Size(159, 55);
            this.NameGroup.TabIndex = 0;
            this.NameGroup.TabStop = false;
            this.NameGroup.Text = "Name";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(25, 19);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(100, 20);
            this.nameInput.TabIndex = 0;
            // 
            // GenderGroup
            // 
            this.GenderGroup.Controls.Add(this.isFemale);
            this.GenderGroup.Controls.Add(this.isMale);
            this.GenderGroup.Location = new System.Drawing.Point(165, 0);
            this.GenderGroup.Name = "GenderGroup";
            this.GenderGroup.Size = new System.Drawing.Size(192, 55);
            this.GenderGroup.TabIndex = 0;
            this.GenderGroup.TabStop = false;
            this.GenderGroup.Text = "Gender";
            // 
            // isFemale
            // 
            this.isFemale.AutoSize = true;
            this.isFemale.Location = new System.Drawing.Point(97, 22);
            this.isFemale.Name = "isFemale";
            this.isFemale.Size = new System.Drawing.Size(59, 17);
            this.isFemale.TabIndex = 1;
            this.isFemale.TabStop = true;
            this.isFemale.Text = "Female";
            this.isFemale.UseVisualStyleBackColor = true;
            // 
            // isMale
            // 
            this.isMale.AutoSize = true;
            this.isMale.Location = new System.Drawing.Point(6, 22);
            this.isMale.Name = "isMale";
            this.isMale.Size = new System.Drawing.Size(48, 17);
            this.isMale.TabIndex = 0;
            this.isMale.TabStop = true;
            this.isMale.Text = "Male";
            this.isMale.UseVisualStyleBackColor = true;
            // 
            // confirmBut
            // 
            this.confirmBut.Location = new System.Drawing.Point(50, 62);
            this.confirmBut.Name = "confirmBut";
            this.confirmBut.Size = new System.Drawing.Size(75, 23);
            this.confirmBut.TabIndex = 1;
            this.confirmBut.Text = "Confirm";
            this.confirmBut.UseVisualStyleBackColor = true;
            this.confirmBut.Click += new System.EventHandler(this.confirmBut_Click);
            // 
            // cancelBut
            // 
            this.cancelBut.Location = new System.Drawing.Point(220, 61);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(75, 23);
            this.cancelBut.TabIndex = 2;
            this.cancelBut.Text = "Cancel";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelBut_Click);
            // 
            // NewSurvivor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 97);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.confirmBut);
            this.Controls.Add(this.GenderGroup);
            this.Controls.Add(this.NameGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewSurvivor";
            this.Text = "NewSurvivor";
            this.NameGroup.ResumeLayout(false);
            this.NameGroup.PerformLayout();
            this.GenderGroup.ResumeLayout(false);
            this.GenderGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox NameGroup;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.GroupBox GenderGroup;
        private System.Windows.Forms.RadioButton isFemale;
        private System.Windows.Forms.RadioButton isMale;
        private System.Windows.Forms.Button confirmBut;
        private System.Windows.Forms.Button cancelBut;
    }
}