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
                tbc.TbId = i.ToString();
                letter.Add(tbc);
            }
            
            Letters.ItemsSource = letter;
            string a = letter[0].TbId;
            string b = letter[0].TbContent;
        }



        private void textBoxLetter_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string c = e.Changes.ToString();
            //string a = letter[0].TbId;
            //string b = letter[0].TbContent;
        }

        private void textBoxLetter_KeyDown(object sender, KeyEventArgs e)
        {
            string[] eng = {"F", "OemComma", "C", "U", "L", "T", "Oem3", "Oem1", "P", "B", "Q", "R", "K",
                        "V", "Y", "J", "G", "H", "C", "N", "E", "A", "OemOpenBrackets", "W", "X", "I",
                        "O", "Oem6", "S", "M", "OemQuotes", "OemPeriod", "Z"};
            string[] rus = {"А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л",
                        "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш",
                        "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я"};
            string k = e.Key.ToString();
            string a = letter[0].TbId;
            string b = letter[0].TbContent;
            string j = "";
            foreach (var item in letter)
            {
                j += item.TbContent;
            }
            MessageBox.Show(j);
        }
    }
    public class TextBoxClass
    {
        public string TbContent { get; set; }
        public string TbId { get; set; }
    }
}
