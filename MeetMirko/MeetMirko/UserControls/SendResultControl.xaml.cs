using System;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MeetMirko
{
    /// <summary>
    /// Interaction logic for SendResult.xaml
    /// </summary>
    public partial class SendResultControl : UserControl
    {
        private const string MYMAIL = "mirko_collura89@hotmail.it";
        private const string MYNUMBER = "3270166633";
        private const string FAKEMAIL = "meet.mirko@gmail.com";
        private const string FAKEPASSWORD = "meetmirko1@";

        private ActivitiesControl _activitiesControl;
        public SendResultControl(ActivitiesControl activitiesControl)
        {
            InitializeComponent();

            _activitiesControl = activitiesControl;
        }

        private void Btn_SendResult_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var gmailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(FAKEMAIL, FAKEPASSWORD)
            };

            using (var msg = new MailMessage(FAKEMAIL, MYMAIL))
            {
                var builder = new StringBuilder();

                builder.Append($"APERITIF: {_activitiesControl.Cb_Aperitif.IsChecked}");
                builder.Append("\n");
                builder.Append($"WALK: {_activitiesControl.Cb_Walk.IsChecked}");
                builder.Append("\n");
                builder.Append($"MOUNTAIN BIKE: {_activitiesControl.Cb_MountainBike.IsChecked}");
                builder.Append("\n");
                builder.Append($"TRIP: {_activitiesControl.Cb_Trip.IsChecked}");
                builder.Append("\n");
                builder.Append($"TEXT: {new TextRange(_activitiesControl.TextBox.Document.ContentStart, _activitiesControl.TextBox.Document.ContentEnd).Text}");

                msg.Body = builder.ToString();

                try
                {
                    gmailClient.Send(msg);
                    MessageBox.Show("Message sent correctly!", string.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("I can't send results, check the connection and try again or use whatsapp!", string.Empty, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Btn_SendWhatsApp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"My number: {MYNUMBER}");
        }
    }
}
