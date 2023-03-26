using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace IceCream.Controls
{
    /// <summary>
    /// MediumSizeButtons.xaml 的交互逻辑
    /// </summary>
    public partial class MediumSizeButtons : UserControl
    {

        public MediumSizeButtons()
        {
            InitializeComponent();
        }

        public ImageSource imageSource
        {
            get
            {
                return buttonImage.Source;
            }
            set
            {
                buttonImage.Source = value;
            }
        }
        public string text1
        {
            get { return Text1.Text; }

            set { Text1.Text = value; }
        }

        public string errorText1
        {
            get => ErrorText.Text;
            set { ErrorText.Text = value; }
        }

        public string Remaining
        {
            get
            {
                return GetValue(RemainingProperty) as string;
            }
            set
            {
                if (value != null)
                {
                    int v = int.Parse(value);//1
                    if (v < 10)
                    {
                        errorText1 = "!!余量不足10个 当前含量 " + v + " 请及时补充";
                    }
                    else
                    {
                        errorText1 = "";
                    }
                    SetValue(RemainingProperty, value);
                }
            }
        }

        // 当外部绑定后,数据变化时,界面更新
        public static readonly DependencyProperty RemainingProperty =
            DependencyProperty.Register("Remaining", typeof(string), typeof(MediumSizeButtons), new PropertyMetadata(null, (s, e) =>
            {
                ((MediumSizeButtons)s).Remaining = (string)e.NewValue;
            }));

        public string Mount
        {
            get
            {
                return GetValue(MountProperty) as string;
            }
            set
            {
                SetValue(MountProperty, value);
            }
        }

        // 当外部绑定后,数据变化时,界面更新
        public static readonly DependencyProperty MountProperty =
            DependencyProperty.Register("Mount", typeof(string), typeof(MediumSizeButtons), new PropertyMetadata(null, (s, e) =>
            {
                ((MediumSizeButtons)s).Mount = (string)e.NewValue;
            }));
    }
}
