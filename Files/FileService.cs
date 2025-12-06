using Microsoft.Win32;
using MottSchottkyAnalizer.DI.Registration;

namespace MottSchottkyAnalizer.Infrastructure.Files;

[Service<IFileService>]
public class FileService : IFileService
{
    public string SelectFile(Filter filter)
    {
        OpenFileDialog fileDialog = new OpenFileDialog()
        {
            Filter = filter.Build(),
        };

        if (fileDialog.ShowDialog() == true)
            return fileDialog.FileName;

        return string.Empty;
    }

    public string CreateFile(string title, Filter filter)
    {
        SaveFileDialog fileDialog = new SaveFileDialog()
        {
            Filter = filter.Build(),
            OverwritePrompt = true,
            FileName = title,
        };

        if (fileDialog.ShowDialog() == true)
            return fileDialog.FileName;

        return string.Empty;
    }
}
