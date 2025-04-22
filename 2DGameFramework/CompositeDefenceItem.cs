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
        public IDefenceItem AddIDefenceItem(IDefenceItem item)
        {
            if (item == null || item == this) // either of these two senarios should cause a crash, if added to the list
                return this;
            _defenceItems.Add(item);
            return this;
        }

        public string Name()
        {
            if (_defenceItems.Count == 0)
                return "...";
            string name = "";
            foreach (string individualName in _defenceItems.Select(a => a.Name()))
                name += individualName + " ";
            return name;
        }

        public int ReduceHitPoints()
        {
            return _defenceItems.Count == 0 ? 0 : _defenceItems.Sum(di => di.ReduceHitPoints());
        }
    }
}
