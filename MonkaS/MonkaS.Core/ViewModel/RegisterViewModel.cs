using MonkaS.Core.DataModel;
using MonkaS.Core.Security;
using MonkaS.Core.ViewModel.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkaS.Core.ViewModel
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class RegisterViewModel : ViewModelBase
    {
        #region Private Properties
        private bool _RegisterIsRunning;
        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning
        {
            get => _RegisterIsRunning;
            set => this.MutateVerbose(ref _RegisterIsRunning, value, RaisePropertyChanged());
        }

        #endregion

        #region Commands

        /// <summary>
        /// The command to Register
        /// </summary>
        public ICommand RegisterCommand { get; set; }


        /// <summary>
        /// The change page to LoginPage
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RegisterViewModel()
        {
            // Create commands
            RegisterCommand = new AnotherCommandImplementation(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new AnotherCommandImplementation(async (parameter) => await LoginAsync(parameter));
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);

                var email = Email;

                // IMPORTANT: Never store unsecure password in variable like this
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                             
            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            // Go to register page?
            IoC.IoC.Application.GoToPage(ApplicationPage.Login);
            await Task.Delay(1);
        }
    }
}
