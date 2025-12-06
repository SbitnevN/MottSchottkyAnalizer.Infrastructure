using ElinsDataParser.Data;

namespace MottSchottkyAnalizer.Infrastructure.Files;

public interface IParser
{
    ElinsData Parse(string path);
    Task<ElinsData> ParseAsync(string path);
}