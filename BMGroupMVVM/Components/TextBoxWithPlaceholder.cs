using System.Windows;
using System.Windows.Controls;

namespace BMGroupMVVM.Components
{
    public class TextBoxWithPlaceholder : TextBox
    {
        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(TextBoxWithPlaceholder), new PropertyMetadata(null));
    }
}
