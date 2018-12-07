using MonkaS.Core.ViewModel.Base;
using System;

namespace MonkaS.Core.ViewModel.Chat.ChatMessageList
{
    /// <summary>
    /// A view model for each chat message thread item in a chat thread
    /// </summary>
    public class ChatMessageListItemViewModel : ViewModelBase
    {
        #region Private properties
        /// <summary>
        /// The display name of the sender of the message
        /// </summary>
        private string _SenderName;

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
        /// True if this item is currently selected
        /// </summary>
        private bool _IsSelected;

        /// <summary>
        /// True if this message was sent by the signed in user
        /// </summary>
        private bool _SentByMe;

        /// <summary>
        /// The time the message was read, or <see cref="DateTimeOffset.MinValue"/> if not read
        /// </summary>
        private DateTimeOffset _MessageReadTime;

        /// <summary>
        /// True if this message has been read
        /// </summary>
        private bool _MessageRead;

        /// <summary>
        /// The time the message was sent
        /// </summary>
        private DateTimeOffset _MessageSentTime;

        /// <summary>
        /// A flag indicating if this item was added since the first main list of items was created
        /// Used as a flag for animating in
        /// </summary>
        private bool _NewItem;
        #endregion


        #region Public properties
        /// <summary>
        /// The display name of the sender of the message
        /// </summary>
        public string SenderName
        {
            get => _SenderName;
            set => this.MutateVerbose(ref _SenderName, value, RaisePropertyChanged());
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
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected
        {
            get => _IsSelected;
            set => this.MutateVerbose(ref _IsSelected, value, RaisePropertyChanged());
        }

        /// <summary>
        /// True if this message was sent by the signed in user
        /// </summary>
        public bool SentByMe
        {
            get => _SentByMe;
            set => this.MutateVerbose(ref _SentByMe, value, RaisePropertyChanged());
        }

        /// <summary>
        /// The time the message was read, or <see cref="DateTimeOffset.MinValue"/> if not read
        /// </summary>
        public DateTimeOffset MessageReadTime
        {
            get => _MessageReadTime;
            set => this.MutateVerbose(ref _MessageReadTime, value, RaisePropertyChanged());
        }

        /// <summary>
        /// True if this message has been read
        /// </summary>
        public bool MessageRead
        {
            get => _MessageRead;
            set => this.MutateVerbose(ref _MessageRead, _MessageReadTime > DateTimeOffset.MinValue, RaisePropertyChanged());
        }

        /// <summary>
        /// The time the message was sent
        /// </summary>
        public DateTimeOffset MessageSentTime
        {
            get => _MessageSentTime;
            set => this.MutateVerbose(ref _MessageSentTime, value, RaisePropertyChanged());
        }

        /// <summary>
        /// A flag indicating if this item was added since the first main list of items was created
        /// Used as a flag for animating in
        /// </summary>
        public bool NewItem
        {
            get => _NewItem;
            set => this.MutateVerbose(ref _NewItem, value, RaisePropertyChanged());
        }
        #endregion
    }
}
