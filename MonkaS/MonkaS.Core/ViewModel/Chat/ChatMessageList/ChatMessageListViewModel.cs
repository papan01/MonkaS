using MonkaS.Core.ViewModel.Base;
using MonkaS.Core.ViewModel.Dialogs;
using MonkaS.Core.ViewModel.PopupMenu;
using System.Collections.Generic;
using System.Windows.Input;

namespace MonkaS.Core.ViewModel.Chat.ChatMessageList
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        private bool _AttachmentMenuVisible = false;
        #endregion

        #region Public Properties
        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        /// <summary>
        /// True to show the attachment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible
        {
            get => _AttachmentMenuVisible;
            set
            {
                this.MutateVerbose(ref _AttachmentMenuVisible, value, RaisePropertyChanged());
                OnPropertyChanged(nameof(AnyPopupVisible));
            }

        }

        /// <summary>
        /// True if any popup menus are visible
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;


        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu
        {
            get;
            set;
        }
        #endregion

        #region Public Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        /// <summary>
        /// The command for when the user clicks the send button
        /// </summary>
        public ICommand SendCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            // Create commands
            AttachmentButtonCommand = new AnotherCommandImplementation(AttachmentButton);
            PopupClickawayCommand = new AnotherCommandImplementation(PopupClickaway);
            SendCommand = new AnotherCommandImplementation(Send);

            // Make a default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion

        #region Command Methods
        /// <summary>
        /// When the attachment button is clicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton(object sender)
        {
            // Toggle menu visibility
            AttachmentMenuVisible ^= true;
        }

        /// <summary>
        /// When the popup clickaway area is clicked hide any popups
        /// </summary>
        public void PopupClickaway(object sender)
        {
            // Hide attachment menu
            AttachmentMenuVisible = false;
        }

        /// <summary>
        /// When the user clicks the send button, sends the message
        /// </summary>
        public void Send(object sender)
        {
            IoC.IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Send Message",
                Message = "Thank you for writing a nice message :)",
                OkText = "OK"
            });
        }

        #endregion
    }
}
