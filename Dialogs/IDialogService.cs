using MottSchottkyAnalizer.Core.Dialogs;
using System.Windows;

namespace MottSchottkyAnalizer.Infrastructure.Dialogs;

public interface IDialogService
{
    bool Show<T>(DialogParameters? parameters = null) where T : Window;
}