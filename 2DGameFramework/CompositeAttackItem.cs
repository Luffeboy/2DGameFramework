using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class CompositeAttackItem : IAttackItem
    {
        private List<IAttackItem> _attackItems = new List<IAttackItem>();
        public IAttackItem AddIAttackItem(IAttackItem item)
        {
            if (item == null || item == this) // either of these two senarios should cause a crash, if added to the list
                return this;
            _attackItems.Add(item);
            return this;
        }

        public int Hit()
        {
            return _attackItems.Count == 0 ? 0 : _attackItems.Sum(a => a.Hit());
        }

        public string Name()
        {
            if (_attackItems.Count == 0)
                return "...";
            string name = "";
            foreach (string individualName in _attackItems.Select(a => a.Name()))
                name += individualName + " ";
            return name;
        }

        public void PickUp(Creature creature)
        {
        }

        public int Range()
        {
            if (_attackItems.Count == 0)
                return 0;
            return (int)Math.Ceiling(_attackItems.Average(a => a.Range()));
        }
    }
}
