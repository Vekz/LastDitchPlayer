using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LastDitchPlayer.Classes
{
    internal static class UtilClass
    {
        internal static string RandomAlphaNumericString(int lenght)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        
        }

        public static List<Track> listifyObservableTracks(this ObservableCollection<Track> tracks)
        {
            IEnumerable<Track> obsCollection = (IEnumerable<Track>)tracks;
            var list = new List<Track>(obsCollection);
            return list;
        }

        public static ObservableCollection<Track> listToObservable(this List<Track> tracks)
        {
            IEnumerable<Track> regular = (IEnumerable<Track>)tracks;
            var list = new ObservableCollection<Track>(regular);
            return list;
        }
    }
}
