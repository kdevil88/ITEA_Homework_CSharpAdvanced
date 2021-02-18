using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;



namespace GraduationWork
{
    class AccessLevelAttribute : Attribute
    {
        public int level;
        public AccessLevelAttribute(int level)
        {
            this.level = level;
        }
    }
    public class NewOrder
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal ProductTotalPrice 
        { get { return Product.Price * Quantity; } }
    }
    public partial class MainWindow : Window
    {
        private StoreContext db;
        private object CurrentUser = null;
        private User UserData = null;
        public List<NewOrder> NewOrderList;
        private System.Drawing.Font CurrentFont;
        private System.Drawing.Color CurrentBackColor;
        private System.Drawing.Color CurrentFontColor;

        public void Seed()
        {
            // users
            var user_admin = db.Users.FirstOrDefault<User>(n => n.Name.Equals("admin"));
            if (user_admin == null)
            {
                db.Users.Add(new User { Name = "admin", Password = "admin" });
                db.SaveChanges();
                user_admin = db.Users.FirstOrDefault<User>(n => n.Name.Equals("admin"));
            }
            var user_user = db.Users.FirstOrDefault<User>(n => n.Name.Equals("user"));
            if (user_user == null)
            {
                db.Users.Add(new User { Name = "user", Password = "user" });
                db.SaveChanges();
                user_user = db.Users.FirstOrDefault<User>(n => n.Name.Equals("user"));
            }
            // managers
            var manager_admin = db.Managers.FirstOrDefault<Manager>(n => n.User.Name.Equals("admin"));
            if (manager_admin == null)
                db.Managers.Add(new Manager { User = user_admin, FIO = "Store Administrator" });
            // customers
            var customer_user = db.Customers.FirstOrDefault<Customer>(n => n.User.Name.Equals("user"));
            if (customer_user == null)
                db.Customers.Add(new Customer { User = user_user, FIO = "Test customer", Birthday = Convert.ToDateTime("17.02.1989") });
            db.SaveChanges();
            // products
            if (db.Products.Count() == 0)
            {
                db.Products.Add(new Product { Name = "Шнурки PM", Description = "Универсальные шнурки для обуви с логотипом PM.", Price = 255 });
                db.Products.Add(new Product { Name = "Фитнес бутылка black", Description = "Бутылка фитнес брендированная в стиле PM объемом 0,72 л. В комплекте брендированный чехол для бутылки.", Price = 1099 });
                db.Products.Add(new Product { Name = "Перчатки спортивные black & green", Description = "Перчатки CHIBA FIT Black/VPGreen брендированные в стиле PM", Price = 528 });
                db.Products.Add(new Product { Name = "Часы CASIO G-SHOCK GBA-800-9AER", Description = "Циферблат со стрелками и многосегментным ЖК-экраном защищен минеральным стеклом, стойким к ударам.", Price = 5440 });
                db.Products.Add(new Product { Name = "Рюкзак casual", Description = "Рюкзак черный брендированный", Price = 1100 });
                db.Products.Add(new Product { Name = "Носки PM yellow", Description = "Высокие носки PM с логотипом.", Price = 115 });
                db.Products.Add(new Product { Name = "Чехол для телефона На скорости", Description = "Чехол для телефона На скорости", Price = 300 });
                db.SaveChanges();
            }
        }
        public void setCurrentUser(User AuthData)
        {
            if (AuthData != null)
            {
                CurrentUser = db.Customers.FirstOrDefault<Customer>(n => n.User.Id == AuthData.Id);
                if (CurrentUser == null)
                    CurrentUser = db.Managers.FirstOrDefault<Manager>(n => n.User.Id == AuthData.Id);
            }
            if (CurrentUser == null)
            {
                System.Windows.MessageBox.Show("Не удается найти пользователя для учетной записи: " + AuthData?.Name);
                System.Windows.Application.Current.Shutdown();
            }
            UserData = AuthData;
            this.Title = string.Format("Store @ {0}", UserData.Name);
            setPermissions(CurrentUser);
            ReadSettings();
        }

        public void setPermissions(object user)
        {
            bool IsAdmin = Common.isAdmin(user);
            if (!IsAdmin)
            {
                int cust_id = (user as Customer).Id;
                db.Orders.Where(o => o.Customer.Id == cust_id).OrderByDescending(o => o.OrderId).Load();
                tabProducts.Visibility = Visibility.Collapsed;
                tabCustomers.Visibility = Visibility.Collapsed;
                tabManagers.Visibility = Visibility.Collapsed;
                tabUsers.Visibility = Visibility.Collapsed;
                tcMain.SelectedIndex = 0;
            }
            else
            {
                db.Orders.OrderByDescending(o => o.OrderId).Load();
                tabNewOrder.Visibility = Visibility.Collapsed;
                tcMain.SelectedIndex = 1;
            }
        }

        private void ReadSettings()
        {
            RegistryKey settings = Registry.CurrentUser.CreateSubKey(@"Software\ITEA_Store\" + UserData.Name);
            if (settings.GetValue("BackColor") != null)
            {
                CurrentBackColor = ColorTranslator.FromHtml((string)settings.GetValue("BackColor"));
                UpdateColors();
            }
            if (settings.GetValue("FontColor") != null)
            {
                CurrentFontColor = ColorTranslator.FromHtml((string)settings.GetValue("FontColor"));
                UpdateFontColors();
            }
            if (settings.GetValue("Font") != null)
            {
                var fc = new FontConverter();
                CurrentFont = (Font)fc.ConvertFromString((string)settings.GetValue("Font"));
                UpdateFonts();
            }
            settings.Close();
        }

        private void WriteSettings(string key, string value)
        {
            RegistryKey settings = Registry.CurrentUser.CreateSubKey(@"Software\ITEA_Store\" + UserData.Name);
            settings.SetValue(key, value);
            settings.Close();
        }
        public MainWindow()
        {
            InitializeComponent();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StoreContext>());
            db = new StoreContext();
            Seed();
            if (!TryLogin())
                System.Windows.Application.Current.Shutdown();
            NewOrderList = new List<NewOrder>();
            gridNewOrder.ItemsSource = NewOrderList.ToList();
            gridOrders.ItemsSource = db.Orders.Local.ToBindingList();
            db.Products.Load();
            gridProducts.ItemsSource = db.Products.Local.ToBindingList();
            db.Customers.Load();
            gridCustomers.ItemsSource = db.Customers.Local.ToBindingList();
            db.Managers.Load();
            gridManagers.DataContext = db;
            gridManagers.ItemsSource = db.Managers.Local.ToBindingList();
            db.Users.Load();
            gridUsers.ItemsSource = db.Users.Local.ToBindingList();
        }

        private bool TryLogin()
        {
            bool login_result = false;
            while (!login_result)
            {
                LoginWindow login = new LoginWindow();
                UpdateWindow(login);
                if ((bool)login.ShowDialog())
                {
                    User login_user = db.Users.FirstOrDefault<User>(n => n.Name.Equals(login.txtLogin.Text.Trim()));
                    login_result = Common.checkCredentials(login_user, login.txtPassword.Password);
                    if (!login_result)
                    {
                        System.Windows.MessageBox.Show("Неправильно указан логин или пароль");
                        login.Close();
                    }
                    else
                        setCurrentUser(login_user);
                }
                else
                {
                    login_result = true;
                    System.Windows.Application.Current.Shutdown();
                }
            }
            return login_result;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.SaveChanges();
        }

        private void gridUsers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            db.SaveChanges();
        }
        private void gridProducts_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            db.SaveChanges();
        }

        private void btAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow();
            UpdateWindow(customerWindow);
            customerWindow.cbUsers.ItemsSource = db.Users.Local.Select(u => u.Name);
            if (customerWindow.ShowDialog() == true)
            {
                Customer customer = new Customer
                {
                    User = db.Users.Local.FirstOrDefault(u => u.Name.Equals(customerWindow.cbUsers.Text)),
                    FIO = customerWindow.txtFIO.Text,
                    Birthday = customerWindow.dpBirthday.SelectedDate
                };
                db.Customers.Add(customer);
                db.SaveChanges();
                gridCustomers.ItemsSource = null;
                gridCustomers.ItemsSource = db.Customers.Local.ToBindingList();
            }
        }

        private void btEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (gridCustomers.SelectedItem == null) return;
            var EditItem = db.Customers.Find((gridCustomers.SelectedItem as Customer).Id);
            if (EditItem == null) return;
            CustomerWindow customerWindow = new CustomerWindow();
            UpdateWindow(customerWindow);
            customerWindow.cbUsers.ItemsSource = db.Users.Local.Select(u => u.Name);
            customerWindow.cbUsers.SelectedItem = EditItem.User?.Name;
            customerWindow.txtFIO.Text = EditItem.FIO;
            customerWindow.dpBirthday.SelectedDate = EditItem.Birthday;
            if (customerWindow.ShowDialog() == true)
            {
                db.Customers.Attach(EditItem);
                EditItem.User = db.Users.Local.FirstOrDefault(u => u.Name.Equals(customerWindow.cbUsers.Text));
                EditItem.FIO = customerWindow.txtFIO.Text;
                EditItem.Birthday = customerWindow.dpBirthday.SelectedDate;
                db.SaveChanges();
                gridCustomers.ItemsSource = null;
                gridCustomers.ItemsSource = db.Customers.Local.ToBindingList();
            }
        }

        private void gridCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btEditCustomer_Click(null, null);
        }

        private void gridNewOrder_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btEditNewOrder_Click(null, null);
        }

        private void btDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (gridCustomers.SelectedItem == null) return;
            var removeItem = db.Customers.Find((gridCustomers.SelectedItem as Customer).Id);
            if (removeItem == null) return;
            {
                db.Customers.Remove(removeItem);
                db.SaveChanges();
                gridCustomers.ItemsSource = null;
                gridCustomers.ItemsSource = db.Customers.Local.ToBindingList();
            }
        }

        private void btAddManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            UpdateWindow(managerWindow);
            managerWindow.cbUsers.ItemsSource = db.Users.Local.Select(u => u.Name);
            if (managerWindow.ShowDialog() == true)
            {
                Manager manager = new Manager
                {
                    User = db.Users.Local.FirstOrDefault(u => u.Name.Equals(managerWindow.cbUsers.Text)),
                    FIO = managerWindow.txtFIO.Text,
                };
                db.Managers.Add(manager);
                db.SaveChanges();
                gridManagers.ItemsSource = null;
                gridManagers.ItemsSource = db.Managers.Local.ToBindingList();
            }
        }

        private void btEditManager_Click(object sender, RoutedEventArgs e)
        {
            if (gridManagers.SelectedItem == null) return;
            var EditItem = db.Managers.Find((gridManagers.SelectedItem as Manager).Id);
            if (EditItem == null) return;
            ManagerWindow managerWindow = new ManagerWindow();
            UpdateWindow(managerWindow);
            managerWindow.cbUsers.ItemsSource = db.Users.Local.Select(u => u.Name);
            managerWindow.cbUsers.SelectedItem = EditItem.User?.Name;
            managerWindow.txtFIO.Text = EditItem.FIO;
            if (managerWindow.ShowDialog() == true)
            {
                db.Managers.Attach(EditItem);
                EditItem.User = db.Users.Local.FirstOrDefault(u => u.Name.Equals(managerWindow.cbUsers.Text));
                EditItem.FIO = managerWindow.txtFIO.Text;
                db.SaveChanges();
                gridManagers.ItemsSource = null;
                gridManagers.ItemsSource = db.Managers.Local.ToBindingList();
            }
        }

        private void btDeleteManager_Click(object sender, RoutedEventArgs e)
        {
            if (gridManagers.SelectedItem == null) return;
            var removeItem = db.Managers.Find((gridManagers.SelectedItem as Manager).Id);
            if (removeItem == null) return;
            {
                db.Managers.Remove(removeItem);
                db.SaveChanges();
                gridManagers.ItemsSource = null;
                gridManagers.ItemsSource = db.Managers.Local.ToBindingList();
            }
        }

        private void gridManagers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btEditManager_Click(null, null);
        }

        private void btAddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (db.Products.Local.Count() == 0)
            {
                System.Windows.MessageBox.Show("Нет продуктов для заказа");
                return;
            }
            NewOrderWindow neworderWindow = new NewOrderWindow();
            UpdateWindow(neworderWindow);
            neworderWindow.cbProducts.ItemsSource = db.Products.Local.Select(p => p.Name);
            neworderWindow.cbProducts.SelectedIndex = 0;
            if (neworderWindow.ShowDialog() == true)
            {
                NewOrder newOrder = new NewOrder
                {
                    Product = db.Products.Local.FirstOrDefault(p => p.Name.Equals(neworderWindow.cbProducts.Text)),
                    Quantity = Convert.ToInt32(neworderWindow.numQuantity.Text)
                };
                NewOrderList.Add(newOrder);
                gridNewOrder.ItemsSource = null;
                gridNewOrder.ItemsSource = NewOrderList.ToList();
            }
        }

        private void btEditNewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (db.Products.Local.Count() == 0)
            {
                System.Windows.MessageBox.Show("Нет продуктов для заказа");
                return;
            }
            if (gridNewOrder.SelectedItem == null) return;
            var EditItem = NewOrderList[gridNewOrder.SelectedIndex];
            if (EditItem == null) return;
            NewOrderWindow neworderWindow = new NewOrderWindow();
            UpdateWindow(neworderWindow);
            neworderWindow.cbProducts.ItemsSource = db.Products.Local.Select(p => p.Name);
            neworderWindow.cbProducts.SelectedItem = EditItem.Product.Name;
            neworderWindow.numQuantity.Text = EditItem.Quantity.ToString();
            if (neworderWindow.ShowDialog() == true)
            {
                EditItem.Product = db.Products.Local.FirstOrDefault(p => p.Name.Equals(neworderWindow.cbProducts.Text));
                EditItem.Quantity = Convert.ToInt32(neworderWindow.numQuantity.Text);
                gridNewOrder.ItemsSource = null;
                gridNewOrder.ItemsSource = NewOrderList.ToList();
            }
        }

        private void btDeleteNewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (gridNewOrder.SelectedItem == null) return;
            var removeItem = NewOrderList[gridNewOrder.SelectedIndex];
            if (removeItem == null) return;
            {
                NewOrderList.Remove(removeItem);
                gridNewOrder.ItemsSource = null;
                gridNewOrder.ItemsSource = NewOrderList.ToList();
            }
        }

        private void btClearNewOrder_Click(object sender, RoutedEventArgs e)
        {
            NewOrderList.Clear();
            gridNewOrder.ItemsSource = null;
            gridNewOrder.ItemsSource = NewOrderList.ToList();
        }

        private void UpdateColors()
        {
            System.Windows.Media.Color ConvertedColor = System.Windows.Media.Color.FromArgb(CurrentBackColor.A, CurrentBackColor.R, CurrentBackColor.G, CurrentBackColor.B);
            SolidColorBrush BrushColor = new SolidColorBrush(ConvertedColor);
            this.Background = BrushColor;
            MainMenu.Background = BrushColor;
            tcMain.Background = BrushColor;
            tabNewOrder.Background = BrushColor;
            GridNewOrder.Background = BrushColor;
            gridNewOrder.Background = BrushColor;
            tabOrders.Background = BrushColor;
            gridOrders.Background = BrushColor;
            tabProducts.Background = BrushColor;
            gridProducts.Background = BrushColor;
            tabCustomers.Background = BrushColor;
            GridCustomers.Background = BrushColor;
            gridCustomers.Background = BrushColor;
            tabManagers.Background = BrushColor;
            GridManagers.Background = BrushColor;
            gridManagers.Background = BrushColor;
            tabUsers.Background = BrushColor;
            gridUsers.Background = BrushColor;
            btChangeBackColor.Background = BrushColor;
            btChangeFont.Background = BrushColor;
            btChangeFontColor.Background = BrushColor;
        }

        private void UpdateFontColors()
        {
            System.Windows.Media.Color ConvertedColor = System.Windows.Media.Color.FromArgb(CurrentFontColor.A, CurrentFontColor.R, CurrentFontColor.G, CurrentFontColor.B);
            SolidColorBrush BrushColor = new SolidColorBrush(ConvertedColor);
            this.Foreground = BrushColor;
            tcMain.Foreground = BrushColor;
            tabNewOrder.Foreground = BrushColor;
            gridNewOrder.Foreground = BrushColor;
            tabOrders.Foreground = BrushColor;
            gridOrders.Foreground = BrushColor;
            tabProducts.Foreground = BrushColor;
            gridProducts.Foreground = BrushColor;
            tabCustomers.Foreground = BrushColor;
            gridCustomers.Foreground = BrushColor;
            tabManagers.Foreground = BrushColor;
            gridManagers.Foreground = BrushColor;
            tabUsers.Foreground = BrushColor;
            gridUsers.Foreground = BrushColor;
            btChangeBackColor.Foreground = BrushColor;
            btChangeFont.Foreground = BrushColor;
            btChangeFontColor.Foreground = BrushColor;
            btAddNewOrder.Foreground = BrushColor;
            btEditNewOrder.Foreground = BrushColor;
            btDeleteNewOrder.Foreground = BrushColor;
            btClearNewOrder.Foreground = BrushColor;
            btAddCustomer.Foreground = BrushColor;
            btEditCustomer.Foreground = BrushColor;
            btDeleteCustomer.Foreground = BrushColor;
            btAddManager.Foreground = BrushColor;
            btEditManager.Foreground = BrushColor;
            btDeleteManager.Foreground = BrushColor;
        }

        private void UpdateFonts()
        {
            System.Windows.Media.Color ConvertedColor = System.Windows.Media.Color.FromArgb(CurrentFontColor.A, CurrentFontColor.R, CurrentFontColor.G, CurrentFontColor.B);
            SolidColorBrush BrushColor = new SolidColorBrush(ConvertedColor);
            System.Windows.Media.FontFamily currentFontFamily = new System.Windows.Media.FontFamily(CurrentFont.Name);
            this.FontFamily = currentFontFamily;
            this.FontSize = CurrentFont.Size;
            gridNewOrder.FontFamily = currentFontFamily;
            gridNewOrder.FontSize = CurrentFont.Size;
            gridOrders.FontFamily = currentFontFamily;
            gridOrders.FontSize = CurrentFont.Size;
            gridProducts.FontFamily = currentFontFamily;
            gridProducts.FontSize = CurrentFont.Size;
            gridCustomers.FontFamily = currentFontFamily;
            gridCustomers.FontSize = CurrentFont.Size;
            gridManagers.FontFamily = currentFontFamily;
            gridManagers.FontSize = CurrentFont.Size;
            gridUsers.FontFamily = currentFontFamily;
            gridUsers.FontSize = CurrentFont.Size;
        }

        private void UpdateWindow(Window window)
        {
            window.Background = this.Background;
            window.Foreground = this.Foreground;
            window.FontFamily = this.FontFamily;
            window.FontSize = this.FontSize;
        }

        private void btChangeBackColor_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = CurrentBackColor;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentBackColor = colorDialog.Color;
                WriteSettings("BackColor", ColorTranslator.ToHtml(CurrentBackColor));
                UpdateColors();
            }
        }

        private void btChangeFontColor_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = CurrentFontColor;
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentFontColor = colorDialog.Color;
                WriteSettings("FontColor", ColorTranslator.ToHtml(CurrentFontColor));
                UpdateFontColors();
            }
        }

        static void OpenTicket(IAsyncResult asyncResult)
        {
            Stream stream = asyncResult.AsyncState as Stream;
            if (stream != null)
            {
                stream.Close();
            }
            System.Diagnostics.Process.Start(stream.GetType().GetField("m_FullPath", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stream).ToString());
        }

        private void btChangeFont_Click(object sender, RoutedEventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = CurrentFont;
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentFont = fontDialog.Font;
                var fc = new FontConverter();
                WriteSettings("Font", fc.ConvertToString(CurrentFont));
                UpdateFonts();
            }
        }

        private void btMakeNewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (NewOrderList.Count() == 0) return;
            int NewOrderId = 1;
            DateTime NewOrderDate = DateTime.Now;
            if (db.Orders.Local.Count() > 0)
                NewOrderId = db.Orders.Local.Max(o => o.OrderId) + 1;
            StringBuilder ticket = new StringBuilder();
            ticket.Append("Чек из нашего магазина\n\n");
            ticket.Append(string.Format("Заказ №{0}\n", NewOrderId));
            ticket.Append(string.Format("Дата покупки {0}\n\n", NewOrderDate));
            foreach (NewOrder newOrderItem in NewOrderList)
            {
                db.Orders.Add(new Order
                {
                    OrderId = NewOrderId,
                    OrderDate = NewOrderDate,
                    Product = newOrderItem.Product,
                    Quantity = newOrderItem.Quantity,
                    Customer = CurrentUser as Customer
                });
                ticket.Append(string.Format("{0} {1} – {2} грн.\n", newOrderItem.Product.Name, newOrderItem.Quantity, newOrderItem.ProductTotalPrice));
            }
            db.SaveChanges();
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream tempTicket = new IsolatedStorageFileStream("temp.txt", FileMode.Create, userStorage);
            byte[] array = Encoding.UTF8.GetBytes(ticket.ToString());
            tempTicket.BeginWrite(array, 0, array.Length, new AsyncCallback(OpenTicket), tempTicket);
            btClearNewOrder_Click(null, null);
        }
    }
}
