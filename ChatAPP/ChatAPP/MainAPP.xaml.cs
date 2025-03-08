using ChatAPP.DataBase.Entity;
using ChatAPP.DataBase.MyDBcontext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ChatAPP
{
    /// <summary>
    /// Interaction logic for MainAPP.xaml
    /// </summary>
    public partial class MainAPP : Window
    {
        public MainAPP()
        {
            InitializeComponent();
            DataContext = this;
            LoadMessagesFromDatabase();
            ColorChange();
        }

       

        
        
        public ObservableCollection<UserMessage> UserMessages { get; set; } = new ObservableCollection<UserMessage>();
        private void LoadMessagesFromDatabase()
        {
            using (var context = new myDbcontext())
            {
                var messages = context.UserMessages.ToList();
                foreach (var message in messages)
                {
                    UserMessages.Add(message);
                }
            }
        }
        public RulesCode Rules = new RulesCode();
        private void BtnProFile_Click(object sender, RoutedEventArgs e)
        {
            string userName = GLV.username;
            string password = GLV.password;
            MessageBox.Show($"UserName : ({userName}) And Password : ({password})");
        }

        

        private void BtnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            string message = InputMessage.Text;
            Sendmessage(message , GLV.username);
        }

        //برای ارسال پیام : 
        public void Sendmessage(string message, string userName)
        {
            if (message != null && message != "" && userName != null && userName != "")
            {
                using (var db = new myDbcontext())
                {
                    var newMessage = new UserMessage()
                    {
                        Content = message,
                        UserName = userName
                    };
                    db.UserMessages.Add(newMessage);
                    db.SaveChanges();

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        UserMessages.Add(newMessage);
                        ListBoxMessage.ScrollIntoView(UserMessages.Last());
                    });
                }
              
            }
            else
            {
                MessageBox.Show("The entered inputs cannot be empty.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserMessage selectedMessage = ListBoxMessage.SelectedItem as UserMessage;

                if (selectedMessage == null)
                {
                    MessageBox.Show("لطفاً یک پیام را انتخاب کنید.");
                    return;
                }

                MessageBoxResult result = MessageBox.Show("آیا مطمئن هستید که می‌خواهید این پیام را حذف کنید؟", "تأیید حذف", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.No)
                {
                    return;
                }

                using (var context = new myDbcontext())
                {
                    context.UserMessages.Remove(selectedMessage);
                    context.SaveChanges();
                }

                UserMessages.Remove(selectedMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا: {ex.Message}");
            }
        }

        public string codeHex
        {
            get; set;

        }

        public void ColorChange()
        {
            using (var db = new myDbcontext())
            {
                var lastCode = db.UserSettings.FirstOrDefault();

                if (lastCode != null)
                {
                    codeHex = lastCode.CodeHEX;
                    try
                    {
                      
                        BrushConverter converter = new BrushConverter();
                        Brush brush = (Brush)converter.ConvertFromString(codeHex);

                     
                        ListBoxMessage.Background = brush;
                        BorderMain.Background = brush;
                    }
                    catch (FormatException)
                    {
                        
                        MessageBox.Show("کد هگز ذخیره شده نامعتبر است.");
                    }
                }
                else
                {
                    
                }
            }
        }

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
    }
}
