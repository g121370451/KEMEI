using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream.Models
{
    public class MakingInfo
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}


		private string type;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		private string isFinished;

		public string IsFinished
		{
			get { return isFinished; }
			set { isFinished = value; }
		}

		private string createTime;

		public string CreateTime
		{
			get { return createTime; }
			set { createTime = value; }
		}

		private string desc;

		public string Desc
		{
			get { return desc; }
			set { desc = value; }
		}
	}
}
