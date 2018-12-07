using MonkaS.Core.DataModel;
using MonkaS.Core.ViewModel.Base;
using MonkaS.Core.ViewModel.Chat.ChatMessageList;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MonkaS.Core.ViewModel.Chat.ChatList
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The display name of this chat list
        /// </summary>
        private string _Name;

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        private string _Message;

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        private string _Initials;

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        private string _ProfilePictureRGB;

        /// <summary>
        /// True if there are unread messages in this chat 
        /// </summary>
        private bool _NewContentAvailable;

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        private bool _IsSelected;
        #endregion

        #region Public Properties
        /// <summary>
        /// The display name of this chat list
        /// </summary>
        public string Name
        {
            get => _Name;
            set => this.MutateVerbose(ref _Name, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Message
        {
            get => _Message;
            set => this.MutateVerbose(ref _Message, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials
        {
            get => _Initials;
            set => this.MutateVerbose(ref _Initials, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB
        {
            get => _ProfilePictureRGB;
            set => this.MutateVerbose(ref _ProfilePictureRGB, value, RaisePropertyChanged());
        }

        /// <summary>
        /// True if there are unread messages in this chat 
        /// </summary>
        public bool NewContentAvailable
        {
            get => _NewContentAvailable;
            set => this.MutateVerbose(ref _NewContentAvailable, value, RaisePropertyChanged());
        }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected
        {
            get => _IsSelected;
            set => this.MutateVerbose(ref _IsSelected, value, RaisePropertyChanged());
        }
        #endregion

        #region Public Commands

        /// <summary>
        /// Opens the current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemViewModel()
        {
            // Create commands
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }
        #endregion

        #region Command Methods

        public void OpenMessage()
        {        
            IoC.IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                     new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Luke",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Luke",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Luke",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,
                    }
                }
            });
        }

        #endregion
    }
}
