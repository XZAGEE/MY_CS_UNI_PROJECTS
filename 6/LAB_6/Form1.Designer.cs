namespace LAB_6
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
            this.X_Vector_Dgv = new System.Windows.Forms.DataGridView();
            this.A_Matrix_Dgv = new System.Windows.Forms.DataGridView();
            this.C_Matrix_Dgv = new System.Windows.Forms.DataGridView();
            this.B_Vector_Dgv = new System.Windows.Forms.DataGridView();
            this.B_Create_Grid = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Matrix_C_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NUD_Rozmir = new System.Windows.Forms.NumericUpDown();
            this.B_Exit = new System.Windows.Forms.Button();
            this.B_Clear = new System.Windows.Forms.Button();
            this.MethodChoice = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.X_Vector_Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_Matrix_Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_Matrix_Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Vector_Dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Rozmir)).BeginInit();
            this.SuspendLayout();
            // 
            // X_Vector_Dgv
            // 
            this.X_Vector_Dgv.ColumnHeadersVisible = false;
            this.X_Vector_Dgv.Location = new System.Drawing.Point(635, 112);
            this.X_Vector_Dgv.Name = "X_Vector_Dgv";
            this.X_Vector_Dgv.ReadOnly = true;
            this.X_Vector_Dgv.Size = new System.Drawing.Size(167, 150);
            this.X_Vector_Dgv.TabIndex = 11;
            // 
            // A_Matrix_Dgv
            // 
            this.A_Matrix_Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.A_Matrix_Dgv.ColumnHeadersVisible = false;
            this.A_Matrix_Dgv.Location = new System.Drawing.Point(67, 112);
            this.A_Matrix_Dgv.Name = "A_Matrix_Dgv";
            this.A_Matrix_Dgv.Size = new System.Drawing.Size(240, 150);
            this.A_Matrix_Dgv.TabIndex = 10;
            this.A_Matrix_Dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.A_Matrix_Dgv_CellClick);
            // 
            // C_Matrix_Dgv
            // 
            this.C_Matrix_Dgv.ColumnHeadersVisible = false;
            this.C_Matrix_Dgv.Location = new System.Drawing.Point(67, 288);
            this.C_Matrix_Dgv.Name = "C_Matrix_Dgv";
            this.C_Matrix_Dgv.Size = new System.Drawing.Size(363, 150);
            this.C_Matrix_Dgv.TabIndex = 9;
            // 
            // B_Vector_Dgv
            // 
            this.B_Vector_Dgv.ColumnHeadersVisible = false;
            this.B_Vector_Dgv.Location = new System.Drawing.Point(384, 112);
            this.B_Vector_Dgv.Name = "B_Vector_Dgv";
            this.B_Vector_Dgv.Size = new System.Drawing.Size(175, 150);
            this.B_Vector_Dgv.TabIndex = 8;
            this.B_Vector_Dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.B_Vector_Dgv_CellClick);
            // 
            // B_Create_Grid
            // 
            this.B_Create_Grid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Create_Grid.Location = new System.Drawing.Point(484, 313);
            this.B_Create_Grid.Name = "B_Create_Grid";
            this.B_Create_Grid.Size = new System.Drawing.Size(102, 46);
            this.B_Create_Grid.TabIndex = 12;
            this.B_Create_Grid.Text = "Solve";
            this.B_Create_Grid.UseVisualStyleBackColor = true;
            this.B_Create_Grid.Click += new System.EventHandler(this.B_Create_Grid_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(63, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Matrix A ";
            // 
            // Matrix_C_Label
            // 
            this.Matrix_C_Label.AutoSize = true;
            this.Matrix_C_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Matrix_C_Label.Location = new System.Drawing.Point(63, 265);
            this.Matrix_C_Label.Name = "Matrix_C_Label";
            this.Matrix_C_Label.Size = new System.Drawing.Size(215, 20);
            this.Matrix_C_Label.TabIndex = 16;
            this.Matrix_C_Label.Text = "MAtrix C of LU decomp coefs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(380, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(461, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Choose matrix size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(631, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = " Vector X";
            // 
            // NUD_Rozmir
            // 
            this.NUD_Rozmir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NUD_Rozmir.Location = new System.Drawing.Point(620, 36);
            this.NUD_Rozmir.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_Rozmir.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Rozmir.Name = "NUD_Rozmir";
            this.NUD_Rozmir.Size = new System.Drawing.Size(120, 26);
            this.NUD_Rozmir.TabIndex = 21;
            this.NUD_Rozmir.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Rozmir.ValueChanged += new System.EventHandler(this.NUD_Rozmir_ValueChanged);
            // 
            // B_Exit
            // 
            this.B_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Exit.Location = new System.Drawing.Point(543, 365);
            this.B_Exit.Name = "B_Exit";
            this.B_Exit.Size = new System.Drawing.Size(102, 46);
            this.B_Exit.TabIndex = 24;
            this.B_Exit.Text = "Exit";
            this.B_Exit.UseVisualStyleBackColor = true;
            this.B_Exit.Click += new System.EventHandler(this.B_Exit_Click);
            // 
            // B_Clear
            // 
            this.B_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_Clear.Location = new System.Drawing.Point(604, 313);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(102, 46);
            this.B_Clear.TabIndex = 25;
            this.B_Clear.Text = "Clear";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // MethodChoice
            // 
            this.MethodChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodChoice.FormattingEnabled = true;
            this.MethodChoice.Location = new System.Drawing.Point(309, 40);
            this.MethodChoice.Name = "MethodChoice";
            this.MethodChoice.Size = new System.Drawing.Size(121, 21);
            this.MethodChoice.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(125, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Choose the method ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(387, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Vector B";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MethodChoice);
            this.Controls.Add(this.B_Clear);
            this.Controls.Add(this.B_Exit);
            this.Controls.Add(this.NUD_Rozmir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Matrix_C_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Create_Grid);
            this.Controls.Add(this.B_Vector_Dgv);
            this.Controls.Add(this.C_Matrix_Dgv);
            this.Controls.Add(this.A_Matrix_Dgv);
            this.Controls.Add(this.X_Vector_Dgv);
            this.Name = "Form1";
            this.Text = "LU decoposition";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.X_Vector_Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.A_Matrix_Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.C_Matrix_Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_Vector_Dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Rozmir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView X_Vector_Dgv;
        private System.Windows.Forms.DataGridView A_Matrix_Dgv;
        private System.Windows.Forms.DataGridView C_Matrix_Dgv;
        private System.Windows.Forms.DataGridView B_Vector_Dgv;
        private System.Windows.Forms.Button B_Create_Grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Matrix_C_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NUD_Rozmir;
        private System.Windows.Forms.Button B_Exit;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.ComboBox MethodChoice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

