using LastDitchPlayer.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LastDitchPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Player();
            playBtn.Content = "\u25B7";
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            changePlayBttnState();
        }

        internal void changePlayBttnState()
        {
            var state = this.DataContext as Player;

            if (state.currentState.GetType().FullName == "LastDitchPlayer.State.StatePaused")
            {
                playBtn.Content = "\u25B7";
            }
            else
            {
                playBtn.Content = "\u23F8";
            }
        }


    }
}
