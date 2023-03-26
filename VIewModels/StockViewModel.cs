using IceCream.dao;
using IceCream.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.VIewModels
{
    public class StockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        public void Notify(string param)
        {
            if (PropertyChanged != null)//有改变
            {
                PropertyChanged(this, new PropertyChangedEventArgs(param));//对Banana进行监听
            }
        }

        private IceCreamStock _iceCreamStock;

        public IceCreamStock iceCreamStock
        {
            get { return _iceCreamStock; }
            set
            {
                _iceCreamStock = value;
                Notify("iceCreamStock");
            }
        }
        private static volatile StockViewModel _instance = null;
        private static object Singleton_Lock = new object();

        private StockViewModel()
        {
            iceCreamStock = DaoRepository.Init();
        }

        public static StockViewModel Single()
        {
            if (_instance == null)
            {
                lock (Singleton_Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new StockViewModel();
                    }
                }
            }
            return _instance;
        }
    }
}
