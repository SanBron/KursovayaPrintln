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

namespace KursovayaPrintLn
{
    public partial class FormGistogram : Form
    {
        public FormGistogram(List<string> filenames, List<int> indexSearch, string name,string worktime)
        {
            InitializeComponent(name);

            //устанавливаем диапазон, 0-100%
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;

            chart1.Series.Clear();
            richTextBox1.Text = worktime;
            //вводим в чарт значения
            for (int i=0; i<filenames.Count; i++)
            {
                Series seriesOper = new Series();
                //текст
                seriesOper.AxisLabel = filenames[i];
                seriesOper.LegendText = filenames[i];
                var dp1 = seriesOper.Points.Add(indexSearch[i]); // значение по Y
                chart1.Series.Add(seriesOper);
            }            

            chart1.AlignDataPointsByAxisLabel(); // выравнивание столбцов по подписям
        }

        private void FormGistogram_Load(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
