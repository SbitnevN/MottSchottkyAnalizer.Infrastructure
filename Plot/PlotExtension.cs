using ElinsData.Data;
using OxyPlot;
using OxyPlot.Series;

namespace MottSchottkyAnalizer.Infrastructure.Plot;

public static class PlotExtension
{
    public static void UpdateBode(this PlotModel plot, IEnumerable<IImpedancePoint> impedancePoints)
    {
        IEnumerable<DataPoint> points = impedancePoints
            .OrderBy(p => p.Frequency)
            .Select(p => new DataPoint(p.Frequency, p.Capacitance));

        plot.Series.Clear();
        LineSeries series = new LineSeries
        {
            MarkerType = MarkerType.Circle,
            MarkerSize = 2,
            MarkerFill = OxyColors.Red,
        };
        series.Points.AddRange(points);

        plot.Series.Add(series);
        plot.ResetAllAxes();
        plot.InvalidatePlot(true);
    }
}
