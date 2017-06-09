using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindChartDemo
{
    /// <summary>
    /// PolarCharts.xaml 的交互逻辑
    /// </summary>
    public partial class PolarCharts : Window
    {

        private ChartStylePolar cs;
        private DataCollectionPolar dc;
        private DataSeries ds;

        public PolarCharts()
        {
            InitializeComponent();
        }

        private void chartGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = chartGrid.ActualWidth;
            double height = chartGrid.ActualHeight;
            double side = width;
            if (width > height)
                side = height;
            chartCanvas.Width = side;
            chartCanvas.Height = side;
            chartCanvas.Children.Clear();
            AddChart1();
        }

        private void AddChart()
        {
            cs = new ChartStylePolar();
            dc = new DataCollectionPolar();
            cs.ChartCanvas = chartCanvas;

            cs.Rmax = 0.5;
            cs.Rmin = 0;
            cs.NTicks = 8;
            cs.AngleStep = 30;
            cs.AngleDirection = ChartStylePolar.AngleDirectionEnum.CounterClockWise;
            cs.LinePattern = ChartStylePolar.LinePatternEnum.Dot;
            cs.LineColor = Brushes.Black;
            cs.SetPolarAxes();

            dc.DataList.Clear();
            ds = new DataSeries();
            ds.LineColor = Brushes.Red;
            for (int i = 0; i < 360; i++)
            {
                double theta = 1.0 * i;
                double r = Math.Abs(Math.Cos(2.0 * theta * Math.PI / 180) * Math.Sin(2.0 * theta * Math.PI / 180));
                ds.LineSeries.Points.Add(new Point(theta, r));
            }
            dc.DataList.Add(ds);
            dc.AddPolar(cs);
        }

        private void AddChart1()
        {
            cs = new ChartStylePolar();
            dc = new DataCollectionPolar();
            cs.ChartCanvas = chartCanvas;

            cs.Rmax = 0;
            cs.Rmin = -7;
            cs.NTicks = 8;
            cs.AngleStep = 30;
            cs.AngleDirection = ChartStylePolar.AngleDirectionEnum.CounterClockWise;
            cs.LinePattern = ChartStylePolar.LinePatternEnum.Dot;
            cs.LineColor = Brushes.Black;
            cs.SetPolarAxes();

            dc.DataList.Clear();
            ds = new DataSeries();
            ds.LineColor = Brushes.Red;
            ds.Symbols = new Symbols { SymbolType = Symbols.SymbolTypeEnum.Square, BorderThickness = 1, SymbolSize = 10, BorderColor = Brushes.Black, FillColor = Brushes.Chocolate };
            for (int i = 0; i < 360; i++)
            {
                double theta = 1.0 * i;
                double r = Math.Log(1.001 + Math.Sin(2 * theta * Math.PI / 180));
                ds.LineSeries.Points.Add(new Point(theta, r));
            }
            dc.DataList.Add(ds);

            ds = new DataSeries();
            ds.LineColor = Brushes.Blue;
            ds.Symbols = new Symbols { SymbolType = Symbols.SymbolTypeEnum.Square, BorderThickness = 1, SymbolSize = 10, BorderColor = Brushes.Black, FillColor = Brushes.Blue };
            for (int i = 0; i < 360; i++)
            {
                double theta = 1.0 * i;
                double r = Math.Log(1.001 + Math.Cos(2 * theta * Math.PI / 180));
                ds.LineSeries.Points.Add(new Point(theta, r));
            }
            dc.DataList.Add(ds);

            dc.AddPolar(cs);
        }

        private void Btn_change_Click(object sender, RoutedEventArgs e)
        {
            AddChart();


            dc.DataList.Clear();
            dc.ClearLines(cs);
            Random rd = new Random();
           
            for (int i = 0; i < 20; i++)
            {
                double theta = 1.0 * i;
                double r = rd.Next(-7, 0); 
                ds.LineSeries.Points.Add(new Point(theta, r));
            }
            dc.DataList.Add(ds);

            dc.AddPolar(cs);
        }
    }
}


