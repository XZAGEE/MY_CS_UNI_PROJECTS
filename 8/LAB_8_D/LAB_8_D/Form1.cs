using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAB_8_D
{
    // Make the designer partial Form1 the first class in this file so Visual Studio Designer can open it
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Shape Details:");
            sb.AppendLine("--------------------------");

            ShapeList drawingCanvas = new ShapeList(6);
            drawingCanvas.AddShape(new Circle(new Point { X = 50, Y = 50 }, 25));
            drawingCanvas.AddShape(new Rectangle(new Point { X = 100, Y = 50 }, 40, 60));
            drawingCanvas.AddShape(new Circle(new Point { X = 200, Y = 150 }, 70));
            drawingCanvas.AddShape(new Triangle(new Point { X = 150, Y = 120 }, new Point { X = 170, Y = 160 }, new Point { X = 130, Y = 160 }));

            sb.AppendLine("\n--- Output using foreach loop (IEnumerable) ---");
            foreach (IShape shape in drawingCanvas)
            {
                if ((shape is Circle && checkBoxCircle.Checked) ||
                    (shape is Rectangle && checkBoxRectangle.Checked) ||
                    (shape is Triangle && checkBoxTriangle.Checked))
                {
                    sb.AppendLine(shape.GetDetails());
                }
            }

            sb.AppendLine("\n--- Output using IEnumerator manually ---");
            IEnumerator enumerator = drawingCanvas.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IShape currentShape = enumerator.Current as IShape;
                if (currentShape != null)
                {
                    if ((currentShape is Circle && checkBoxCircle.Checked) ||
                        (currentShape is Rectangle && checkBoxRectangle.Checked) ||
                        (currentShape is Triangle && checkBoxTriangle.Checked))
                    {
                        sb.AppendLine(currentShape.GetDetails());
                    }
                }
            }

            label1.Text = sb.ToString();
        }

    }
}

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public interface IShape
    {
        string Name { get; }
        Point Position { get; set; }
        void Draw();
        string GetDetails();
    }

    public class Circle : IShape
    {
        public string Name => "Circle";
        public Point Position { get; set; }
        public int Radius { get; set; }

        public Circle(Point position, int radius)
        {
            this.Position = position;
            this.Radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a {Name} at {Position}, Radius: {Radius}");
        }

        public string GetDetails()
        {
            return $"{Name} at {Position}, Radius: {Radius}";
        }

        public override string ToString()
        {
            return GetDetails();
        }
    }

    public class Rectangle : IShape
    {
        public string Name => "Rectangle";
        public Point Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(Point position, int width, int height)
        {
            this.Position = position;
            this.Width = width;
            this.Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a {Name} at {Position}, Size: {Width}x{Height}");
        }

        public string GetDetails()
        {
            return $"{Name} at {Position}, Size: {Width}x{Height}";
        }

        public override string ToString()
        {
            return GetDetails();
        }
    }

    public class Triangle : IShape
    {
        public string Name => "Triangle";
        public Point Position { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
            Position = a;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a {Name} at vertices: {A}, {B}, {C}");
        }

        public string GetDetails()
        {
            return $"{Name} with vertices {A}, {B}, {C}";
        }

        public override string ToString()
        {
            return GetDetails();
        }
    }

    public class ShapeList : IEnumerable
    {
        private IShape[] shapes;
        private int currentCount = 0;

        public ShapeList(int capacity)
        {
            shapes = new IShape[capacity];
        }

        public void AddShape(IShape shape)
        {
            if (currentCount < shapes.Length)
            {
                shapes[currentCount] = shape;
                currentCount++;
            }
            else
            {
                MessageBox.Show("Shape collection is full!");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ShapeEnumerator(shapes, currentCount);
        }

        private class ShapeEnumerator : IEnumerator
        {
            private IShape[] shapes;
            private int currentCount;
            private int position = -1;

            public ShapeEnumerator(IShape[] shapes, int count)
            {
                this.shapes = shapes;
                this.currentCount = count;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return shapes[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException("Enumerator is before or after the collection.");
                    }
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < currentCount);
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }