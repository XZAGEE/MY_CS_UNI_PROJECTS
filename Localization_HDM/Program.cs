using System;
public class RootFinder
{
    public static double f(double x)
    {
        return (Math.Pow(x, 3) / 9.0) - 2.0;
    }
    public static Tuple<double, double> FindInterval(double X0, double step, int maxIterations = 10000)
    {
        double x1 = X0;
        double y1 = f(x1);

        for (int i = 0; i < maxIterations; i++)
        {
            double x2 = x1 + step;
            double y2 = f(x2);
            if (y1 * y2 < 0)
            {
                return Tuple.Create(x1, x2);
            }
            x1 = x2;
            y1 = y2;
        }
        return null;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Our function is f(x) = x^3/9 - 2");

        double roughStep = 1.0;
        var roughInterval = FindInterval(0.0, roughStep);

        if (roughInterval != null)
        {
            Console.WriteLine($"\nFound a rough interval with step {roughStep}: [{roughInterval.Item1}, {roughInterval.Item2}]");
            double Step = 0.0001;
            double fineSearchStart = roughInterval.Item1;
            var fineInterval = FindInterval(fineSearchStart, Step);

            if (fineInterval != null)
            {
                Console.WriteLine($"Found an interval with step {Step}: [{fineInterval.Item1:F4}, {fineInterval.Item2:F4}]");
                Console.WriteLine($"So, the root is x ≈ {fineInterval.Item1:F4}");
            }
            else
            {
                Console.WriteLine("Could not refine the interval.");
            }
        }
        else
        {
            Console.WriteLine("Could not find a root interval.");
        }
    }
}