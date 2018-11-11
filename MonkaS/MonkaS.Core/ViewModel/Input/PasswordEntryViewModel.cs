using MonkaS.Core.Security;
using MonkaS.Core.ViewModel.Base;
using MonkaS.Core.ViewModel.Dialogs;
using System.Security;
using System.Windows.Input;

namespace MonkaS.Core.ViewModel.Input
{
    /// <summary>
    /// The view model for a password entry to edit a password 
    /// <summary>
    public class PasswordEntryViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        private string _Label;

        /// <summary>
        /// The fake password display string
        /// </summary>
        private string _FakePassword;

        /// <summary>
        /// The current password hint text
        /// </summary>
        private string _CurrentPasswordHintText;

        /// <summary>
        /// The new password hint text
        /// </summary>
        private string _NewPasswordHintText;

        /// <summary>
        /// The confirm password hint text
        /// </summary>
        private string _ConfirmPasswordHintText;

        /// <summary>
        /// The current saved password
        /// </summary>
        private SecureString _CurrentPassword;

        /// <summary>
        /// The current non-commit edited password
        /// </summary>
        private SecureString _NewPassword;

        /// <summary>
        /// The current non-commit edited confirmed password
        /// </summary>
        private SecureString _ConfirmPassword;

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        private bool _Editing;

        #endregion

        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label
        {
            get => _Label;
            set => this.MutateVerbose(ref _Label, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The fake password display string
        /// </summary>
        public string FakePassword
        {
            get => _FakePassword;
            set => this.MutateVerbose(ref _FakePassword, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current password hint text
        /// </summary>
        public string CurrentPasswordHintText
        {
            get => _CurrentPasswordHintText;
            set => this.MutateVerbose(ref _CurrentPasswordHintText, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The new password hint text
        /// </summary>
        public string NewPasswordHintText
        {
            get => _NewPasswordHintText;
            set => this.MutateVerbose(ref _NewPasswordHintText, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The confirm password hint text
        /// </summary>
        public string ConfirmPasswordHintText
        {
            get => _ConfirmPasswordHintText;
            set => this.MutateVerbose(ref _ConfirmPasswordHintText, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current saved password
        /// </summary>
        public SecureString CurrentPassword
        {
            get => _CurrentPassword;
            set => this.MutateVerbose(ref _CurrentPassword, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current non-commit edited password
        /// </summary>
        public SecureString NewPassword
        {
            get => _NewPassword;
            set => this.MutateVerbose(ref _NewPassword, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The current non-commit edited confirmed password
        /// </summary>
        public SecureString ConfirmPassword
        {
            get => _ConfirmPassword;
            set => this.MutateVerbose(ref _ConfirmPassword, value, RaisePropertyChanged());
        }

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        public bool Editing
        {
            get => _Editing;
            set => this.MutateVerbose(ref _Editing, value, RaisePropertyChanged());
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commits the edits and saves the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public PasswordEntryViewModel()
        {
            // Create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            // Set default hints
            // TODO: Replace with localization text
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            // Clear all password
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();

            // Go into edit mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            // Make sure current password is correct
            // TODO: This will come from the real back-end store of this users password
            //       or via asking the web server to confirm it
            var storedPassword = "Testing";

            // Confirm current password is a match
            // NOTE: Typically this isn't done here, it's done on the server
            if (storedPassword != CurrentPassword.Unsecure())
            {
                // Let user know
                IoC.IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password",
                    Message = "The current password is invalid"
                });

                return;
            }

            // Now check that the new and confirm password match
            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                // Let user know
                IoC.IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password mismatch",
                    Message = "The new and confirm password do not match"
                });

                return;
            }

            // Check we actually have a password
            if (NewPassword.Unsecure().Length == 0)
            {
                // Let user know
                IoC.IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password too short",
                    Message = "You must enter a password!"
                });

                return;
            }

            // Set the edited password to the current value
            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);

            Editing = false;
        }
        #endregion
    }
}
