using MonkaS.Core.DataModel;
using MonkaS.Core.ViewModel.Base;

namespace MonkaS.Core.ViewModel
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The current page of the application
        /// </summary>
        private ApplicationPage _CurrentPage = ApplicationPage.Login;

        private bool _SideMenuVisible = false;
        #endregion

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => _CurrentPage;
            private set => this.MutateVerbose(ref _CurrentPage, value, RaisePropertyChanged());
        }

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible
        {
            get => _SideMenuVisible;
            set => this.MutateVerbose(ref _SideMenuVisible, value, RaisePropertyChanged());
        }


        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoToPage(ApplicationPage page)
        {
            // Set the current page
            CurrentPage = page;

            // Show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
