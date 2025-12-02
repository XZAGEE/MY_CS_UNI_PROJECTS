using System;
using System.Collections;
using System.Windows.Forms;

namespace LAB_8_D_2
{
    public partial class Form1 : Form
    {
        public class MyBook : IComparable
        {
            public int bookNomer { get; set; }
            public string Avtor { get; set; }
            public string Nazva { get; set; }
            public string Vydavnyctvo { get; set; }
            public int RikVyhodu { get; set; }

            public MyBook(int bookNomer, string avtor, string nazva, string vydavnyctvo, int rikVyhodu)
            {
                this.bookNomer = bookNomer;
                this.Avtor = avtor;
                this.Nazva = nazva;
                this.Vydavnyctvo = vydavnyctvo;
                this.RikVyhodu = rikVyhodu;
            }

            public override string ToString()
            {
                return $"Книга №{bookNomer} Автор: {Avtor} Назва: {Nazva} Видавництво: {Vydavnyctvo} Рік: {RikVyhodu}";
            }

            int IComparable.CompareTo(object obj)
            {
                MyBook pobj = obj as MyBook;
                if (pobj != null)
                {
                    if (this.bookNomer == pobj.bookNomer) return 0;
                    if (this.bookNomer > pobj.bookNomer) return 1;
                    if (this.bookNomer < pobj.bookNomer) return -1;
                }
                throw new ArgumentException("Параметр повинен бути типу MyBook");
            }
        }

        public class MyBooks : ArrayList
        {
            public MyBook[] MyBooksArray { get; set; }

            public MyBooks(int kilkistKnyh)
            {
                MyBooksArray = new MyBook[kilkistKnyh];
            }
        }

        public class BookNameComparer : IComparer
        {
            int IComparer.Compare(object o1, object o2)
            {
                MyBook b1 = o1 as MyBook;
                MyBook b2 = o2 as MyBook;

                if (b1 != null && b2 != null)
                    return string.Compare(b1.Nazva, b2.Nazva);

                throw new ArgumentException("Параметри не є класу MyBook");
            }
        }

        public class BookAvtorComparer : IComparer
        {
            int IComparer.Compare(object o1, object o2)
            {
                MyBook b1 = o1 as MyBook;
                MyBook b2 = o2 as MyBook;

                if (b1 != null && b2 != null)
                    return string.Compare(b1.Avtor, b2.Avtor);

                throw new ArgumentException("Параметри не є класу MyBook");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ss = "Виведення засобами класу MyBooks несортованого масиву\n\n";

            MyBooks mbs1 = new MyBooks(5);
            mbs1.MyBooksArray[0] = new MyBook(7, "Еріх Марія Ремарк", "Три товариші", "Ранок", 1981);
            mbs1.MyBooksArray[1] = new MyBook(9, "Всеволод Нестайко", "У країні сонячних зайчиків", "Ранок", 1961);
            mbs1.MyBooksArray[2] = new MyBook(2, "С.И.Баскаков", "Радиотехнические цепи и сигналы", "М.: Высша школа", 2000);
            mbs1.MyBooksArray[3] = new MyBook(5, "Джеймс Кервуд", "Грізлі Казан", "Київ, Молодь", 1962);
            mbs1.MyBooksArray[4] = new MyBook(4, "Ю.П.Пармузин", "Осторожно - пума", "Москва. Мисль", 1978);

            foreach (MyBook b in mbs1.MyBooksArray)
            {
                if (b != null)
                    ss += b.ToString() + "\n";
            }

            ss += "\n";
            Array.Sort(mbs1.MyBooksArray);
            ss += "Виведення засобами класу MyBooks масиву, який посортовано по полю Номер книги\n\n";

            foreach (MyBook b in mbs1.MyBooksArray)
            {
                if (b != null)
                    ss += b.ToString() + "\n";
            }

            ss += "\n";
            Array.Sort(mbs1.MyBooksArray, new BookNameComparer());
            ss += "Виведення засобами класу MyBooks масиву, який посортовано по полю Назва книги\n\n";

            foreach (MyBook b in mbs1.MyBooksArray)
            {
                if (b != null)
                    ss += b.ToString() + "\n";
            }

            ss += "\n";
            Array.Sort(mbs1.MyBooksArray, new BookAvtorComparer());
            ss += "Виведення засобами класу MyBooks масиву, який посортовано по полю Автор книги\n\n";

            foreach (MyBook b in mbs1.MyBooksArray)
            {
                if (b != null)
                    ss += b.ToString() + "\n";
            }

            label1.Text = ss;
        }
    }
}
