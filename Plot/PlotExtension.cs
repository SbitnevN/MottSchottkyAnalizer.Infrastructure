using ElinsData.Data;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Point = MottSchottkyAnalizer.Math.DataPoint;

namespace MottSchottkyAnalizer.Infrastructure.Plot;

public static class PlotExtension
{
    public static void UpdateBode(this PlotModel plot, IEnumerable<IImpedancePoint> impedancePoints)
    {
        List<DataPoint> points = impedancePoints
            .Where(p => p.Frequency > 0)
            .OrderBy(p => p.Frequency)
            .Select(p => new DataPoint(p.Frequency, p.Capacitance))
            .ToList();

        plot.Series.Clear();

        LineSeries series = new LineSeries
        {
            StrokeThickness = 2,
            MarkerType = MarkerType.Circle,
            MarkerSize = 3,
            MarkerFill = OxyColors.White,
            MarkerStroke = OxyColors.SteelBlue,
            MarkerStrokeThickness = 1
        };

        series.Points.AddRange(points);
        plot.Series.Add(series);

        LinearAxis yAxis = plot.Axes.OfType<LinearAxis>().First(a => a.Position == AxisPosition.Left);

        double min = points.Min(p => p.Y);
        double max = points.Max(p => p.Y);
        double pad = (max - min) * 0.1;

        if (pad == 0)
        {
            pad = System.Math.Abs(max) * 0.1;
            if (pad == 0)
                pad = 1;
        }

        yAxis.Minimum = min - pad;
        yAxis.Maximum = max + pad;

        plot.ResetAllAxes();
        plot.InvalidatePlot(true);
    }

    public static void UpdateBodeTest(this PlotModel plot, IEnumerable<IImpedancePoint> impedancePoints)
    {
        IEnumerable<IEnumerable<IImpedancePoint>> groups = impedancePoints
            .OrderBy(p => p.Frequency)
            .GroupBy(p => p.PotentialStep.Step);

        plot.Series.Clear();

        foreach (IEnumerable<IImpedancePoint> points in impedancePoints.GroupBy(p => p.PotentialStep.Step))
        {
            LineSeries series = new LineSeries
            {
                StrokeThickness = 3,
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerFill = OxyColors.White,
                MarkerStroke = OxyColors.SteelBlue,
                MarkerStrokeThickness = 3
            };

            series.Points.AddRange(points
                .OrderBy(p => p.Frequency)
                .Select(p => new DataPoint(p.Frequency, p.Capacitance)));

            plot.Series.Add(series);
        }

        plot.ResetAllAxes();
        plot.InvalidatePlot(true);
    }

    public static void UpdateSchottky(this PlotModel plot, IEnumerable<Point> points)
    {
        plot.Series.Clear();
        ScatterSeries series = new ScatterSeries
        {
            MarkerType = MarkerType.Circle,
            MarkerSize = 4,
            MarkerFill = OxyColors.White,
            MarkerStroke = OxyColors.SteelBlue,
            MarkerStrokeThickness = 5
        };

        series.Points.AddRange(points.Select(i => new ScatterPoint(i.X, i.Y)));

        plot.Series.Add(series);

        plot.ResetAllAxes();
        plot.InvalidatePlot(true);
    }

    public static void AppendLine(this PlotModel plot, double slope, double intercept, params double[] xPoints)
    {
        LineSeries? series = (LineSeries?)plot.Series.FirstOrDefault(s => (s as LineSeries) != null);
        if (series == null)
        {
            series = new LineSeries
            {
                MarkerStrokeThickness = 5,
            };
            plot.Series.Add(series);
        }

        series.Points.Clear();

        foreach (double x in xPoints)
            series.Points.Add(new DataPoint(x, x * slope + intercept));

        plot.ResetAllAxes();
        plot.InvalidatePlot(true);
    }
}
