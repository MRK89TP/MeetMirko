using System;
using System.Windows;

namespace MeetMirko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FirstControl _firstControl = new FirstControl();
        private ActivitiesControl _activitiesControl = new ActivitiesControl();
        private WantMeetControl _wantMeetControl = new WantMeetControl();
        private SendResultControl _sendResultControl;
        private LastControl _lastControl = new LastControl();

        private int _pageNumber = 0;

        public MainWindow()
        {
            InitializeComponent();

            _sendResultControl = new SendResultControl(_activitiesControl);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _wantMeetControl.YesClicked += OnYesClicked;
            _sendResultControl.MessageSent += OnYesClicked;

            ChangeControl();
        }

        private void OnYesClicked(object sender, EventArgs e)
        {
            BtnNext_Click(null, null);
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            _pageNumber++;
            ChangeControl();
            CheckEnable();
        }

        private void CheckEnable()
        {
            BntPrev.IsEnabled = _pageNumber != 0;
            BntNext.IsEnabled = _pageNumber != 4 && _pageNumber != 2;
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            _pageNumber--;
            ChangeControl();
            CheckEnable();
        }

        private void ChangeControl()
        {
            CenterGrid.Children.Clear();
            CenterGrid.Children.Add(GetControl(_pageNumber));
        }

        private UIElement GetControl(int pageNumber)
        {
            switch (pageNumber)
            {
                case 0:
                    return _firstControl;
                case 1:
                    return _activitiesControl;
                case 2:
                    return _wantMeetControl;
                case 3:
                    return _sendResultControl;
                case 4:
                    return _lastControl;
            }

            return null;
        }
    }
}
