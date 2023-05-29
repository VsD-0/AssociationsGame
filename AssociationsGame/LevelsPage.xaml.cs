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

            vbUser.Visibility = Visibility.Collapsed;

            string jsonLevels = File.ReadAllText("levels.json");
            List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonLevels);

            List<LevelClass> newList = new List<LevelClass>();

            int i = 1;
            foreach (var p in listLevel)
            {
                LevelClass lvl = new LevelClass();
                lvl.Name = p.Name;
                lvl.Image = p.Image;
                lvl.Word = p.Word;
                if (i <= countLvl)
                    lvl.Enabled = true;
                else
                    lvl.Enabled = false;
                i++;
                newList.Add(lvl);
            }
            //Кнопка для создания нового уровня
            LevelClass lvlAdd = new LevelClass();
            lvlAdd.Name = "+";
            lvlAdd.Enabled = true;
            newList.Add(lvlAdd);
            listLevels.ItemsSource = newList;
        }

        // Конструктор для окна списка пользователей
        public LevelsPage(bool loadgame)
        {
            InitializeComponent();

            listLevels.Visibility = Visibility.Collapsed;

            loadgame_mode = loadgame;

            levelsOrgamers.Text = "Игроки";

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

                foreach (var item in listLevel)
                {
                    if (e.Source.ToString().Substring(32) == item.Name)
                        this.NavigationService.Navigate(new GamePage(item.Name, item.Image, item.Word, nameUser, countLvl, money));
                    else if (e.Source.ToString()[e.Source.ToString().Length - 1] == '+')
                        this.NavigationService.Navigate(new GamePage(true, nameUser, countLvl, money));
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (!loadgame_mode)
                this.NavigationService.Navigate(new LevelsPage(true));
            else
                this.NavigationService.Navigate(new MainPage());
        }
    }
    public class LevelClass
    {
        public string? Name { get; set; }
        public List<string>? Image { get; set; }
        public string? Word { get; set; }
        public bool Enabled { get; set; }
    }
}
