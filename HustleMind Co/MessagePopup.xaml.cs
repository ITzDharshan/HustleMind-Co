using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HustleMind_Co_
{
    public partial class MessagePopup : Window
    {
        public MessagePopup(string message, string messageType, bool showCancelButton = false)
        {
            InitializeComponent();
            MessageText.Text = message;

            // Display the appropriate icon and color based on the message type
            if (messageType == "Success")
            {
                messageIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Ok-amico.png"));
                MessageText.Foreground = new SolidColorBrush(Colors.Blue);
                okButton.Background = new SolidColorBrush(Colors.Blue);
                okButton.BorderBrush = new SolidColorBrush(Colors.Blue);
                MainBorder.BorderBrush = new SolidColorBrush(Colors.Blue);
            }
            else if (messageType == "Error")
            {
                messageIcon.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/Feeling angry-amico.png"));
                MessageText.Foreground = new SolidColorBrush(Colors.Red);
                okButton.Background = new SolidColorBrush(Colors.Red);
                okButton.BorderBrush = new SolidColorBrush(Colors.Red);
                MainBorder.BorderBrush = new SolidColorBrush(Colors.Red);
            }

            // Show/hide Cancel button based on the flag passed
            if (showCancelButton)
            {
                cancelButton.Visibility = Visibility.Visible;
            }
            else
            {
                cancelButton.Visibility = Visibility.Collapsed;
            }
        }

        // Handle the OK button click
        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;  // Set DialogResult to true when OK is clicked
            this.Close();  // Close the message box when OK is clicked
        }

        // Handle the Cancel button click
        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;  // Set DialogResult to false when Cancel is clicked
            this.Close();  // Close the message box when Cancel is clicked
        }
    }
}
