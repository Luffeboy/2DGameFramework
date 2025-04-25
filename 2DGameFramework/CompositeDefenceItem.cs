using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class CompositeDefenceItem : IDefenceItem
    {
        private List<IDefenceItem> _defenceItems = new List<IDefenceItem>();

        /// <summary>
        /// Adds an IDefenceItem to a list of IDefenceItems
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <returns>This</returns>
        public IDefenceItem AddIDefenceItem(IDefenceItem item)
        {
            if (item == null || item == this) // either of these two senarios should cause a crash, if added to the list
                return this;
            _defenceItems.Add(item);
            return this;
        }
        /// <summary>
        /// The sum of name of all IDefenceItems added to this
        /// </summary>
        /// <returns></returns>
        public string Name()
        {
            if (_defenceItems.Count == 0)
                return "...";
            string name = "";
            foreach (string individualName in _defenceItems.Select(a => a.Name()))
                name += individualName + " ";
            return name;
        }
        /// <summary>
        /// Return the sum of ReduceHitPoints of all IDefenceItems added to this
        /// </summary>
        /// <returns></returns>
        public int ReduceHitPoints()
        {
            return _defenceItems.Count == 0 ? 0 : _defenceItems.Sum(di => di.ReduceHitPoints());
        }
    }
}
