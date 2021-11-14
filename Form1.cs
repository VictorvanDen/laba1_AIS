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
    int On = 0;
    const int quantity = 100;
    int[] massiv_in_begin = new int[quantity];

    int[] massiv_in_begin1 = new int[quantity];
    bool f = false;
    public string pathF = "FileLaba_";
    // string FileName + NameSort
    // FileWrite(mass, "QuickSort")

    public bool Check() {
      if (massiv_in_begin[0] == 0) f = false;
      else f = true;
      return f;
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
      f = true;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      FileWrite(massiv_in_begin, "1");
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
            int[] res = new int[quantity];
            using(var sr = new StreamReader(fileName))
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
            On = 0;
            QuickSort(list, 0, massiv_in_begin.Length);
            printLab(label5, list.ToArray());
            FileWrite(list.ToArray(), "3");
        }
        public void QuickSort(List<int> unsorted, int low, int high)
        {
            int i = 0;
            while(i < high - 1)
            {
                int index = i;
                int j = i + 1;
                while(j < high)
                {
                    if(unsorted[index] < unsorted[j])
                    {
                        index = j;
                    }
                    On++;//operation counter
                    j++;
                }
                //LowerT.Add(list[t]);
                for(int i = 0; i < HigherT.Count(); i++)
                {
                    LowerT.Add(HigherT[i]);
                }
                list = LowerT;
                QuickSort(list, low, t - 1);
                QuickSort(list, t + 1, high);
                
            }
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
        int[] Diff = new int[quantity];
        private void button8_Click(object sender, EventArgs e)
        {
            On = 0;
            for(int i = 0; i < quantity; i++)
            {
                On = 0;
                QuickSort(massiv_in_begin.ToList(), 0, i);
                Diff[i] = On;
            }
            printLab(label7, Diff);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form F1 = new Graphik(Diff, quantity);
            this.Hide();
            F1.ShowDialog();
            this.Close();
        }
    }
}
