using MonkaS.Core.IoC;
using System.Windows.Controls;

namespace MonkaS.Controls
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            DataContext = IoC.Settings;
        }
    }
}
