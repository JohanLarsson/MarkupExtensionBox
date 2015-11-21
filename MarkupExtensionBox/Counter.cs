using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using MarkupExtensionBox.Annotations;

namespace MarkupExtensionBox
{
    public class Counter : INotifyPropertyChanged
    {
        private readonly DispatcherTimer _timer;
        private int _value;

        public Counter()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1),
            };
            _timer.Tick += (_, __) => Value++;
            _timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Value
        {
            get { return _value; }
            private set
            {
                if (value == _value) return;
                _value = value;
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
