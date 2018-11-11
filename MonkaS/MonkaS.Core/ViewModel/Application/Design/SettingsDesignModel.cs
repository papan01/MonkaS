using MonkaS.Core.ViewModel.Input;

namespace MonkaS.Core.ViewModel.Application.Design
{
    /// <summary>
    /// The design-time data for a <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Louis Peng" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Louis" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "navy90517@gmail.com" };
        }

        #endregion
    }
}
