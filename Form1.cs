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
            List<int> l = new List<int>();
            l = QuickSort(list, 0, massiv_in_begin.Length);
            printLab(label5, l.ToArray());
            
        }
        public List<int> QuickSort(List<int> list, int low, int high)//не работает и вам не советует (причина: потеря элемента списка где-то внутри алгоритма)
        {
            if(high - low > 1)
            {
                int m = list.Count();
                label6.Text = Convert.ToString(m);
                Random r = new Random();
                int t = low;
                List<int> LowerT = new List<int>();
                List<int> HigherT = new List<int>();
                int el;
                for (int i = t; i < high; i++)
                {
                    el = list[i];
                    if (list[t] > list[i])
                    {
                        LowerT.Add(el);
                    }
                    //else if (list[t] == list[i]) LowerT.Add(list[i]);
                    else 
                        HigherT.Add(el);
                }
                for (int i = t; i > low; i--)
                {
                    el = list[i];
                    if (list[t] > list[i])
                    {
                        LowerT.Add(el);
                    }
                    else if (list[t] == list[i]) ;
                    else
                        HigherT.Add(el);
                }
                //LowerT.Add(list[t]);
                for (int i = 0; i < HigherT.Count(); i++)
                {
                    LowerT.Add(HigherT[i]);
                }
                list = new List<int>();
                for (int i = 0; i < LowerT.Count(); i++)
                {
                    list.Add(LowerT[i]);
                }
                QuickSort(list, low, t - 1);
                QuickSort(list, t + 1, list.Count());
                
            }
            return list;
            /*if(low < high)
            {
                int p = election(list, low, high);
                QuickSort(list, low, p - 1);
                QuickSort(list, p + 1, high);
            }*/
            /*if(high - low > 1)
            {
                int t;
                if(high - low >= 3)
                {
                    Random r = new Random();
                    t = r.Next(low + 1, high - 1);
                    if(list[t + 1] < list[t] || list[t] < list[t - 1])
                    {
                        int b = list[t + 1];
                        list[t + 1]
                            = list[t - 1];
                        list[t - 1] = b;
                    }
                    
                    QuickSort(list, low, t - 1);
                    QuickSort(list, t + 1, high);
                }
                else if(high - low == 2)
                {
                    if(list[low] > list[high]) {
                        int b = list[low];
                        list[low]
                            = list[high];
                        list[low] = b;
                    }
                }
            }*/
        }

        public void ElectionSort(int[] x) { 
            
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
            for (int i = 0; i < mass.Length; i++)
            {
                q = q + " " + Convert.ToString(mass[i]);
            }
            Lab.Text = q;
        }
    }
}
