using ElinsDataParser;
using ElinsDataParser.Data;
using ElinsDataParser.Elins;
using ElinsDataParser.Text;
using MottSchottkyAnalizer.DI.Registration;
using System.IO;

namespace MottSchottkyAnalizer.Infrastructure.Files;

[Service<IParser>]
public class Parser : IParser
{
    private IElinsParser _elinsParser = new ElinsParser();
    private IElinsParser _textParser = new TextParser();

    public ElinsData Parse(string path)
    {
        string extension = Path.GetExtension(path);
        if (extension == ".txt")
            return _textParser.Parse(path);

        if (extension == ".edf")
            return _elinsParser.Parse(path);

        throw new Exception("Неизвестный тип файла");
    }

    public Task<ElinsData> ParseAsync(string path)
    {
        string extension = Path.GetExtension(path);
        if (extension == ".txt")
            return _textParser.ParseAsync(path);

        if (extension == ".edf")
            return _elinsParser.ParseAsync(path);

        throw new Exception("Неизвестный тип файла");
    }
}
