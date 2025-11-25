using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace LAB_7_D_
{ 
    public partial class Form1 : Form
    {
        List<Place> gameLocations = new List<Place>();

        public Form1()
        {
            InitializeComponent();
            SetupGameData();
        }
        private void SetupGameData()
        {
            gameLocations.Add(new City("Львів", "Україна", 720000));
            gameLocations.Add(new Mountain("Еверест", "Непал", 8848));
            gameLocations.Add(new City("Нью-Йорк", "США", 8400000));
            gameLocations.Add(new Mountain("К2", "Пакистан", 8611));
            gameLocations.Add(new Lake("Синевир", "Україна", 0.07));
            gameLocations.Add(new Lake("Байкал", "Росія", 31722));
            gameLocations.Add(new Lake("Світязь", "Україна", 26.2));
            gameLocations.Add(new City("Токіо", "Японія", 13960000));
        }
        public abstract class Place
        {
            public string Name { get; protected set; }
            public string Country { get; protected set; }

            public Place(string name, string country)
            {
                Name = name;
                Country = country;
            }
            public virtual string GetDescription()
            {
                return $"{Name} ({Country})";
            }
        }
        public class City : Place
        {
            public int Population;

            public City(string name, string country, int population)
                : base(name, country)
            {
                Population = population;
            }
            public override string GetDescription()
            {
                return $"МІСТО: {Name}, {Country}. Населення: {Population} ос.";
            }
        }
        public class Mountain : Place
        {
            public double Height;
            public Mountain(string name, string country, double height)
                : base(name, country)
            {
                Height = height;
            }
            public override string GetDescription()
            {
                return $" ГОРА: {Name}, {Country}. Висота: {Height} м.";
            }
        }
        public class Lake : Place
        {
            public double Area;
            public Lake(string name, string country, double area)
                : base(name, country)
            {
                Area = area;
            }
            public override string GetDescription()
            {
                return $" ОЗЕРО: {Name}, {Country}. Площа: {Area} кв.км.";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Демонстрація ООП: Geo Filter";
            if (!rbCity.Checked && !rbMountain.Checked && !rbLake.Checked)
            {
                rbCity.Checked = true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string output = "";
            IEnumerable<Place> filteredList = null;
            if (rbCity.Checked)
            {
                output += "=== Фільтр: МІСТА ===\n\n";
                filteredList = gameLocations.OfType<City>();
            }
            else if (rbMountain.Checked)
            {
                output += "=== Фільтр: ГОРИ ===\n\n";
                filteredList = gameLocations.OfType<Mountain>();
            }
            else if (rbLake.Checked)
            {
                output += "=== Фільтр: ОЗЕРА ===\n\n";
                filteredList = gameLocations.OfType<Lake>();
            }
            else
            {
                output += "=== Усі об'єкти ===\n\n";
                filteredList = gameLocations;
            }
            if (filteredList != null)
            {
                foreach (Place place in filteredList)
                {
                    output += place.GetDescription() + "\n\n";
                }
            }
            else
            {
                output += "Нічого не знайдено.";
            }

            label1.Text = output;
        }
    }
}