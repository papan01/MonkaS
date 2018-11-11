using MonkaS.Core.DataModel;
using MonkaS.Core.ViewModel.Base;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkaS.Core.ViewModel.Application
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        #region Private Properties
        private bool _LoginIsRunning;
        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning
        {
            get => _LoginIsRunning;
            set => this.MutateVerbose(ref _LoginIsRunning, value, RaisePropertyChanged());
        }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to Register
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new AnotherCommandImplementation(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new AnotherCommandImplementation(async (parameter) => await RegisterAsync(parameter));
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(2000);

                // Go to chat page
                IoC.IoC.Application.GoToPage(ApplicationPage.Chat);

                //var email = Email;

                //// IMPORTANT: Never store unsecure password in variable like this
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            // Go to register page?
            IoC.IoC.Application.GoToPage(ApplicationPage.Register);
            await Task.Delay(1);
        }
    }
}
