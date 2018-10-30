using MonkaS.Core.ViewModel.Base;
using System.Collections.Generic;

namespace MonkaS.Core.ViewModel.Chat
{
    public class ChatListViewModel : ViewModelBase
    {
        /// <summary>
        /// A view model for the overview chat list
        /// </summary> 
        public List<ChatListItemViewModel> Items { get; set; }
    }
}
