using MonkaS.Core.DataModel;
using MonkaS.Core.ViewModel.Base;

namespace MonkaS.Core.ViewModel.Menu
{
    /// <summary>
    /// A view model for a menu item
    /// </summary>
    public class MenuItemViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The text to display for the menu item
        /// </summary>
        private string _Text;

        /// <summary>
        /// The icon for this menu item
        /// </summary>
        private IconType _Icon;

        /// <summary>
        /// The type of this menu item
        /// </summary>
        private MenuItemType _Type;
        #endregion


        #region Public Properties
        /// <summary>
        /// The text to display for the menu item
        /// </summary>
        public string Text
        {
            get => _Text;
            set => this.MutateVerbose(ref _Text, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The icon for this menu item
        /// </summary>
        public IconType Icon
        {
            get => _Icon;
            set => this.MutateVerbose(ref _Icon, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The type of this menu item
        /// </summary>
        public MenuItemType Type
        {
            get => _Type;
            set => this.MutateVerbose(ref _Type, value, RaisePropertyChanged());
        }
        #endregion
    }
}
