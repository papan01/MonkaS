using MonkaS.Animation;
using MonkaS.Core.ViewModel.Chat.ChatMessageList;
using System.Windows.Media.Animation;

namespace MonkaS.Pages
{
    /// <summary>
    /// Interaction logic for ChatMessagePage.xaml
    /// </summary>
    public partial class ChatMessagePage : BasePage<ChatMessageListViewModel>
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessagePage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public ChatMessagePage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }
        #endregion

        #region Override Methods

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            // Make sure UI exists first
            if (ChatMessageList == null)
                return;

            // Fade in chat message list
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);
        }
        #endregion
    }
}
