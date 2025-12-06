namespace MottSchottkyAnalizer.Infrastructure.Files;

public static class Filters
{
    public static Filter ExperimentalFilter => new Filter("Эксперементальные данные", "*.txt", "*.edf");
}
