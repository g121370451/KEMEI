using IceCream.Controls;
using IceCream.dao;
using IceCream.Models;
using log4net;
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

namespace IceCream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainWindow));
        private static readonly Page showStock = new ShowStock();
        private static readonly Page makingChocolateIceCreamPage = new MakingChocolateIceCreamPage();
        private static readonly Page makingAppleIceCreamPage = new MakingAppleIceCreamPage();

        public MainWindow()
        {
            InitializeComponent();
            ShowPageChanged.Content = new Frame()
            {
                Content = showStock
            };
        }

        private string _currentType;

        public string CurrentType
        {
            get { return _currentType; }
            set { _currentType = value; }
        }


        private void StackPanel_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = e.OriginalSource as RadioButton;
            string selectMode = radioButton.Name;
            if (!string.IsNullOrEmpty(selectMode))
            {
                CurrentType = selectMode;
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            log.Info("进入添加材料的逻辑");

        }

        private void make_Click(object sender, RoutedEventArgs e)
        {
            log.Info("进入制作的逻辑");
        }


        private void Click_Second_Menu_Button(object sender, RoutedEventArgs e)
        {
            ShowPageChanged.Content = new Frame()
            {
                Content = makingChocolateIceCreamPage
            };
        }

        private void Click_First_Menu_Button(object sender, RoutedEventArgs e)
        {
            ShowPageChanged.Content = new Frame()
            {
                Content = showStock
            };
        }

        private void Click_Third_Menu_Button(object sender, RoutedEventArgs e)
        {
            ShowPageChanged.Content = new Frame()
            {
                Content = makingAppleIceCreamPage
            };
        }
    }
}
