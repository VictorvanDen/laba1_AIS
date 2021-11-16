using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using System.Collections.Generic;

namespace laba1_AIS
{
    public partial class Form1 : Form
    {
        //StreamReader sr = new StreamReader("C:\\Sample.txt");
        public Form1()
        {
            InitializeComponent();
        }
        const int quantity = 5;
        int[] massiv_in_begin = new int[quantity];
        int[] massiv_in_begin1 = new int[quantity];
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
            Random r = new Random();
            for (int i = 0; i < quantity; i++) {
                int y = r.Next(1, 1000);
                massiv_in_begin[i] = y;
                label1.Text = label1.Text + " " + Convert.ToString(y);
                massiv_in_begin1[i] = massiv_in_begin[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int min = massiv_in_begin[0];
            //int u;
            for (int i = 1; i < quantity + 1; i++) {
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
            }
            string q = "";
            for(int i = 0; i < quantity; i++)
            {
                q = q + " " + Convert.ToString(massiv_in_begin1[i]);
            }
            label3.Text = q;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string q = "";
            for (int i = 0; i < quantity; i++)
            {
                q = q + " " + Convert.ToString(massiv_in_begin1[i]);
            }
            label4.Text = q;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<int> list = massiv_in_begin.ToList();
            QuickSort(list, 0, massiv_in_begin.Length);
            printLab(label5, list.ToArray());
            
        }
        public void QuickSort(List<int> unsorted, int low, int high)
        {
            if(high - low > 1)
            {
                int index = i;
                int j = i + 1;
                while (j < high)
                {
                    Random r = new Random();
                    t = r.Next(low + 1, high - 1);
                    if(list[t + 1] < list[t] || list[t] < list[t - 1])
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
            /*int o;
            int pivot = A[h];
            int i = l;
            for(int j = l; j < h - 1; j++)
            {
                if(A[j] <= pivot)
                {
                    o = A[i];
                    A[i] = A[j];
                    A[j] = o;
                    i++;
                }
            }
            o = A[i];
            A[i] = A[h];
            A[h] = o;*/

            Random r = new Random();
            int i = r.Next(l, h);
            return i;
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
    }
}
