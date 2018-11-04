using MonkaS.Core.ViewModel.Base;

namespace MonkaS.Core.ViewModel.Dialogs
{
    /// <summary>
    /// A base view model for any dialogs
    /// </summary>
    public class BaseDialogViewModel : ViewModelBase
    {
        #region Priavte Properties
        /// <summary>
        /// The title of the dialog
        /// </summary>
        private string _Title;
        #endregion


        #region Public Properties
        /// <summary>
        /// The title of the dialog
        /// </summary>
        public string Title
        {
            get => _Title;
            set => this.MutateVerbose(ref _Title, value, RaisePropertyChanged());
        } 
        #endregion
    }
}
