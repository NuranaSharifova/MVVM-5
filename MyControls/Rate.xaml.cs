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

namespace WpfApp5.MyControls
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        private List<CheckBox> rbList;
        private List<SolidColorBrush> brushes;
        public Rate()
        {
            InitializeComponent();
            brushes = new List<SolidColorBrush>()
            {

             Brushes.Red,Brushes.Yellow,Brushes.Green
            };
            rbList = new List<CheckBox>()
            {
             Rb1, Rb2, Rb3
            };
        }

        private void Rb1_MouseEnter(object sender, MouseEventArgs e)
        {
           CheckBox selectedRb = sender as CheckBox;
            int selectedIndex = Convert.ToInt32(selectedRb.Name[selectedRb.Name.Length-1].ToString());
            for (int i = 0; i < selectedIndex; i++)
            {
                rbList[i].Background = brushes[i];
            }
          }

        private void Rb1_MouseLeave(object sender, MouseEventArgs e)
        {
           
            for (int i = 0; i < rbList.Count; i++)
            {
                if (rbList[i].IsChecked == false)
                {
                    rbList[i].Background = Brushes.White;
                }
            }
        }

        private void Rb1_Click(object sender, RoutedEventArgs e)
        {
           CheckBox selectedRb = sender as CheckBox;
            int selectedIndex = Convert.ToInt32(selectedRb.Name[selectedRb.Name.Length - 1].ToString());

            for (int i = 0; i < selectedIndex - 1; i++)
            {
                rbList[i].IsChecked = true;
                rbList[i].Background = brushes[i];
            }
            rbList[selectedIndex - 1].Background = brushes[selectedIndex - 1];
            for (int i = selectedIndex; i < rbList.Count; i++)
            {
                rbList[i].IsChecked = false;
                rbList[i].Background = Brushes.White;
            }
        }
    }
}
