using MottSchottkyAnalizer.DI.Registration;
using OxyPlot;
using OxyPlot.Axes;

namespace MottSchottkyAnalizer.Infrastructure.Plot;

[Service<IPlotFactory>]
public class PlotFactory : IPlotFactory
{
    public PlotModel CreateBode()
    {
        PlotModel plot = new PlotModel();
        plot.Title = "Координаты Боде";

        plot.Axes.Add(new LogarithmicAxis()
        {
            Position = AxisPosition.Bottom,
            Title = "Частота, Гц",
            Base = 10
        });

        plot.Axes.Add(new LinearAxis()
        {
            Position = AxisPosition.Left,
            Title = "C, Ф/м2"
        });

        return plot;
    }

    public PlotModel CreateSchottky()
    {
        PlotModel plot = new PlotModel();
        plot.Title = "Координаты Мота-Шотки";

        plot.Axes.Add(new LogarithmicAxis()
        {
            Position = AxisPosition.Bottom,
            Title = "Частота, Гц",
            Base = 10
        });

        plot.Axes.Add(new LinearAxis()
        {
            Position = AxisPosition.Left,
            Title = "C, Ф/м2"
        });

        return plot;
    }
}
