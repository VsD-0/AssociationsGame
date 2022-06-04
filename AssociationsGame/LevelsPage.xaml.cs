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

namespace AssociationsGame
{
    /// <summary>
    /// Логика взаимодействия для LevelsPage.xaml
    /// </summary>
    public partial class LevelsPage : Page
    {
        List<ButtonClass> btnL = new List<ButtonClass>();
        public LevelsPage()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                ButtonClass btn = new ButtonClass();
                btn.btnContent = (i+1).ToString() + " Уровень";
                btnL.Add(btn);
                btnListView.Items.Add(btn);
            }
            ButtonClass btnAdd = new ButtonClass();
            btnAdd.btnContent = "+";
            btnL.Add(btnAdd);

            btnListView.Items.Add(btnAdd);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source.ToString()[e.Source.ToString().Length-1] == '+')
                this.NavigationService.Navigate(new GamePage(true));
            else
                this.NavigationService.Navigate(new GamePage());
        }
    }
    public class ButtonClass
    {
        public string btnContent { get; set; }
    }
}
