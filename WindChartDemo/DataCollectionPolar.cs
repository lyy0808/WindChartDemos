using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WindChartDemo
{
    public class DataCollectionPolar : DataCollection
    {
        public void AddPolar(ChartStylePolar csp)
        {
            double xc = csp.ChartCanvas.Width/ 2;
            double yc = csp.ChartCanvas.Height / 2;

            int j = 0;
            foreach (DataSeries ds in DataList)
            {
                if (ds.SeriesName == "Default Name")
                {
                    ds.SeriesName = "DataSeries" + j.ToString();
                }
                ds.AddLinePattern();
                for (int i = 0; i < ds.LineSeries.Points.Count; i++)
                {

                    double r = ds.LineSeries.Points[i].Y;
                    double theta = ds.LineSeries.Points[i].X * Math.PI / 180;
                    if (csp.AngleDirection == ChartStylePolar.AngleDirectionEnum.CounterClockWise)
                        theta = -theta;

                    double x = xc + csp.RNormalize(r) * Math.Cos(theta);
                    double y = yc + csp.RNormalize(r) * Math.Sin(theta);
                    ds.LineSeries.Points[i] = new Point(x, y);
                    ds.Symbols.AddSymbol(csp.ChartCanvas, ds.LineSeries.Points[i]);
                }
                csp.ChartCanvas.Children.Add(ds.LineSeries);
                j++;
            }
        }

        ///=================================================================================================
        /// <summary>   清空控件所有的图型. </summary>
        ///
        /// <remarks>   lyy, 2017:6:9_10:35:33. </remarks>
        ///
        /// <param name="cs">   The create struct. </param>
        ///-------------------------------------------------------------------------------------------------

        public void ClearLines(ChartStylePolar cs)
        {
            List<int> ListLineRemove = new List<int>();

            for (int i = 0; i < cs.ChartCanvas.Children.Count; i++)
            {
                
                if (cs.ChartCanvas.Children[i].GetType() == typeof(Polyline))
                {
                    ListLineRemove.Add(i);
                }
            }
            for (int j = ListLineRemove.Count - 1; j >= 0; j--)
            {
                cs.ChartCanvas.Children.RemoveAt(j);
                
            }
            //foreach (var item in cs.ChartCanvas.Children)
            //{
            //    if (item.GetType() == typeof(Polyline))
            //    {
            //        ListLineRemove.Add((Polyline)item);
            //    }
            //}
            //foreach (var item in ListLineRemove)
            //{
            //    cs.ChartCanvas.Children.Remove(item);
            //}
            //cs.ChartCanvas.UpdateLayout();
        }
    }
}
