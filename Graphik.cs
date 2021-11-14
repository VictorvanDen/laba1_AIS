using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
/// <summary>
/// 
/// </summary>

namespace laba1_AIS
{
    public partial class Graphik : Form
    {
        const int qconst = 10000;
        int qF1;
        int[] DifficultOn = new int[qconst];
        public Graphik(int[] Difficult, int q)
        {
            for(int i = 0; i < q; i++) { DifficultOn[i] = Difficult[i]; }
            qF1 = q;
            InitializeComponent();
        }

        private void Graphik_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            
            for (int i = 0; i < qF1; i++)
            {
                /*chart1.Series.Add(Convert.ToString(i));
                chart1.Series.Insert(i, DifficultOn[i]);*/
            }
            //создаем элемент Chart
            
            //кладем его на форму и растягиваем на все окно.
            
            chart1.Dock = DockStyle.Fill;
            //добавляем в Chart область для рисования графиков, их может быть
            //много, поэтому даем ей имя.
            chart1.ChartAreas.Add(new ChartArea("Math functions"));
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
            
            Series mySeriesOfPoint = new Series("Сложность");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";
            for (int i = 0; i < qF1; i++)
            {
                mySeriesOfPoint.Points.AddXY(i, DifficultOn[i]);
            }
            //Добавляем созданный набор точек в Chart
            chart1.Series.Add(mySeriesOfPoint);
        }
    }
}
