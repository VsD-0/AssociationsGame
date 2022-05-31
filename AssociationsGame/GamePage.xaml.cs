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

namespace AssociationsGame
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        List<TextBoxClass> letter = new List<TextBoxClass>();
        public GamePage()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                TextBoxClass tbc = new TextBoxClass();
                letter.Add(tbc);
            }
            
            Users.ItemsSource = letter;
        }

        private void textBoxLetter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string word;
            foreach (var item in letter)
            {
                word += item.TbContent
            }
        }
    }
    public class TextBoxClass
    {
        public string TbContent { get; set; }
    }
}
