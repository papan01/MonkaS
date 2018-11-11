using MonkaS.Core.DataModel;
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
        private PasswordEntryViewModel _Password;
        /// <summary>
        /// The current users email
        /// </summary>
        private TextEntryViewModel _Email;

        /// <summary>
        /// The text for the logout button
        /// </summary>
        private string _LogoutButtonText;
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
        public PasswordEntryViewModel Password
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

        /// <summary>
        /// The text for the logout button
        /// </summary>
        public string LogoutButtonText
        {
            get => _LogoutButtonText;
            set => this.MutateVerbose(ref _LogoutButtonText, value, RaisePropertyChanged());
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

        /// <summary>
        /// The command to logout of the application
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// The command to clear the users data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }
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
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            // TODO: Remove this once the real back-end is ready
            //Name = new TextEntryViewModel { Label = "Name", OriginalText = "Louis N" };
            //Username = new TextEntryViewModel { Label = "Username", OriginalText = "N" };
            //Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            //Email = new TextEntryViewModel { Label = "Email", OriginalText = "navy90517@gmail.com" };

            // TODO: Get from localization
            LogoutButtonText = "Logout";
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

        /// <summary>
        /// Logs the user out
        /// </summary>
        public void Logout()
        {
            // TODO: Confirm the user wants to logout

            // TODO: Clear any user data/cache

            // Clean all application level view models that contain
            // any information about the current user
            ClearUserData();

            // Go to login page
            IoC.IoC.Application.GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clears any data specific to the current user
        /// </summary>
        public void ClearUserData()
        {
            // Clear all view models containing the users info
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }
    }
}
