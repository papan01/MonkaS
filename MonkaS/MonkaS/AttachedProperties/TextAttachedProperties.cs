using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MonkaS.AttachedProperties
{
    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we don't have a control, return
            if (!(sender is Control control))
                return;

            // Focus this control once loaded
            control.Loaded += (s, se) => control.Focus();
        }
    }

    /// <summary>
    /// Focuses (keyboard focus) this element if true
    /// </summary>
    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we don't have a control, return
            if (!(sender is Control control))
                return;

            if ((bool)e.NewValue)
                // Focus this control
                control.Focus();
        }
    }


    /// <summary>
    /// Focuses (keyboard focus) and selects all text in this element if true
    /// </summary>
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {         
            if (sender is TextBoxBase textbox)
            {
                if ((bool)e.NewValue)
                {
                    // Focus this control
                    textbox.Focus();

                    // Select all text
                    textbox.SelectAll();
                }
            }

            if (sender is PasswordBox passwordbox)
            {
                if ((bool)e.NewValue)
                {
                    // Focus this control
                    passwordbox.Focus();

                    // Select all text
                    passwordbox.SelectAll();
                }
            }

        }
    }
}
