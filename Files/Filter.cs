using System.Text;

namespace MottSchottkyAnalizer.Infrastructure.Files;

public class Filter
{
    private StringBuilder _stringBuilder = new StringBuilder();

    internal Filter(string title, params string[] extensions)
    {
        _stringBuilder.Append(title.Trim())
            .Append(" (").AppendJoin(", ", extensions)
            .Append(")|")
            .AppendJoin(';', extensions);
    }

    public string Build()
    {
        return _stringBuilder.ToString();
    }
}
