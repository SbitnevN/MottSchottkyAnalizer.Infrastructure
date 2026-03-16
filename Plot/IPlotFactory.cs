using OxyPlot;

namespace MottSchottkyAnalizer.Infrastructure.Plot;

public interface IPlotFactory
{
    PlotModel CreateBode();
    PlotModel CreateSchottky();
}