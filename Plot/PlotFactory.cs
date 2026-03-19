using MottSchottkyAnalizer.DI.Registration;
using OxyPlot;
using OxyPlot.Axes;

namespace MottSchottkyAnalizer.Infrastructure.Plot;

[Service<IPlotFactory>]
public class PlotFactory : IPlotFactory
{
    public PlotModel CreateBode()
    {
        PlotModel plot = new PlotModel
        {
            Title = "Диаграмма Боде"
        };

        plot.Axes.Add(new LogarithmicAxis
        {
            Position = AxisPosition.Bottom,
            Title = "Частота, Гц",
            Base = 10,
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Dot
        });

        plot.Axes.Add(new LinearAxis
        {
            Position = AxisPosition.Left,
            Title = "C, Ф/м²",
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Dot,
            StringFormat = "0.###"
        });

        return plot;
    }

    public PlotModel CreateSchottky()
    {
        PlotModel plot = new PlotModel();
        plot.Title = "Координаты Мота-Шотки";

        plot.Axes.Add(new LinearAxis()
        {
            Position = AxisPosition.Bottom,
            Title = "Потенциал, В",
            StringFormat = "0.###"
        });

        plot.Axes.Add(new LinearAxis()
        {
            Position = AxisPosition.Left,
            Title = "1/C, м²/Ф",
            StringFormat = "0.###"
        });

        return plot;
    }
}
