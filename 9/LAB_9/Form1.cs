using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
namespace LAB_9

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class CaseTransistors
        {
            public string transType { get; set; }
            public string transName { get; set; } 
            public string transModelName { get; set; }
            transPrefixName[] Prefixs; 
            CaseTransistors[] transistors;
            public int Length;
            public int ErrorKod; 

            public CaseTransistors(int size, string type, string tname, string modelName)
            {
                transistors = new CaseTransistors[size];
                Length = size;
                setPrefixName(); 
                transType = type;
                transName = tname;
                transModelName = modelName;
            } 
            struct transPrefixName
            {
                public string PrefixName;
                public string PrefixText; 
            }
            public override string ToString() 
            {
                return " Транзистор " + transName + " Тип- " + transType + " модель- " + transModelName;
            }
            void setPrefixName()
            {
                Prefixs = new transPrefixName[14];
                Prefixs[0].PrefixName = "AC"; Prefixs[0].PrefixText = "Germanium small-signal AF транзистор AC126";
                Prefixs[1].PrefixName = "AD"; Prefixs[1].PrefixText = "Germanium AF power транзистор AD133";
                Prefixs[2].PrefixName = "AF"; Prefixs[2].PrefixText = "Germanium small-signal RF транзистор AF117";
                Prefixs[3].PrefixName = "AL"; Prefixs[3].PrefixText = "Germanium RF power транзистор ALZ10";
                Prefixs[4].PrefixName = "AS"; Prefixs[4].PrefixText = "Germanium switching транзистор ASY28";
                Prefixs[5].PrefixName = "AU"; Prefixs[5].PrefixText = "Germanium power switching транзистор AU103";
                Prefixs[6].PrefixName = "BC"; Prefixs[6].PrefixText = "Silicon, small signal транзистор BC548B";
                Prefixs[7].PrefixName = "BD"; Prefixs[7].PrefixText = "Silicon, power транзистор BD139";
                Prefixs[8].PrefixName = "BF"; Prefixs[8].PrefixText = "Silicon, RF (high frequency) BJT or FET BF245";
                Prefixs[9].PrefixName = "BS"; Prefixs[9].PrefixText = "Silicon, switching транзистор (BJT or MOSFET) BS170";
                Prefixs[10].PrefixName = "BL"; Prefixs[10].PrefixText = "Silicon, high frequency, high power (for transmitters) BLW34";
                Prefixs[11].PrefixName = "BU"; Prefixs[11].PrefixText = "Silicon, high voltage (for CRT horizontal deflection circuits) BU508";
                Prefixs[12].PrefixName = "CF"; Prefixs[12].PrefixText = "Gallium Arsenide small-signal Microwave транзистор (MESFET) CF300";
                Prefixs[13].PrefixName = "CL"; Prefixs[13].PrefixText = "Gallium Arsenide Microwave power транзистор (FET) CLY10";
            }
            bool OkPrefixName(string prefix)
            {
                for (int i = 0; i < 14; i++)
                {
                    if (Prefixs[i].PrefixName == prefix) return true;
                }
                return false;
            }
            bool OkIndex(int i)
            {
                if (i >= 0 && i < Length) return true;
                else return false;
            }
            public CaseTransistors this[int index]
            {
                get 
                {
                    if (OkIndex(index)) 
                    {
                        ErrorKod = 0;
                        return transistors[index];
                    }
                    else
                    {
                        ErrorKod = 1; 
                        return null;
                    }
                }
                set 
                {
                    if (!OkIndex(index))
                    {
                        ErrorKod = 1;
                        return;
                    }
                    if (!OkPrefixName(value.transName.Substring(0, 2)))
                    {
                        ErrorKod = 2;
                        return;
                    }
                    transistors[index] = value;
                    ErrorKod = 0; 
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CaseTransistors MyTr = new CaseTransistors(5, "Bipolar", "AC126", "EbbersMoll");
            CaseTransistors MyTr1 = new CaseTransistors(1, "Field-effet", "AC126", "Gummel-Poon");
            CaseTransistors MyTr2 = new CaseTransistors(1, "Field-effet", "AD133", "Gummel-Poon");
            CaseTransistors MyTr3 = new CaseTransistors(1, "Schottky", "BD139", "Gummel-Poon");
            CaseTransistors MyTr4 = new CaseTransistors(1, "Avalanche", "OO117", "EbbersMoll");
            CaseTransistors MyTr5 = new CaseTransistors(1, "Darlington", "BLW34", "EbbersMoll");
            CaseTransistors MyTr6 = new CaseTransistors(1, "Photo", "BU508", "EbbersMoll");
            CaseTransistors MyTr7 = new CaseTransistors(1, "Bipolar", "CLY10", "EbbersMoll");
            string sMessage = " ";
            MyTr[0] = MyTr1;
            if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 1 Транзистор не додано " + MyTr1.transName + " код помилки -" + MyTr.ErrorKod.ToString();
            else sMessage = sMessage + "\n 1 Транзистор додано " + MyTr1.transName + " ";
            MyTr[1] = MyTr2;
            if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 2 Транзистор не додано " + MyTr2.transName + " код помилки -" + MyTr.ErrorKod.ToString();
            else sMessage = sMessage + "\n 2 Транзистор додано " + MyTr2.transName + " ";
            MyTr[2] = MyTr3;
            if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 3 Транзистор не додано " + MyTr3.transName + " код помилки -" + MyTr.ErrorKod.ToString();
            else sMessage = sMessage + "\n 3 Транзистор додано " + MyTr3.transName + " ";
            MyTr[3] = MyTr4;
            if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 4 Транзистор не додано " + MyTr4.transName + " код помилки -" + MyTr.ErrorKod.ToString();
            else sMessage = sMessage + "\n 4 Транзистор додано " + MyTr4.transName + " ";
            MyTr[4] = MyTr5;
            if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 5 Транзистор не додано " + MyTr5.transName + " код помилки -" + MyTr.ErrorKod.ToString();
            else sMessage = sMessage + "\n 5 Транзистор додано " + MyTr5.transName + " ";
            MyTr[5] = MyTr6;
            if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 6 Транзистор не додано " + MyTr6.transName + " код помилки -" + MyTr.ErrorKod.ToString();
            else sMessage = sMessage + "\n 6 Транзистор додано " + MyTr6.transName + " ";
            MyTr[6] = MyTr7;
            if (MyTr.ErrorKod > 0) sMessage = sMessage + "\n 7 Транзистор не додано " + MyTr7.transName + " код помилки -" + MyTr.ErrorKod.ToString();
            else sMessage = sMessage + "\n 7 Транзистор додано " + MyTr7.transName + " ";
            label1.Text = sMessage;
            sMessage = "";
            for (int i = 0; i < MyTr.Length; i++)
            {
                if (MyTr[i] != null) sMessage = sMessage + "\n " + MyTr[i].ToString();
            }
            label2.Text = sMessage;
        }
    }
}