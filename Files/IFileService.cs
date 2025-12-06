namespace MottSchottkyAnalizer.Infrastructure.Files;

public interface IFileService
{
    string CreateFile(string title, Filter filter);
    string SelectFile(Filter filter);
}