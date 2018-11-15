using MonkaS.Core.DataModel;
using MonkaS.Core.ViewModel.Base;

namespace MonkaS.Core.ViewModel.Application
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

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page 
        ///       at the time it changes
        /// </summary>
        private ViewModelBase _CurrentPageViewModel;
        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        private bool _SideMenuVisible = false;

        /// <summary>
        /// True if the settings menu should be shown
        /// </summary>
        private bool _SettingsMenuVisible = false;
        #endregion


        #region Public Properties
        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => _CurrentPage;
            private set => this.MutateVerbose(ref _CurrentPage, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page 
        ///       at the time it changes
        /// </summary>
        public ViewModelBase CurrentPageViewModel
        {
            get => _CurrentPageViewModel;
            private set => this.MutateVerbose(ref _CurrentPageViewModel, value, RaisePropertyChanged());
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
        /// True if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible
        {
            get => _SettingsMenuVisible;
            set => this.MutateVerbose(ref _SettingsMenuVisible, value, RaisePropertyChanged());
        }
        #endregion

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, ViewModelBase viewModel = null)
        {
            // Always hide settings page if we are changing pages
            SettingsMenuVisible = false;

            // Set the view model
            CurrentPageViewModel = viewModel;

            // Set the current page
            CurrentPage = page;

            // Fire off a CurrentPage changed event
            OnPropertyChanged(nameof(CurrentPage));

            // Show side menu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
