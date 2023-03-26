using IceCream.config;
using IceCream.Models;
using IceCream.VIewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IceCream.dao
{
    public class DaoRepository
    {
        private static object _Lock = new object();
        public static IceCreamStock? GetTheStock()
        {
            using (var ctx = new DataContext())
            {
                foreach (var item in ctx.iceCreamStocks)
                {
                    StockViewModel stockViewModel = StockViewModel.Single();
                    stockViewModel.iceCreamStock = item;
                    return item;
                }
            }
            return null;
        }

        public static IceCreamStock? Init()
        {
            using (var ctx = new DataContext())
            {
                foreach (var item in ctx.iceCreamStocks)
                {
                    return item;
                }
            }
            return null;
        }

        public static void updateTheStockMakeOne()
        {
            lock (_Lock)
            {
                using (var ctx = new DataContext())
                {
                    foreach (var item in ctx.iceCreamStocks)
                    {
                        item.Apple = item.Apple - 1;
                        item.IceCream = item.IceCream - 1;
                        item.Banana = item.Banana - 1;
                        ctx.SaveChanges();
                        StockViewModel stockViewModel = StockViewModel.Single();
                        stockViewModel.iceCreamStock = item;
                    }
                }
            }
        }

        public static void updateTheStockNum(int num)
        {
            lock (_Lock)
            {
                int i = 0;
                using (var ctx = new DataContext())
                {
                    StockViewModel stockViewModel = StockViewModel.Single();
                    foreach (var item in ctx.iceCreamStocks)
                    {
                        if (item.Apple != 100)
                        {
                            item.Apple = 100;
                            Thread.Sleep(5000);
                            ctx.SaveChanges(); stockViewModel.iceCreamStock = item;
                        }
                        if (item.IceCream != 100)
                        {
                            item.IceCream = 100;
                            Thread.Sleep(5000);
                            ctx.SaveChanges(); stockViewModel.iceCreamStock = item;
                        }
                        if (item.Banana != 100)
                        {
                            item.Banana = 100;
                            Thread.Sleep(5000);
                            ctx.SaveChanges(); stockViewModel.iceCreamStock = item;
                        }
                    }
                }
            }
        }
    }
}
