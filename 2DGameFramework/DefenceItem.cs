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
        /// <summary>
        /// Returns this, or the IDefenceItem, whichever has the greater ReduceHitPoints() value
        /// </summary>
        /// <param name="item"></param>
        /// <returns>This or item</returns>
        public IDefenceItem AddIDefenceItem(IDefenceItem item)
        {
            if (item == null)
                return this;
            return (item.ReduceHitPoints() > ReduceHitPoints()) ? item : this;
            
        }
        /// <summary>
        /// Returns NameValue
        /// </summary>
        /// <returns>NameValue</returns>
        public string Name()
        {
            return NameValue;
        }
        /// <summary>
        /// Returns ReduceHitPointsValue
        /// </summary>
        /// <returns>ReduceHitPointsValue</returns>

        public int ReduceHitPoints()
        {
            return ReduceHitPointsValue;
        }
    }
}
