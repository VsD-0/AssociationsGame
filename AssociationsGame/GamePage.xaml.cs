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
        public GamePage(string name, List<string> image, string word)
        {
            InitializeComponent();

            lvl.Image = image;
            lvl.Name = name;
            lvl.Word = word;

            Image1.Source = new BitmapImage(new Uri(lvl.Image[0], UriKind.RelativeOrAbsolute));
            Image2.Source = new BitmapImage(new Uri(lvl.Image[1], UriKind.RelativeOrAbsolute));
            Image3.Source = new BitmapImage(new Uri(lvl.Image[2], UriKind.RelativeOrAbsolute));
            Image4.Source = new BitmapImage(new Uri(lvl.Image[3], UriKind.RelativeOrAbsolute));

            for (int i = 0; i < lvl.Word.Length; i++)
            {
                TextBox tb = new TextBox();
                stackpanel.Children.Add(tb);
                tb.Width = 60;
                letter.Add(tb);
            }
        }
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
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string jsonRunners = File.ReadAllText("levels.json");
            List<LevelClass> listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);

            LevelClass lc = new LevelClass();

            lc.Image = new List<string> { Image1.Source.ToString(), Image2.Source.ToString(), Image3.Source.ToString(), Image4.Source.ToString()};
            lc.Word = letter[0].Text;

            lc.Name = (listLevel.Count + 1).ToString() + " Уровень";


            listLevel.Add(lc);
            var modifiedJson = JsonConvert.SerializeObject(listLevel, Formatting.Indented);
            File.WriteAllText("levels.json", modifiedJson);
            this.NavigationService.Navigate(new MainPage());
        }
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
                    Image1.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));
                    
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
                    Image2.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));
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
                    Image3.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));
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
                    Image4.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.RelativeOrAbsolute));
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
                    List<LevelClass> listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);
                    dialogHost.IsOpen = true;
                    if (listLevel[listLevel.Count-1].Name == lvl.Name)
                        wbNext.Visibility = Visibility.Collapsed;
                }
                    
            }
        }

        class LevelClass
        {
            public string Name { get; set; }
            public List<string> Image { get; set; }
            public string Word { get; set; }
        }

        private void wdMenu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void wbNext_Click(object sender, RoutedEventArgs e)
        {
            string jsonRunners = File.ReadAllText("levels.json");
            List<LevelClass> listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonRunners);
            for (int i = 0; i < listLevel.Count; i++)
            {
                if (lvl.Name == listLevel[i].Name)
                {
                    this.NavigationService.Navigate(new GamePage(listLevel[i+1].Name, listLevel[i+1].Image, listLevel[i+1].Word));
                }
            }
        }
    }
}