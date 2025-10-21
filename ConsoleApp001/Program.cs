using System;

namespace ConsoleApplication1
{
    class Program
    {
        const double d = 1e-5;
        public static double f(double x)
        {
            return x * x - 4;
        }
        public static double fp(double x)
        {
            return (f(x + d) - f(x)) / d;
        }
        public static double f2p(double x)
        {
            return (fp(x + d) - fp(x)) / d;
        }
        public static double MethodOfHalfDivision(double a, double b, double Eps, out int IterationCount)
        {
            IterationCount = 0; 
            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("Помилка: На кінцях інтервалу функція має однаковий знак.");
                return double.NaN;
            }
            while (Math.Abs(b - a) > Eps)
            {
                double c = (a + b)* 0.5;
                IterationCount++;
                if (f(a) * f(c) < 0)
                    b = c;
                else
                    a = c;
            }
            return (a + b) / 2;
        }
        public static double NewtonMethod(double a, double b, double Eps, int Kmax)
        {
            double x = b;
            if (f(x) * f2p(x) < 0)
            {
                x = a;
            }
            for (int i = 0; i < Kmax; i++)
            {
                double Dx = f(x) / fp(x);
                x = x - Dx;
                if (Math.Abs(Dx) < Eps)
                {
                    return x;
                }
            }
            Console.WriteLine("Помилка (Метод Ньютона): За задану кількість ітерацій корінь не знайдено.");
            return double.NaN;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Введіть вхідні дані ---");
                Console.Write("Початок інтервалу (a): ");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Кінець інтервалу (b): ");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Точність (Eps): ");
                double Eps = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("\n--- Оберіть метод ---");
                Console.WriteLine("1: Метод ділення навпіл");
                Console.WriteLine("2: Метод Ньютона");
                Console.Write("Ваш вибір: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                double x_root = double.NaN;

                if (choice == 1)
                { 
                    int iterationCount;
                    x_root = MethodOfHalfDivision(a, b, Eps, out iterationCount);

                    if (!double.IsNaN(x_root))
                    {
                        Console.WriteLine($"\nРезультат: знайдений корінь x ="+"{0}", x_root);
                        Console.WriteLine($"Кількість ітерацій: {iterationCount}");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Введіть макс. кількість ітерацій Kmax: ");
                    int Kmax = Convert.ToInt32(Console.ReadLine());
                    x_root = NewtonMethod(a, b, Eps, Kmax);
                    if (!double.IsNaN(x_root))
                    {
                        Console.WriteLine($"\nРезультат: знайдений корінь x = {x_root}");
                    }
                }
                else
                {
                    Console.WriteLine("Неправильний вибір.");
                }
            }
        }
    }
}