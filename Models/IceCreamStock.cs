using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Models
{
    public class IceCreamStock 
    {
        private int _id;
        public int Id { get; set; }

        private int _iceCream;
        public int IceCream
        { get; set; }

        private int _apple;
        public int Apple
        { get; set; }

        private int _banana;
        public int Banana
        { get; set; }

        public IceCreamStock(int id, int iceCream, int apple, int banana)
        {
            Id = id;
            IceCream = iceCream;
            Apple = apple;
            Banana = banana;
        }

        public IceCreamStock()
        {
        }
    }
}
