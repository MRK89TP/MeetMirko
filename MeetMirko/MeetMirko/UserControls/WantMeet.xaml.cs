using System;
using System.Windows;
using System.Windows.Controls;

namespace MeetMirko
{
    /// <summary>
    /// Interaction logic for WantMeet.xaml
    /// </summary>
    public partial class WantMeetControl : UserControl
    {
        public EventHandler YesClicked;
        public WantMeetControl()
        {
            InitializeComponent();
        }

        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Good choice!", string.Empty, MessageBoxButton.OK, MessageBoxImage.Information);

            YesClicked?.Invoke(this, new EventArgs());
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry, this button in broken!", string.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
