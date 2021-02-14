using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace GraduationWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StoreContext db;
        private User CurrentUser;
        public MainWindow()
        {
            InitializeComponent();
            //Database.SetInitializer(new DropCreateDatabaseAlways<StoreContext>());
            db = new StoreContext();
            db.Users.Load();
            gridUsers.ItemsSource = db.Users.Local.ToBindingList();
#if DEBUG
            CurrentUser = db.Users.FirstOrDefault<User>(n => n.Name.Equals("admin"));
#else
            if (!TryLogin())
                Application.Current.Shutdown();
#endif
        }

        public enum Roles
        {
            Admin,
            User
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private bool TryLogin()
        {
            bool login_result = false;
            while (!login_result)
            {
                LoginWindow login = new LoginWindow();
                if ((bool)login.ShowDialog())
                {
                    User login_user = db.Users.FirstOrDefault<User>(n => n.Name.Equals(login.txtLogin.Text.Trim()));
                    login_result = login_user != null && login_user.Password.Equals(login.txtPassword.Password.Trim());
                    if (!login_result)
                    {
                        MessageBox.Show("Неправильно указан логин или пароль");
                        login.Close();
                    }
                    else
                        CurrentUser = login_user;
                }
                else
                    login_result = false;
            }
            return login_result;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
        }

        private void gridUsers_Loaded(object sender, RoutedEventArgs e)
        {
            /*foreach (DataGridColumn column in gridUsers.ItemsSource)
            {
                switch (column.Header)
                {
                    case "Id":
                        column.Visibility = Visibility.Hidden;
                        break;
                    default:
                        break;
                }

            }
            */
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
