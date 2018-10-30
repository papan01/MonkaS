using MonkaS.Core.ViewModel.Base;
using System.Windows;
using System.Windows.Input;

namespace MonkaS.ViewModel
{
    public class MainWindowViewModel: ViewModelBase
    {
        #region Private Member
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window _Window;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int _OuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _WindowRadius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition _DockPosition = WindowDockPosition.Undocked;
        #endregion

        #region Public Properties
        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless { get { return (_Window.WindowState == WindowState.Maximized || _DockPosition != WindowDockPosition.Undocked); } }

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(ResizeBorder + OuterMarginSize);
            }
        }

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return _Window.WindowState == WindowState.Maximized ? 0 : _OuterMarginSize;
            }
            set
            {
                _OuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(OuterMarginSize);
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return _Window.WindowState == WindowState.Maximized ? 0 : _WindowRadius;
            }
            set
            {
                _WindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu the window
        /// </summary>
        public ICommand MenuCommand { get; set; }
    
        #endregion

        #region constructor
        public MainWindowViewModel(Window window)
        {
            _Window = window;
            // Listen out for the window resizing
            _Window.StateChanged += (sender, e) =>
            {
                WindowResized();
            };

            CreateCommand();

            // Fix window resize issue
            var resizer = new WindowResizer(_Window);

            // Listen out for dock changes
            resizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                _DockPosition = dock;

                // Fire off resize events
                WindowResized();
            };

        }

        #endregion

        #region Command Implementation
        private void CreateCommand()
        {
            MinimizeCommand = new AnotherCommandImplementation(MinimizeExecute);
            MaximizeCommand = new AnotherCommandImplementation(MaximizeExecute);
            CloseCommand = new AnotherCommandImplementation(CloseExecute);
            MenuCommand = new AnotherCommandImplementation(ShowSystemMenuExecute);
        }

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        private void MinimizeExecute(object sender) => _Window.WindowState = WindowState.Minimized;

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        private void MaximizeExecute(object sender)
        {
            if (_Window.WindowState == WindowState.Maximized)
                _Window.WindowState = WindowState.Normal;
            else
                _Window.WindowState = WindowState.Maximized;
        } 

        /// <summary>
        /// The command to close the window
        /// </summary>
        private void CloseExecute(object sender) => _Window.Close();

        /// <summary>
        /// The command to show the system menu the window
        /// </summary>
        private void ShowSystemMenuExecute(object sender) => SystemCommands.ShowSystemMenu(_Window, GetMousePosition());
        #endregion

        #region Private Helper
        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(_Window);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + _Window.Left, position.Y + _Window.Top);
        }

        /// <summary>
        /// If the window resizes to a special position (docked or maximized)
        /// this will update all required property change events to set the borders and radius values
        /// </summary>
        private void WindowResized()
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }
        #endregion
    }
}
