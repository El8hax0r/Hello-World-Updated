using System.Windows;


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
        }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //if text in both uxName and uxPassword, allow submit
            if ((user.Name != string.Empty) && (user.Password != string.Empty))
            {
                MessageBox.Show("Submitting password:" + uxPassword.Text);
            }
            else
            {
                MessageBox.Show("You have not entered both username and password...");
            }
        }
    }
}
