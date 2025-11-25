using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; 

namespace LAB_6
{
    public partial class Form1 : Form
    {
        int N = 1;
        int i = 0;
        int j = 0;
        int Change; 

        double[,] A = new double[6, 6];
        double[] B = new double[6];
        double[] X = new double[6];

        public Form1()
        {
            InitializeComponent();
        }
        private void Decomp(int N, ref int Change)
        {
            int i, j, k;
            double sum;
            Change = 1;

            double maxVal = Math.Abs(A[1, 1]);
            int maxRow = 1;
            for (i = 2; i <= N; i++)
            {
                if (Math.Abs(A[i, 1]) > maxVal)
                {
                    maxVal = Math.Abs(A[i, 1]);
                    maxRow = i;
                }
            }
            if (maxRow != 1)
            {
                Change = maxRow; 
                for (j = 1; j <= N; j++)
                {
                    double temp = A[1, j];
                    A[1, j] = A[maxRow, j];
                    A[maxRow, j] = temp;
                }
            }
            if (Math.Abs(A[1, 1]) < 1e-9)
            {
                MessageBox.Show("Matrix is singular (pivotal element = 0).");
                return;
            }
            for (j = 2; j <= N; j++)
            {
                A[1, j] = A[1, j] / A[1, 1];
            }

            for (i = 2; i <= N; i++)
            {
                for (k = i; k <= N; k++)
                {
                    sum = 0;
                    for (j = 1; j <= i - 1; j++)
                    {
                        sum += A[k, j] * A[j, i];
                    }
                    A[k, i] = A[k, i] - sum;
                }

                for (k = i + 1; k <= N; k++)
                {
                    sum = 0;
                    for (j = 1; j <= i - 1; j++)
                    {
                        sum += A[i, j] * A[j, k];
                    }

                    if (Math.Abs(A[i, i]) < 1e-9)
                    {
                        MessageBox.Show("Division by zero while decomp");
                        return;
                    }
                    A[i, k] = (A[i, k] - sum) / A[i, i];
                }
            }
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                {
                    C_Matrix_Dgv.Rows[i].Cells[j].Value = String.Format("{0:0.00000}", A[i + 1, j + 1]);
                }
        }
        private void Solve(int Change, int N)
        {
            int i, j;
            double sum;
            double[] Y = new double[N + 1];

            if (Change != 1)
            {
                double temp = B[1];
                B[1] = B[Change];
                B[Change] = temp;
            }

            Y[1] = B[1] / A[1, 1];

            for (i = 2; i <= N; i++)
            {
                sum = 0;
                for (j = 1; j <= i - 1; j++)
                {
                    sum += A[i, j] * Y[j];
                }
                Y[i] = (B[i] - sum) / A[i, i];
            }

            X[N] = Y[N];

            for (i = N - 1; i >= 1; i--)
            {
                sum = 0;
                for (j = i + 1; j <= N; j++)
                {
                    sum += A[i, j] * X[j];
                }
                X[i] = Y[i] - sum;
            }
        }
        private void SolveGauss(int n)
        {
            double[,] a = (double[,])A.Clone();
            double[] b = (double[])B.Clone();
            int i, j, k;
            double temp;

            for (i = 1; i < n; i++)
            {
                int maxRow = i;
                double maxVal = Math.Abs(a[i, i]);

                for (k = i + 1; k <= n; k++)
                {
                    if (Math.Abs(a[k, i]) > maxVal) { maxVal = Math.Abs(a[k, i]); maxRow = k; }
                }

                if (maxRow != i)
                {
                    for (j = i; j <= n; j++) { temp = a[i, j]; a[i, j] = a[maxRow, j]; a[maxRow, j] = temp; }
                    temp = b[i]; b[i] = b[maxRow]; b[maxRow] = temp;
                }

                if (Math.Abs(a[i, i]) < 1e-9) { MessageBox.Show("Gauss: System is singular."); return; }

                for (k = i + 1; k <= n; k++)
                {
                    double factor = a[k, i] / a[i, i];
                    for (j = i; j <= n; j++) a[k, j] -= factor * a[i, j];
                    b[k] -= factor * b[i];
                }
            }
            if (Math.Abs(a[n, n]) < 1e-9) { MessageBox.Show("Gauss: System is singular."); return; }
            for (i = n; i >= 1; i--)
            {
                double sum = 0;
                for (j = i + 1; j <= n; j++) sum += a[i, j] * X[j];
                X[i] = (b[i] - sum) / a[i, i];
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            X_Vector_Dgv.ReadOnly = true;
            A_Matrix_Dgv.AllowUserToAddRows = false;
            B_Vector_Dgv.AllowUserToAddRows = false;
            X_Vector_Dgv.AllowUserToAddRows = false;
            A_Matrix_Dgv.ColumnCount = 1;
            A_Matrix_Dgv.RowCount = 1;
            X_Vector_Dgv.ColumnCount = 1;
            X_Vector_Dgv.RowCount = 1;
            B_Vector_Dgv.ColumnCount = 1;
            B_Vector_Dgv.RowCount = 1;
            NUD_Rozmir.Value = 1;
            MethodChoice.Items.Clear();
            MethodChoice.Items.Add("LU Decomposition");
            MethodChoice.Items.Add("Gaussian Method");
            MethodChoice.SelectedIndex = 0;
            MethodChoice.SelectedIndexChanged -= MethodChoice_SelectedIndexChanged;
            MethodChoice.SelectedIndexChanged += MethodChoice_SelectedIndexChanged;
        }
        private void MethodChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MethodChoice.SelectedIndex == 1)
            { // Gauss
                C_Matrix_Dgv.Visible = false;
                Matrix_C_Label.Visible = false;
            }
            else
            {// LU
                C_Matrix_Dgv.Visible = true;
                Matrix_C_Label.Visible = true;
            }
        }
        private void NUD_Rozmir_ValueChanged(object sender, EventArgs e)
        {
            N = Convert.ToInt16(NUD_Rozmir.Value);

            A_Matrix_Dgv.RowCount = N;
            A_Matrix_Dgv.ColumnCount = N;
            X_Vector_Dgv.RowCount = N;
            B_Vector_Dgv.RowCount = N;
            C_Matrix_Dgv.RowCount = N;
            C_Matrix_Dgv.ColumnCount = N;
        }
        private double ParseDouble(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0.0;
            string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string normalizedValue = value.Replace(".", decimalSeparator).Replace(",", decimalSeparator);
            return Convert.ToDouble(normalizedValue);
        }
        private void B_Create_Grid_Click(object sender, EventArgs e)
        {
            bool exc_A = false;
            bool exc_B = false;

            for (i = 1; i <= N; i++)
                for (j = 1; j <= N; j++)
                {
                    try
                    {
                        string cellValue = A_Matrix_Dgv[j - 1, i - 1].Value?.ToString();
                        A[i, j] = ParseDouble(cellValue);

                        A_Matrix_Dgv[j - 1, i - 1].Style.ForeColor = Color.Black;
                    }
                    catch
                    {
                        A_Matrix_Dgv[j - 1, i - 1].Style.ForeColor = Color.Red;
                        exc_A = true;
                    }
                }
            for (j = 0; j < N; j++)
            {
                try
                {
                    string cellValue = B_Vector_Dgv[0, j].Value?.ToString();
                    B[j + 1] = ParseDouble(cellValue);

                    B_Vector_Dgv[0, j].Style.ForeColor = Color.Black;
                }
                catch
                {
                    B_Vector_Dgv[0, j].Style.ForeColor = Color.Red;
                    exc_B = true;
                }
            }

            if (exc_A || exc_B)
            {
                MessageBox.Show("Помилка введення даних! Перевірте червоні клітинки. Переконайтеся, що ви вводите числа правильно.");
                return;
            }
    
            Decomp(N, ref Change);
            Solve(Change, N);

            for (i = 0; i < N; i++)
            {
                X_Vector_Dgv[0, i].Value = String.Format("{0:0.00000}", X[i + 1]);
            }
            MessageBox.Show("Розв'язок знайдено");
        }
        private void B_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void A_Matrix_Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                A_Matrix_Dgv.CurrentCell.Style.ForeColor = Color.Black;
        }

        private void B_Vector_Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                B_Vector_Dgv.CurrentCell.Style.ForeColor = Color.Black;
        }
        private void B_Clear_Click(object sender, EventArgs e)
        {
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    A_Matrix_Dgv[j, i].Value = "";
                    C_Matrix_Dgv[j, i].Value = "";
                }
                B_Vector_Dgv[0, i].Value = "";
                X_Vector_Dgv[0, i].Value = "";
            }
        }
    }
}