using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostingCalculator
{
    public class RankInfo
    {
		private string rankName;
		private double rankPrice;

		public double RankPrice
		{
			get { return rankPrice; }
			set { rankPrice = value; }
		}

		public string RankName
		{
			get { return rankName; }
			set { rankName = value; }
		}

        public RankInfo(string rankName, double rankPrice)
        {
            this.rankName = rankName;
			this.rankPrice = rankPrice;
        }

    }
}
