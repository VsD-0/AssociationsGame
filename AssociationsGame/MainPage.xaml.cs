using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;
using System.IO;

namespace AssociationsGame
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Кнопка выход
        private void CloseCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        // Кнопка новая игра
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            dialogHost.IsOpen = true;
        }

        // Кнопка загрузить
        private void btnLoadGame_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LevelsPage(true));
        }

        // Кнопка продолжить в диалоговом окне
        private void wdContinue_Click(object sender, RoutedEventArgs e)
        {
            // Добавление нового пользователя и сохранение данных в json файл
            string jsonUsers = File.ReadAllText("users.json");
            List<User>? listUser = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            User user = new User();
            user.Name = nameUser.Text;
            user.CountLvl = 1;
            user.Money = 100;
            listUser.Add(user);
            var modifiedJson = JsonConvert.SerializeObject(listUser, Formatting.Indented);
            File.WriteAllText("users.json", modifiedJson);
            this.NavigationService.Navigate(new LevelsPage(user.Name, 1, user.Money));
        }

        // Кнопка отмены в диалоговом окне
        private void wdMenu_Click(object sender, RoutedEventArgs e)
        {
            dialogHost.IsOpen = false;
        }
    }
    class User
    {
        public string? Name { get; set; }
        public int CountLvl { get; set; }
        public int Money { get; set; }
    }
}
