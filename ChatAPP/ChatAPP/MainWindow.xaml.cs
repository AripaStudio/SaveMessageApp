using System.Data;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatAPP;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SignUp signUp = new SignUp();
        signUp.ShowDialog();
    }
    public RulesCode rules = new RulesCode();
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {

        string usernametxt = TxtUserName.Text;
        string passwordtxt = TxtPassword.Text;

        rules.LoginAcc(usernametxt, passwordtxt);
        if (GLV.inputOK == 1)
        {
            this.Hide();
            
        }
        else
        {
            MessageBox.Show("Error! Please enter your username and password.", "error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
    }

    
}