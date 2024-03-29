﻿using System;
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
        List<Button> btnL = new List<Button>();
        public LevelsPage()
        {
            InitializeComponent();

            string jsonLevels = File.ReadAllText("levels.json");
            List<LevelClass> listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonLevels);
            if (listLevel != null)
                for (int i = 0; i < listLevel.Count; i++)
                {
                    Button btn = new Button();
                    btn.Content = (i+1).ToString() + " Уровень";
                    
                    btnL.Add(btn);
                    stackpanel.Children.Add(btn);
                }
            Button btnAdd = new Button();
            btnAdd.Content = "+";
            btnL.Add(btnAdd);

            stackpanel.Children.Add(btnAdd);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string jsonLevels = File.ReadAllText("levels.json");
            List<LevelClass> listLevel = JsonConvert.DeserializeObject<List<LevelClass>>(jsonLevels);
            if (e.Source.ToString()[e.Source.ToString().Length - 1] == '+')
                this.NavigationService.Navigate(new GamePage(true));
            else
            {
                foreach (var item in listLevel)
                {
                    if (e.Source.ToString().Substring(32) == item.Name)
                        this.NavigationService.Navigate(new GamePage(item.Name, item.Image, item.Word));
                }
            }
        }
    }
    public class LevelClass
    {
        public string Name { get; set; }
        public List<string> Image { get; set; }
        public string Word { get; set; }
    }
}
