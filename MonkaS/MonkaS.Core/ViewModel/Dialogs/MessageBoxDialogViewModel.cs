namespace MonkaS.Core.ViewModel.Dialogs
{
    /// <summary>
    /// Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        #region Private Properties
        /// <summary>
        /// The message to display
        /// </summary>
        private string _Message;

        /// <summary>
        /// The text to use for the OK button
        /// </summary>
        private string _OkText = "OK";
        #endregion

        #region Public Properties
        /// <summary>
        /// The message to display
        /// </summary>
        public string Message
        {
            get => _Message;
            set
            {
                _Message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        /// <summary>
        /// The text to use for the OK button
        /// </summary>
        public string OkText
        {
            get => _OkText;
            set
            {
                _OkText = value;
                OnPropertyChanged(nameof(OkText));
            }
        }
        #endregion
    }
}
