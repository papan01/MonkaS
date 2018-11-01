using MonkaS.Core.ViewModel.Base;
using System.Collections.Generic;

namespace MonkaS.Core.ViewModel.Chat.ChatMessageList
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : ViewModelBase
    {
        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }
    }
}
