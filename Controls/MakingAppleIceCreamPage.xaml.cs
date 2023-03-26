using IceCream.dao;
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
    /// MakingAppleIceCreamPage.xaml.xaml 的交互逻辑
    /// </summary>
    public partial class MakingAppleIceCreamPage : Page
    {

        public MakingAppleIceCreamPage()
        {
            InitializeComponent();
        }

        public string Tip
        {
            get
            {
                return Text1.Text;
            }
            set
            {
                Text1.Text = value;
            }
        }

        public bool Enable
        {
            get
            {
                return makingButton.IsEnabled;
            }
            set
            {
                makingButton.IsEnabled = value;
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            makingButton.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bgk = new BackgroundWorker();
            Enable = false;
            bgk.DoWork += BGWorker_DoWork;
            bgk.WorkerReportsProgress = true;
            bgk.ProgressChanged += new ProgressChangedEventHandler(_backgroundWorker_ProgressChanged);
            bgk.RunWorkerCompleted += worker_RunWorkerCompleted;
            bgk.RunWorkerAsync();
            //this.BGWorker_DoWork(sender,new DoWorkEventArgs(this));
        }

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Tip = e.UserState.ToString();
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string tip;
                BackgroundWorker? backgroundWorker = (sender as BackgroundWorker);
                // 查询库存
                Models.IceCreamStock? iceCreamStock = DaoRepository.GetTheStock();
                // 如果库存充足 减少库存 加锁
                if (iceCreamStock != null && iceCreamStock.IceCream > 0 && iceCreamStock.Apple > 0 && iceCreamStock.Banana > 0)
                {
                    DaoRepository.updateTheStockMakeOne();
                    tip = "准备";
                    backgroundWorker.ReportProgress(0, tip);
                }
                // 库存不足 报错
                else
                {
                    tip = "库存不足 无法制作 请补充库存";
                    backgroundWorker.ReportProgress(0, tip);
                }
                // 开始制作
                Thread.Sleep(5000);
                tip = tip + "->" + "加草莓完成";
                backgroundWorker.ReportProgress(0, tip);
                Thread.Sleep(5000);
                tip = tip + "->" + "加巧克力完成";
                backgroundWorker.ReportProgress(0, tip);
                Thread.Sleep(5000);
                tip = tip + "->" + "加冰激凌完成";
                backgroundWorker.ReportProgress(0, tip);
                // 制作完成
                tip = tip + "->制作完成";
                backgroundWorker.ReportProgress(0, tip);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
