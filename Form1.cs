using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace laba1_AIS
{
    public partial class Form1 : Form
    {
        //StreamReader sr = new StreamReader("C:\\Sample.txt");
        public Form1(bool b)
        {
            InitializeComponent();
            if (b)
            {
                massiv_in_begin1 = FileRead("Gend");
                massiv_in_begin = massiv_in_begin1;
                printLab(label1, massiv_in_begin1);
            }
            else
            {
                Random r = new Random();
                int y;
                for (int i = 0; i < quantity1; i++)
                {
                    y = r.Next(1, 1000);
                    massiv_in_begin[i] = y;
                }
            }
            label9.Text = Convert.ToString(quantity);
            MessageBox.Show("Перед использованием программы вы можете прочитать руководство пользователя (кнопка в правом верхнем углу окна программы с вопросительным знаком).");
        }
        int On = 0;
        const int quantity1 = 10100;
        int quantity = 1000;

        int[] massiv_in_begin = new int[quantity1];

        int[] massiv_in_begin1 = new int[quantity1];
        bool f = false;
        public string pathF = "FileLaba_";
        // string FileName + NameSort
        // FileWrite(mass, "QuickSort")
        public void Gend(ref int[] mass, int q)
        {
            Random r = new Random();
            for (int i = 0; i < q; i++)
            {
                mass[i] = r.Next(1, 1000);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string q = "";
            label1.Text = q;
            Gend(ref massiv_in_begin, quantity);
            massiv_in_begin1 = massiv_in_begin;
            printLab(label1, massiv_in_begin);
            f = true;
            FileWrite(massiv_in_begin, "Gend");
        }
        public void Vstavki(ref int[] array, int l)
        {
            for (int startIndex = 0; startIndex < l - 1; ++startIndex)
            {
                int smallestIndex = startIndex;
                for (int currentIndex = startIndex + 1; currentIndex < l; ++currentIndex)
                {
                    if (array[currentIndex] < array[smallestIndex])
                        smallestIndex = currentIndex;
                    On++;
                }
                On++;
                Swap(ref array[startIndex], ref array[smallestIndex]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Vstavki(ref massiv_in_begin1, quantity);
            printLab(label2, massiv_in_begin1);
            FileWrite(massiv_in_begin1, "Vst");
        }
        const string FN = "File_";
        public void FileWrite(int[] sorted, string fileName)
        {
            fileName = FN + fileName + ".txt";
            using (var sw = new StreamWriter(fileName, false))
            {
                for (int i = 0; i < sorted.Length; i++)
                {
                    sw.WriteLine(sorted[i].ToString());
                }
            }
        }

        public int[] FileRead(string fileName)
        {
            fileName = FN + fileName + ".txt";
            int[] res = new int[quantity1];
            using (var sr = new StreamReader(fileName))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    res[i] = Convert.ToInt32(sr.ReadLine());
                    i++;
                }

            }
            return res;
        }
        public void SortP(ref int[] unsorted, int quant)
        {
            for (int i = 1; i < quant + 1; i++)
            {
                for (int k = 0; k < quant; k++)
                {
                    if (unsorted[k] < unsorted[i - 1])
                    {
                        //u = massiv_in_begin1[k];
                        //massiv_in_begin1[k] = massiv_in_begin1[i - 1];
                        //---min = massiv_in_begin[k];
                        //massiv_in_begin1[i - 1] = u;
                        Swap(ref unsorted[k], ref unsorted[i - 1]);
                        On++;
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            On = 0;
            //int min = massiv_in_begin[0];
            /*for (int i = 1; i < quantity + 1; i++) {
                for (int k = 0; k < quantity; k++) {
                    if (massiv_in_begin1[k] < massiv_in_begin1[i - 1])
                    {
                        //u = massiv_in_begin1[k];
                        //massiv_in_begin1[k] = massiv_in_begin1[i - 1];
                        //---min = massiv_in_begin[k];
                        //massiv_in_begin1[i - 1] = u;
                        Swap(ref massiv_in_begin1[k], ref massiv_in_begin1[i - 1]);
                    }
                }
            }*/
            SortP(ref massiv_in_begin1, quantity);
            printLab(label3, massiv_in_begin1);
            FileWrite(massiv_in_begin1, "SortP");
            /*string q = "";
            for(int i = 0; i < quantity; i++)
            {
                q = q + " " + Convert.ToString(massiv_in_begin1[i]);
            }
            label3.Text = q;*/

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*string q = "";
            for (int i = 0; i < quantity; i++)
            {
                q = q + " " + Convert.ToString(massiv_in_begin1[i]);
            }
            label4.Text = q;*/
            printLab(label4, FileRead("SortP"));
            label3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<int> list = massiv_in_begin.ToList();
            On = 0;
            QuickSort(list, 0, massiv_in_begin.Length);
            printLab(label5, list.ToArray());
            FileWrite(list.ToArray(), "3");
        }
        public void QuickSort(List<int> unsorted, int low, int high)
        {
            Random r = new Random();
            int i = r.Next(low, high);
            int y = i;
            while (i < high - 1)
            {
                int index = i;
                int j = i + 1;
                while (j < high)
                {
                    if (unsorted[index] < unsorted[j])
                    {
                        index = j;
                    }
                    On++;//operation counter
                    j++;
                }
                int boof = unsorted[index];
                unsorted[index] = unsorted[i];
                unsorted[i] = boof;
                //On++; //operation counter
                i++;
            }
            i = y;
            y = low;
            Swap(ref i, ref y);
            while (i > y - 1)
            {
                int index = i;
                int j = i + 1;
                while (j < y)
                {
                    if (unsorted[index] < unsorted[j])
                    {
                        index = j;
                    }
                    On++;//operation counter
                    j++;
                }
                int boof = unsorted[index];
                unsorted[index] = unsorted[i];
                unsorted[i] = boof;
                //On++; //operation counter
                i--;
            }
        }
        public int election(List<int> A, int l, int h)
        {
            return l;
        }
        public void Swap(ref int element1, ref int element2)//не работает для элементов списка (нано технология дала сбой)
        {
            int boof = element1;
            element1 = element2;
            element2 = boof;
        }
        public void printLab(Label Lab, int[] mass)
        {
            string q = "";
            for (int i = 0; i < quantity; i++)
            {
                q = q + " " + Convert.ToString(mass[i]);
            }
            Lab.Text = q;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //printLab(label5, FileRead("1"));
        }
        int[] Diff = new int[quantity1];
        int[] Diff1 = new int[quantity1];
        int[] Diff3 = new int[quantity1];
        private void button8_Click(object sender, EventArgs e)
        {

            On = 0;
            //if (massiv_in_begin[0] == 0) MessageBox.Show("Вы сразу можете посмотреть график сложности алгоритма, нажав на кнопку ниже");
            //else
            //{
            for (int i = 0; i < quantity; i++)
            {
                int[] test_mass = new int[quantity1];
                test_mass = massiv_in_begin;
                On = 0;
                QuickSort(massiv_in_begin.ToList(), 0, i);
                Diff[i] = On;
                On = 0;
                Vstavki(ref test_mass, i);
                Diff1[i] = On;
                test_mass = massiv_in_begin;
                On = 0;
                SortP(ref test_mass, i);
                Diff3[i] = On;
            }
            printLab(label7, Diff);
            FileWrite(Diff, "Diff");
            FileWrite(Diff1, "Diff1");
            FileWrite(Diff3, "Diff3");
            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Diff = FileRead("Diff");
            Diff1 = FileRead("Diff1");
            Diff3 = FileRead("Diff3");
            Form F1 = new Graphik(Diff, Diff1, Diff3, quantity);
            this.Hide();
            F1.ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (quantity < 100) MessageBox.Show("Длина массива должна быть ненулевая");
            else quantity -= 50;
            label9.Text = Convert.ToString(quantity);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (quantity > 10000) MessageBox.Show("Длина массива слишком большая");
            else quantity += 50;
            label9.Text = Convert.ToString(quantity);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            printLab(label12, FileRead("3"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printLab(label11, FileRead("Vst"));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form F1 = new Gid();
            this.Hide();
            F1.ShowDialog();
            this.Close();
        }
    }
}
