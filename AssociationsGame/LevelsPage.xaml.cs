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
    /// Логика взаимодействия для LevelsPage.xaml
    /// </summary>
    public partial class LevelsPage : Page
    {
        string nameUser;
        int countLvl;
        int money;

        bool loadgame_mode = false;

        List<Button> btnL = new List<Button>();

        // Конструктор для окна списка уровней
        public LevelsPage(string name, int countLevel, int moneyUser)
        {
            InitializeComponent();

            // Данные пользователя
            nameUser = name;
            countLvl = countLevel;
            money = moneyUser;

            // Создание кнопок для списка уровней
            string jsonLevels = File.ReadAllText("levels.json");
            List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonLevels);
            if (listLevel != null)
                for (int i = 0; i < listLevel.Count; i++)
                {
                    Button btn = new Button();
                    btn.Content = (i+1).ToString() + " Уровень";
                    if (i > countLevel - 1)
                    {
                        btn.IsEnabled = false;
                    }
                    btnL.Add(btn);
                    stackpanel.Children.Add(btn);
                }
            // Кнопка для создания нового уровня
            Button btnAdd = new Button();
            btnAdd.Content = "+";
            btnL.Add(btnAdd);

            stackpanel.Children.Add(btnAdd);
        }

        // Конструктор для окна списка пользователей
        public LevelsPage(bool loadgame)
        {
            InitializeComponent();

            loadgame_mode = loadgame;

            // Создание кнопок для списка пользователей
            string jsonUsers = File.ReadAllText("users.json");
            List<User>? listUser = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            if (listUser != null)
                for (int i = 0; i < listUser.Count; i++)
                {
                    Button btn = new Button();
                    btn.Content = listUser[i].Name;

                    btnL.Add(btn);
                    stackpanel.Children.Add(btn);
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Нажатие кнопки в списке уровней
            if (!loadgame_mode)
            {
                string jsonLevels = File.ReadAllText("levels.json");
                List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonLevels);
                string jsonUsers = File.ReadAllText("users.json");
                List<User>? listUsers = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
                if (e.Source.ToString()[e.Source.ToString().Length - 1] == '+')
                    this.NavigationService.Navigate(new GamePage(true));
                else
                {
                    foreach (var item in listLevel)
                    {
                        if (e.Source.ToString().Substring(32) == item.Name)
                            this.NavigationService.Navigate(new GamePage(item.Name, item.Image, item.Word, nameUser, countLvl, money));
                    }
                }
            }
            // Нажатие кнопки в списке пользователей
            else
            {
                string jsonUsers = File.ReadAllText("users.json");
                List<User>? listUsers = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
                foreach (var item in listUsers)
                {
                    if (e.Source.ToString().Substring(32) == item.Name)
                        this.NavigationService.Navigate(new LevelsPage(item.Name, item.CountLvl, item.Money));
                }
            }
        }
    }
    public class LevelClass
    {
        public string? Name { get; set; }
        public List<string>? Image { get; set; }
        public string? Word { get; set; }
    }
}
