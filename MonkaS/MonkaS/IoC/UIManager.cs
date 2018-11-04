using MonkaS.Core.IoC.Interfaces;
using MonkaS.Core.ViewModel.Dialogs;
using System.Threading.Tasks;
using System.Windows;

namespace MonkaS
{
    /// <summary>
    /// The applications implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Displays a single message box to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return Task.Run(() => MessageBox.Show("TEST"));
        }
    }
}
