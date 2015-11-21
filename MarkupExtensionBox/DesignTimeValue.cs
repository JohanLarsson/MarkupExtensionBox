using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MarkupExtensionBox.Annotations;

namespace MarkupExtensionBox
{
    public class DesignTimeValue : INotifyPropertyChanged
    {
        public static readonly DesignTimeValue Instance = new DesignTimeValue();

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(string),
            typeof(DesignTimeValue),
            new PropertyMetadata(default(string), OnValueChanged));

        private string _currentValue = "initial";

        private DesignTimeValue()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentValue
        {
            get { return _currentValue; }
            set
            {
                if (value == _currentValue) return;
                _currentValue = value;
                OnPropertyChanged();
            }
        }

        public static void SetValue(DependencyObject element, string value)
        {
            element.SetValue(ValueProperty, value);
        }

        public static string GetValue(DependencyObject element)
        {
            return (string)element.GetValue(ValueProperty);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.CurrentValue = (string)e.NewValue;
        }
    }
}