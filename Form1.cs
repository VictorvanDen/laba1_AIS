﻿using System;
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
            for (int i = 0; i < quantity1; i++)
            {
                cou[i] = i;
            }
            label9.Text = Convert.ToString(quantity);
            //MessageBox.Show("Перед использованием программы вы можете прочитать руководство пользователя (кнопка в правом верхнем углу окна программы с вопросительным знаком).");
        }
        int On = 0;
        const int quantity1 = 10100;
        int quantity = 100;
        int[] cou = new int[quantity1];
        
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
        public void Kostyl()
        {
            MessageBox.Show("Отдельные кнопки для каждой сортировки были отключены, теперь сразу считается сложность для всех сортировок и вывод вектора значений, без вывода отсортированного массива.");
            object sender = new object();
            EventArgs e = new EventArgs();
            button8_Click(sender, e);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Vstavki(ref massiv_in_begin1, quantity);
            //printLab(label2, massiv_in_begin1);
            //printLab(label13, cou);
            //FileWrite(massiv_in_begin1, "Vst");
            Kostyl();

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
            //On = 0;
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
            //SortP(ref massiv_in_begin1, quantity);
            //printLab(label3, massiv_in_begin1);
            //FileWrite(massiv_in_begin1, "SortP");
            /*string q = "";
            for(int i = 0; i < quantity; i++)
            {
                q = q + " " + Convert.ToString(massiv_in_begin1[i]);
            }
            label3.Text = q;*/
            Kostyl();
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
            //List<int> list = massiv_in_begin.ToList();
            //int[] mas = massiv_in_begin;
            //On = 0;
            //mas = QuickSort(mas, 0, quantity);
            //printLab(label5, mas);
            //FileWrite(mas, "3");
            Kostyl();
        }
        public int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    On++;
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        public int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            On++;
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        public void Swap(ref int element1, ref int element2)//не работает для элементов списка (нано технология дала сбой)
        {
            int boof = element1;
            element1 = element2;
            element2 = boof;
        }
        public void printLab(Label Lab, int[] mass, int qu = 50, int d = 7)
        {
            string q = "";
            string b;
            for (int i = 0; i < qu; i++)
            {
                b = Convert.ToString(mass[i]);
                if(b.Length + 1 < d) { for(int k = 0; k < d - b.Length; i++) { b += " "; } }
                q = q + " " + b;
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
            printLab(label3, cou);
            printLab(label2, cou);
            printLab(label5, cou);
            On = 0;
            //if (massiv_in_begin[0] == 0) MessageBox.Show("Вы сразу можете посмотреть график сложности алгоритма, нажав на кнопку ниже");
            //else
            //{
            for (int i = 0; i < quantity; i++)
            {
                int[] test_mass = new int[quantity1];
                test_mass = massiv_in_begin;
                On = 0;
                QuickSort(test_mass, 0, i);
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
            printLab(label16, Diff);
            printLab(label14, Diff1);
            printLab(label15, Diff3);
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
            //Form F1 = new Gid();
            //this.Hide();
            //F1.ShowDialog();
            //this.Close();
            Kostyl();
            MessageBox.Show("Руководство устарело");
        }
    }
}
