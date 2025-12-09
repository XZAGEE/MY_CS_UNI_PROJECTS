namespace LAB_11_D
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
            this.btnNext = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.chkSafety = new System.Windows.Forms.CheckBox();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(320, 40);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 30);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next Stage";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(30, 30);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(78, 13);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = "Progress: Idle";
            // 
            // chkSafety
            // 
            this.chkSafety.AutoSize = true;
            this.chkSafety.Location = new System.Drawing.Point(33, 60);
            this.chkSafety.Name = "chkSafety";
            this.chkSafety.Size = new System.Drawing.Size(140, 17);
            this.chkSafety.TabIndex = 2;
            this.chkSafety.Text = "Safety Tests Passed";
            this.chkSafety.UseVisualStyleBackColor = true;
            this.chkSafety.CheckedChanged += new System.EventHandler(this.chkSafety_CheckedChanged);
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = false;
            this.lblLastUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLastUpdate.Location = new System.Drawing.Point(30, 100);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(410, 60);
            this.lblLastUpdate.TabIndex = 3;
            this.lblLastUpdate.Text = "Last update: none";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 200);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.chkSafety);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnNext);
            this.Name = "Form1";
            this.Text = "Medication Development Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox chkSafety;
        private System.Windows.Forms.Label lblLastUpdate;
    }
}

