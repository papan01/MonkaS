using MonkaS.Core.ViewModel.Base;
using System.Collections.Generic;

namespace MonkaS.Core.ViewModel.Menu
{
    /// <summary>
    /// A view model for a menu
    /// </summary>
    public class MenuViewModel : ViewModelBase
    {
        /// <summary>
        /// The items in this menu
        /// </summary>
        public List<MenuItemViewModel> Items { get; set; }
    }
}
