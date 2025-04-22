using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class DefenceItem : IDefenceItem
    {
        public string NameValue { get; set; }
        public int ReduceHitPointsValue { get; set; }

        public IDefenceItem AddIDefenceItem(IDefenceItem item)
        {
            if (item == null)
                return this;
            return (item.ReduceHitPoints() > ReduceHitPoints()) ? item : this;
            
        }

        public string Name()
        {
            return NameValue;
        }

        public int ReduceHitPoints()
        {
            return ReduceHitPointsValue;
        }
    }
}
