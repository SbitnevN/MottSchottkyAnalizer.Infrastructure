using MottSchottkyAnalizer.Core.Dialogs;
using MottSchottkyAnalizer.DI.Injection;
using MottSchottkyAnalizer.DI.Registration;
using System.Windows;

namespace MottSchottkyAnalizer.Infrastructure.Dialogs;

[Service<IDialogService>]
internal class DialogService(IAppProvider serviceProvider) : IDialogService
{
    private readonly IAppProvider _serviceProvider = serviceProvider;

    public bool Show<T>(DialogParameters? parameters = null) where T : Window
    {
        T dialog = _serviceProvider.GetRequiredService<T>();
        DialogViewModel viewModel = (DialogViewModel)dialog.DataContext;
        viewModel.Parameters = parameters ?? new DialogParameters();
        viewModel.OnChoose += () => dialog.Close();

        dialog.ShowDialog();

        return viewModel.DialogResult;
    }
}
