using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamEffectsTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _longTap, _tap;

        public int LongTap
        {
            get
            {
                return _longTap;
            }
            set
            {
                _longTap = value;
                OnPropertyChanged("LongTap");
            }
        }
        public int Tap
        {
            get
            {
                return _tap;
            }
            set
            {
                _tap = value;
                OnPropertyChanged("Tap");
            }
        }


        public ICommand LongTapCommand { get; set; }
        public ICommand TapCommand { get; set; }

        public MainViewModel()
        {
            LongTapCommand = new Command(LongTapCommandExecute);
            TapCommand = new Command(TapCommandExecute);
            LongTap = 0;
            Tap = 0;
        }

        private void TapCommandExecute()
        {
           Tap = Tap + 1;
        }

        private void LongTapCommandExecute()
        {
            LongTap = LongTap + 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
