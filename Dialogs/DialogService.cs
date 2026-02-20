using Microsoft.Extensions.DependencyInjection;
using MottSchottkyAnalizer.Core.Dialogs;
using MottSchottkyAnalizer.DI.Registration;
using System.Windows;

namespace MottSchottkyAnalizer.Infrastructure.Dialogs;

[Service<IDialogService>]
internal class DialogService(IServiceProvider serviceProvider) : IDialogService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public bool Show<T>(DialogParameters? parameters = null) where T : Window
    {
        T dialog = _serviceProvider.GetRequiredService<T>();
        DialogViewModel viewModel = (DialogViewModel)dialog.DataContext;
        viewModel.Parameters = parameters ?? new DialogParameters();
        viewModel.OnChoose += dialog.Close;

        dialog.ShowDialog();
        return viewModel.DialogResult;
    }
}
