using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LastDitchPlayer.Classes
{
    public class Track : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name 
        { 
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        private double length;
        public double Length
        {
            get { return length; }
            set
            {
                length = value;
                OnPropertyChanged("Length");
            }
        }

        public Track(){}
        public Track(string name, string filePath, double length)
        {
            Name = name;
            FilePath = filePath;
            var tmp = Math.Truncate(length);
            Length = length / 100 * 60;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
