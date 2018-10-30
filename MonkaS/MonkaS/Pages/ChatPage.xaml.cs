using MonkaS.Core.Security;
using MonkaS.Core.ViewModel;
using System.Security;

namespace MonkaS.Pages
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<LoginViewModel>, IHavePassword
    {
        public ChatPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => null;
    }
}
