using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Subscribe to combobox selection change to update Kmax visibility immediately
            this.comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // Ensure initial visibility matches current selection
            UpdateKmaxVisibility();
        }

        double f(double x, ref int k1)
        {
            switch (k1)
            {
                case 0:
                    // Перше рівняння: x*x - 4 = 0 
                    return x * x - 4;
                case 1:
                    // Друге рівняння: 3*x - 4*log(x) - 5 = 0 
                    return 3 * x - 4 * Math.Log(x) - 5;
                case 2:
                    // Third equation: sin(x) - 0.5*x = 0
                    return Math.Sin(x) - 0.5 * x;
                default:
                    return 0;
            }
        }

        // перша похідна (обчислення скінченною різницею)
        double fp(double x, double d, ref int k1)
        {
            // Формула: (f(x+d) - f(x)) / d
            return (f(x + d, ref k1) - f(x, ref k1)) / d;
        }

        // друга похідна (обчислення скінченною різницею)
        double f2p(double x, double d, ref int k1)
        {
            // Формула: (f(x + d) + f(x - d) - 2*f(x)) / (d*d)
            return (f(x + d, ref k1) + f(x - d, ref k1) - 2 * f(x, ref k1)) / (d * d);
        }

        // ==========================================================
        // ЧИСЕЛЬНІ МЕТОДИ
        // ==========================================================

        // Метод ділення навпіл (МДН) - now void, returns root via out parameter
        void MDP(double a, double b, double Eps, ref int k1, ref int L, out double root)
        {
            double c = 0, Fc;
            L = 0; // Лічильник кількості поділів
            root = 0.0;

            while (b - a > Eps)
            {
                c = 0.5 * (b - a) + a;
                L++;
                Fc = f(c, ref k1);

                if (Math.Abs(Fc) < Eps) // Перевірка, чи c є поблизу кореня
                {
                    root = c;
                    return;
                }

                if (f(a, ref k1) * Fc > 0)
                    a = c;
                else
                    b = c;
            }
            root = c;
            return;
        }

        // Метод Ньютона (МН) - now void, returns root via out parameter
        void MN(double a, double b, double Eps, ref int k1, int Kmax, ref int L, out double root)
        {
            double x, Dx, D;
            int i;
            Dx = 0.0;
            D = Math.Max(Eps / 100.0, 1e-12); // avoid too-small finite-diff step
            // Use midpoint as a more robust initial guess
            x = 0.5 * (a + b);

            // Optional: if one endpoint value is smaller in abs, prefer it
            double fa = f(a, ref k1), fb = f(b, ref k1);
            if (Math.Abs(fa) < Math.Abs(fb)) x = a;
            else if (Math.Abs(fb) < Math.Abs(fa)) x = b;

            // Перевірка гарантії збіжності
            if (f(x, ref k1) * f2p(x, D, ref k1) < 0)
            {
                MessageBox.Show("Для цього рівняння збіжність ітерацій не гарантована");
            }

            root = -1000.0;
            for (i = 1; i <= Kmax; i++)
            {
                double denom = fp(x, D, ref k1);
                if (Math.Abs(denom) < 1e-15)
                {
                    MessageBox.Show("Похідна близька до нуля (чисельна помилка) — змініть інтервал або збільште Kmax");
                    L = i;
                    root = -1000.0;
                    return;
                }

                Dx = f(x, ref k1) / denom;
                x = x - Dx;

                if (Math.Abs(Dx) < Eps) // Перевірка умови закінчення
                {
                    L = i;
                    root = x;
                    return;
                }
            }

            // Якщо цикл закінчився без знаходження кореня
            MessageBox.Show("За задану кількість ітерацій кореня не знайдено");
            root = -1000.0; // Ознака нестандартної ситуації
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Clear input and result fields
            textBox1.Clear(); // a
            textBox2.Clear(); // b
            textBox3.Clear(); // Eps
            textBox4.Clear(); // Kmax
            textBox5.Clear(); // x*
            textBox6.Clear(); // count

            // Make visibility follow combobox selection
            UpdateKmaxVisibility();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int L = 0, k = -1, Kmax = 0, m = -1;
            double a = 0, b = 0, Eps = 0, D;

            // Choose numeric method
            switch (comboBox1.SelectedIndex)
            {
                case 0: m = 0; break; // Bisection (MDP)
                case 1: m = 1; break; // Newton (MN)
                default:
                    MessageBox.Show("Оберіть метод!");
                    comboBox1.Focus();
                    return;
            }

            // Choose equation
            switch (comboBox2.SelectedIndex)
            {
                case 0: k = 0; break;
                case 1: k = 1; break;
                case 2: k = 2; break; // sin(x) - 0.5*x = 0
                default:
                    MessageBox.Show("Оберіть рівняння!");
                    comboBox2.Focus();
                    return;
            }

            // Read a
            if (string.IsNullOrWhiteSpace(textBox1.Text) || !double.TryParse(textBox1.Text, out a))
            {
                MessageBox.Show("Введіть число в поле поруч із 'a=' (textBox1)");
                textBox1.Focus();
                return;
            }

            // Read b
            if (string.IsNullOrWhiteSpace(textBox2.Text) || !double.TryParse(textBox2.Text, out b))
            {
                MessageBox.Show("Введіть число в поле поруч із 'b=' (textBox2)");
                textBox2.Focus();
                return;
            }

            if (a > b)
            {
                D = a; a = b; b = D;
                textBox1.Text = Convert.ToString(a);
                textBox2.Text = Convert.ToString(b);
            }

            // Read Eps
            if (string.IsNullOrWhiteSpace(textBox3.Text) || !double.TryParse(textBox3.Text, out Eps))
            {
                MessageBox.Show("Введіть число в поле поруч із 'Eps=' (textBox3)");
                textBox3.Focus();
                return;
            }
            if ((Eps > 1e-1) || (Eps <= 0))
            {
                Eps = 1e-4;
            }
            textBox3.Text = Convert.ToString(Eps);

            // If using Bisection, check sign change
            if (m == 0)
            {
                if ((f(a, ref k)) * (f(b, ref k)) > 0)
                {
                    MessageBox.Show("Введіть правильний інтервал [a, b]!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                    return;
                }
            }

            // Check endpoints near root
            if (Math.Abs(f(a, ref k)) < Eps)
            {
                textBox5.Text = Convert.ToString(a); // result x*
                textBox6.Text = Convert.ToString(L);
                return;
            }
            if (Math.Abs(f(b, ref k)) < Eps)
            {
                textBox5.Text = Convert.ToString(b);
                textBox6.Text = Convert.ToString(L);
                return;
            }

            // Execute selected method
            switch (m)
            {
                case 0: // Bisection
                    {
                        double root;
                        MDP(a, b, Eps, ref k, ref L, out root);
                        textBox5.Text = Convert.ToString(root);
                        textBox6.Text = Convert.ToString(L);
                        label10.Text = "К-ть поділів =";
                    }
                    break;

                case 1: // Newton
                    {
                        if (string.IsNullOrWhiteSpace(textBox4.Text) || !int.TryParse(textBox4.Text, out Kmax) || Kmax <= 0)
                        {
                            MessageBox.Show("Введіть додатній цілий Kmax в поле поруч із 'kmax=' (textBox4)");
                            textBox4.Focus();
                            return;
                        }

                        double root;
                        MN(a, b, Eps, ref k, Kmax, ref L, out root);
                        textBox5.Text = Convert.ToString(root);
                        textBox6.Text = Convert.ToString(L);
                        label10.Text = "К-ть ітерац.=";
                    }
                    break;
            }

            // after parsing a and b
            double fa = f(a, ref k);
            double fb = f(b, ref k);
            // quick info for debugging / user guidance
            if (m == 0) // bisection requires sign change
            {
                if (fa * fb > 0)
                {
                    MessageBox.Show($"f(a) = {fa:G5}, f(b) = {fb:G5}\nІнтервал не містить корінь (f(a)*f(b) > 0). Введіть інший інтервал.");
                    textBox1.Focus();
                    return;
                }
            }
            else // Newton: show f values to help choose initial interval
            {
                if (Math.Abs(fa) < Math.Abs(fb))
                    MessageBox.Show($"Using initial guess near a. f(a)={fa:G5}, f(b)={fb:G5}");
                else
                    MessageBox.Show($"Using initial guess near b. f(a)={fa:G5}, f(b)={fb:G5}");
            }
        }

        // New: update Kmax visibility helper and event handler
        private void UpdateKmaxVisibility()
        {
            // Newton is comboBox1 index 1 per Designer; show Kmax only for Newton
            bool showKmax = (comboBox1.SelectedIndex == 1);
            label7.Visible = showKmax;
            textBox4.Visible = showKmax;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateKmaxVisibility();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
