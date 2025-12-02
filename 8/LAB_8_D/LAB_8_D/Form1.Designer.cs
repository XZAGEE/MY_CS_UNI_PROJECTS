namespace LAB_8_D
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
            this.labelFilterOptions = new System.Windows.Forms.Label();
            this.checkBoxCircle = new System.Windows.Forms.CheckBox();
            this.checkBoxRectangle = new System.Windows.Forms.CheckBox();
            this.checkBoxTriangle = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFilterOptions
            // 
            this.labelFilterOptions.AutoSize = true;
            this.labelFilterOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFilterOptions.Location = new System.Drawing.Point(47, 40);
            this.labelFilterOptions.Name = "labelFilterOptions";
            this.labelFilterOptions.Size = new System.Drawing.Size(111, 20);
            this.labelFilterOptions.TabIndex = 0;
            this.labelFilterOptions.Text = "FilterShapes";
            // 
            // checkBoxCircle
            // 
            this.checkBoxCircle.AutoSize = true;
            this.checkBoxCircle.Checked = true;
            this.checkBoxCircle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCircle.Location = new System.Drawing.Point(51, 81);
            this.checkBoxCircle.Name = "checkBoxCircle";
            this.checkBoxCircle.Size = new System.Drawing.Size(84, 17);
            this.checkBoxCircle.TabIndex = 1;
            this.checkBoxCircle.Text = "ShowCircles";
            this.checkBoxCircle.UseVisualStyleBackColor = true;
            // 
            // checkBoxRectangle
            // 
            this.checkBoxRectangle.AutoSize = true;
            this.checkBoxRectangle.Checked = true;
            this.checkBoxRectangle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRectangle.Location = new System.Drawing.Point(51, 106);
            this.checkBoxRectangle.Name = "checkBoxRectangle";
            this.checkBoxRectangle.Size = new System.Drawing.Size(102, 17);
            this.checkBoxRectangle.TabIndex = 2;
            this.checkBoxRectangle.Text = "ShowRectangle";
            this.checkBoxRectangle.UseVisualStyleBackColor = true;
            // 
            // checkBoxTriangle
            // 
            this.checkBoxTriangle.AutoSize = true;
            this.checkBoxTriangle.Checked = true;
            this.checkBoxTriangle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTriangle.Location = new System.Drawing.Point(51, 129);
            this.checkBoxTriangle.Name = "checkBoxTriangle";
            this.checkBoxTriangle.Size = new System.Drawing.Size(99, 17);
            this.checkBoxTriangle.TabIndex = 3;
            this.checkBoxTriangle.Text = "Show Triangles";
            this.checkBoxTriangle.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 220);
            this.label1.TabIndex = 5;
            this.label1.Text = "ShapeDetails";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxTriangle);
            this.Controls.Add(this.checkBoxRectangle);
            this.Controls.Add(this.checkBoxCircle);
            this.Controls.Add(this.labelFilterOptions);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFilterOptions;
        private System.Windows.Forms.CheckBox checkBoxCircle;
        private System.Windows.Forms.CheckBox checkBoxRectangle;
        private System.Windows.Forms.CheckBox checkBoxTriangle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

