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
using System.Collections.ObjectModel;
using Microsoft.Win32;
using MaterialDesignThemes;
using Newtonsoft.Json;
using System.IO;

namespace AssociationsGame
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        bool modeEdit = false;

        List<TextBox> letter = new List<TextBox>();

        LevelClass lvl = new LevelClass();
        User user = new User();

        // Конструктор для режима игры
        public GamePage(string name, List<string> image, string word, string nameUser, int countLvl, int moneyUser)
        {
            InitializeComponent();

            // Создание объекта нынешнего уровня
            lvl.Image = image;
            lvl.Name = name;
            lvl.Word = word;

            // Создание объекта нынешнего пользователя
            user.Name = nameUser;
            user.CountLvl = countLvl;
            user.Money = moneyUser;
            user.Level = lvl.Name;

            this.DataContext = user;

            Image1.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + lvl.Name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(lvl.Image[0])}", UriKind.RelativeOrAbsolute));
            Image2.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + lvl.Name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(lvl.Image[1])}", UriKind.RelativeOrAbsolute));
            Image3.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + lvl.Name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(lvl.Image[2])}", UriKind.RelativeOrAbsolute));
            Image4.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + lvl.Name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(lvl.Image[3])}", UriKind.RelativeOrAbsolute));

            for (int i = 0; i < lvl.Word.Length; i++)
            {
                TextBox tb = new TextBox();
                tb.Width = 75;
                stackpanel.Children.Add(tb);
                letter.Add(tb);
            }
        }

        // Конструктор для режима создания нового уровня
        public GamePage(bool edit)
        {
            InitializeComponent();

            modeEdit = edit;

            TextBox tb = new TextBox();
            stackpanel.Children.Add(tb);
            tb.MaxLength = 11;
            tb.MinWidth = 60;
            letter.Add(tb);

            Button btnSave = new Button();
            mainStackpanel.Children.Add(btnSave);
        }

        // Кнопка сохранения уровня
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Создание и сохранения уровня в json файл
            string jsonRunners = File.ReadAllText("levels.json");
            List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);

            LevelClass lc = new LevelClass();

            lc.Image = new List<string> { Image1.Source.ToString(), Image2.Source.ToString(), Image3.Source.ToString(), Image4.Source.ToString()};
            lc.Word = letter[0].Text;

            lc.Name = (listLevel.Count + 1).ToString() + " Уровень";


            listLevel.Add(lc);
            var modifiedJson = JsonConvert.SerializeObject(listLevel, Formatting.Indented);
            File.WriteAllText("levels.json", modifiedJson);
            this.NavigationService.Navigate(new MainPage());
        }

        // Кнопка выхода в главное меню через DrawerHost
        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (modeEdit)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg; *.png)|*.jpg;*.png|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        string jsonRunners = File.ReadAllText("levels.json");
                        List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);
                        string name = (listLevel.Count + 1).ToString() + " Уровень";
                        if (!Directory.Exists(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\")))
                        {
                            Directory.CreateDirectory(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\"));
                        }
                        File.Copy(openFileDialog.FileName, $"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}");
                        Image1.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}", UriKind.RelativeOrAbsolute));
                    }
                    catch {}
                }
            }
        }
        private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (modeEdit)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg; *.png)|*.jpg;*.png|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        string jsonRunners = File.ReadAllText("levels.json");
                        List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);
                        string name = (listLevel.Count + 1).ToString() + " Уровень";
                        if (!Directory.Exists(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\")))
                        {
                            Directory.CreateDirectory(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\"));
                        }
                        File.Copy(openFileDialog.FileName, $"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}");
                        Image2.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}", UriKind.RelativeOrAbsolute));
                    }
                    catch {}
                }
            }
        }
        private void Image3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (modeEdit)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg; *.png)|*.jpg;*.png|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        string jsonRunners = File.ReadAllText("levels.json");
                        List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);
                        string name = (listLevel.Count + 1).ToString() + " Уровень";
                        if (!Directory.Exists(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\")))
                        {
                            Directory.CreateDirectory(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\"));
                        }
                        File.Copy(openFileDialog.FileName, $"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}");
                        Image3.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}", UriKind.RelativeOrAbsolute));
                    }
                    catch {}
                }
            }
        }
        private void Image4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (modeEdit)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg; *.png)|*.jpg;*.png|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        string jsonRunners = File.ReadAllText("levels.json");
                        List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);
                        string name = (listLevel.Count + 1).ToString() + " Уровень";
                        if (!Directory.Exists(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\")))
                        {
                            Directory.CreateDirectory(System.IO.Path.GetFullPath(name).Replace(@"\bin\Debug\net6.0-windows\", @"\Resource\GameImage\"));
                        }
                        File.Copy(openFileDialog.FileName, $"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}");
                        Image4.Source = new BitmapImage(new Uri($"{System.IO.Path.GetFullPath("Resource/GameImage/" + name + "/").Replace(@"\bin\Debug\net6.0-windows\", @"\")}{System.IO.Path.GetFileName(openFileDialog.FileName)}", UriKind.RelativeOrAbsolute));
                    }
                    catch {}
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!modeEdit)
            {
                string j = "";
                foreach (var item in letter)
                {
                    j += item.Text;
                }
                if (j == lvl.Word)
                {
                    string jsonRunners = File.ReadAllText("levels.json");
                    List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);
                    dialogHost.IsOpen = true;
                    if (listLevel[listLevel.Count-1].Name == lvl.Name)
                        wbNext.Visibility = Visibility.Collapsed;
                }
                    
            }
        }
        class LevelClass
        {
            public string? Name { get; set; }
            public List<string>? Image { get; set; }
            public string? Word { get; set; }
        }
        class User
        {
            public string? Name { get; set; }
            public int CountLvl { get; set; }
            public int Money { get; set; }
            public string Level { get; set; }
        }
        private void wdMenu_Click(object sender, RoutedEventArgs e)
        {
            string jsonLevels = File.ReadAllText("levels.json");
            List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonLevels);

            string jsonUsers = File.ReadAllText("users.json");
            List<User>? listUser = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            if (user.CountLvl != listLevel.Count+1 && int.Parse(lvl.Name.ToString().Substring(0,1)) == user.CountLvl)
            {
                for (int j = 0; j < listUser.Count; j++)
                    if (user.Name == listUser[j].Name)
                    {
                        user.CountLvl++;
                        listUser[j].CountLvl = user.CountLvl;
                        listUser[j].Money += 10;
                        user.Money += 10;
                        var mod = JsonConvert.SerializeObject(listUser, Formatting.Indented);
                        File.WriteAllText("users.json", mod);
                    }
            }
            this.NavigationService.Navigate(new MainPage());
        }

        private void wbNext_Click(object sender, RoutedEventArgs e)
        {
            string jsonLevels = File.ReadAllText("levels.json");
            List<LevelClass>? listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonLevels);

            string jsonUsers = File.ReadAllText("users.json");
            List<User>? listUser = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            for (int i = 0; i < listLevel.Count; i++)
            {
                if (lvl.Name == listLevel[i].Name)
                {
                    for (int j = 0; j < listUser.Count; j++)
                        if (user.Name == listUser[j].Name)
                        {
                            listUser[j].Money += 10;
                            user.CountLvl++;
                            listUser[j].CountLvl = user.CountLvl;
                            user.Money += 10;
                            var modifiedJson = JsonConvert.SerializeObject(listUser, Formatting.Indented);
                            File.WriteAllText("users.json", modifiedJson);
                            this.NavigationService.Navigate(new GamePage(listLevel[i + 1].Name, listLevel[i + 1].Image, listLevel[i + 1].Word, user.Name, user.CountLvl, user.Money));
                        }
                }
            }
        }
        List<int> l_list = new List<int>();
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            string jsonUsers = File.ReadAllText("users.json");
            List<User>? listUser = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            foreach (var item in listUser)
            {
                if (user.Name == item.Name && item.Money > 19)
                {
                    item.Money -= 20;
                    var modifiedJson = JsonConvert.SerializeObject(listUser, Formatting.Indented);
                    File.WriteAllText("users.json", modifiedJson);
                    this.DataContext = item;

                    Random random = new Random();
                    string j = "";
                    foreach (var i in letter)
                    {
                        j += i.Text;
                    }
                    int n = (lvl.Word.Length - j.Length) / 2;
                    for (int i = 0; i < n; i++)
                    {
                        int l = random.Next(lvl.Word.Length);
                        if (!l_list.Contains(l))
                        {
                            letter[l].Text = lvl.Word[l].ToString();
                            l_list.Add(l);
                        }
                        else
                            n++;
                    }
                }
            }
        }

        private void btnLevels_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LevelsPage(user.Name, user.CountLvl, user.Money));
        }
        
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            for (int i = letter.Count-1; i >= 0; i--)
            {
                if (letter[i].Text != "")
                {
                    letter[i].Text = "";
                    break;
                }
                else
                    continue;
            }
        }
    }
}