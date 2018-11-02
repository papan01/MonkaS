using MonkaS.Core.DataModel;
using MonkaS.Core.ViewModel.Base;

namespace MonkaS.Core.ViewModel.PopupMenu
{
    public class BasePopupMenuViewModel : ViewModelBase
    {
        #region Public Properties

        /// <summary>
        /// The background color of the bubble in RGB value
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// The alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        /// <summary>
        /// The content inside of this popup menu
        /// </summary>
        public ViewModelBase Content { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePopupMenuViewModel()
        {
            // Set default values
            // TODO: Move colors into Core and make use of it here
            BubbleBackground = "303030";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}
