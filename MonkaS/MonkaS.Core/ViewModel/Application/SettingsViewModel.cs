using MonkaS.Core.ViewModel.Base;
using MonkaS.Core.ViewModel.Input;
using System.Windows.Input;

namespace MonkaS.Core.ViewModel.Application
{
    /// <summary>
    /// The settings state as a view model
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The current users name
        /// </summary>
        private TextEntryViewModel _Name;
        /// <summary>
        /// The current users username
        /// </summary>
        private TextEntryViewModel _Username;
        /// <summary>
        /// The current users password
        /// </summary>
        private TextEntryViewModel _Password;
        /// <summary>
        /// The current users email
        /// </summary>
        private TextEntryViewModel _Email;

        #endregion

        #region Public Properties

        /// <summary>
        /// The current users name
        /// </summary>
        public TextEntryViewModel Name
        {
            get => _Name;
            set => this.MutateVerbose(ref _Name, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current users username
        /// </summary>
        public TextEntryViewModel Username
        {
            get => _Username;
            set => this.MutateVerbose(ref _Username, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current users password
        /// </summary>
        public TextEntryViewModel Password
        {
            get => _Password;
            set => this.MutateVerbose(ref _Password, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current users email
        /// </summary>
        public TextEntryViewModel Email
        {
            get => _Email;
            set => this.MutateVerbose(ref _Email, value, RaisePropertyChanged());
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to open the settings menu
        /// </summary>
        public ICommand OpenCommand { get; set; }

        /// <summary>
        /// The command to close the settings menu
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsViewModel()
        {
            // Create commands
            OpenCommand = new RelayCommand(Open);
            CloseCommand = new RelayCommand(Close);

            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Louis N" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "N" };
            Password = new TextEntryViewModel { Label = "Password", OriginalText = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "navy90517@gmail.com" };
        }

        #endregion

        /// <summary>
        /// Open the settings menu
        /// </summary>
        public void Open()
        {
            // Close settings menu
            IoC.IoC.Application.SettingsMenuVisible = true;
        }

        /// <summary>
        /// Closes the settings menu
        /// </summary>
        public void Close()
        {
            // Close settings menu
            IoC.IoC.Application.SettingsMenuVisible = false;
        }

    }
}
