using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldUpdated
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //user property added
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            //the following adds Name context
            uxName.DataContext = user;
            uxNameError.DataContext = user;
            //then add the container context
            uxContainer.DataContext = user;
            var sample = new SampleContext();
            sample.User.Load();
            var users = sample.User.Local.ToObservableCollection();
            uxList.ItemsSource = users;
        }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //if text in both uxName and uxPassword, allow submit
            if ((user.Name != string.Empty) && (user.Password != string.Empty))
            {
                MessageBox.Show("Submitting password:" + uxPassword.Text);
                //new
                var window = new SecondWindow();
                Application.Current.MainWindow = window;
                Close();
                window.Show();
            }
            else
            {
                MessageBox.Show("You have not entered both username and password...");
            }
        }
    }
}