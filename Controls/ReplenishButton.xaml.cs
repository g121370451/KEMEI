using IceCream.dao;
using IceCream.VIewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace IceCream.Controls
{
    /// <summary>
    /// ReplenishButton.xaml 的交互逻辑
    /// </summary>
    public partial class ReplenishButton : UserControl
    {
        public ReplenishButton()
        {
            InitializeComponent();
        }

        public string text1
        {
            get { return Text1.Text; }

            set { Text1.Text = value; }
        }

        public string type { get; set; }

        public string RemainingProcessOn
        {
            get
            {
                return GetValue(RemainingProcessOnProperty) as string;
            }
            set
            {
                SetValue(RemainingProcessOnProperty, value);
            }
        }

        // 当外部绑定后,数据变化时,界面更新
        public static readonly DependencyProperty RemainingProcessOnProperty =
            DependencyProperty.Register("RemainingProcessOn", typeof(string), typeof(ReplenishButton), new PropertyMetadata(null, (s, e) =>
            {
                ((ReplenishButton)s).RemainingProcessOn = (string)e.NewValue;
            }));

        public string MountProcessOn
        {
            get
            {
                return GetValue(MountProcessOnProperty) as string;
            }
            set
            {
                SetValue(MountProcessOnProperty, value);
            }
        }

        // 当外部绑定后,数据变化时,界面更新
        public static readonly DependencyProperty MountProcessOnProperty =
            DependencyProperty.Register("MountProcessOn", typeof(string), typeof(ReplenishButton), new PropertyMetadata(null, (s, e) =>
            {
                ((ReplenishButton)s).MountProcessOn = (string)e.NewValue;
            }));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            enable.IsEnabled = false;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += BGWorker_DoWork;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.RunWorkerAsync();
        }

        private void Bgw_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
           enable.IsEnabled=true;
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Console.WriteLine("进入更新数据库的逻辑");
                BackgroundWorker? backgroundWorker = (sender as BackgroundWorker);
                DaoRepository.updateTheStockNum(0);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
