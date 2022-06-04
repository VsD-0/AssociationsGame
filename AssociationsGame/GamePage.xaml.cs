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

namespace AssociationsGame
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        bool modeEdit = false;
        List<TextBoxClass> letter = new List<TextBoxClass>();
        public GamePage()
        {
            InitializeComponent();

            for (int i = 0; i < 6; i++)
            {
                TextBoxClass tbc = new TextBoxClass();
                letter.Add(tbc);
            }
            
            Letters.ItemsSource = letter;
        }
        public GamePage(bool edit)
        {
            InitializeComponent();
            modeEdit = edit;
            checkbtn.Content = "Сохранить";
        }
        private void checkbtn_Click(object sender, RoutedEventArgs e)
        {
            if (modeEdit)
            {
                string j = "";
                foreach (var item in letter)
                {
                    j += item.TbContent;
                }
                MessageBox.Show(j);
            }
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
    }
    public class TextBoxClass
    {
        public string TbContent { get; set; }
        public string ImgOne { get; set; }
        public string ImgTwo { get; set; }
        public string ImgThree { get; set; }
        public string Answer { get; set; }
    }
}