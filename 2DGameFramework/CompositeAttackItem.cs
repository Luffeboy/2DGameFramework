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

        /// <summary>
        /// Adds an IAttackItem to a list of IAttackItems
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <returns>This</returns>
        public IAttackItem AddIAttackItem(IAttackItem item)
        {
            if (item == null || item == this) // either of these two senarios should cause a crash, if added to the list
                return this;
            _attackItems.Add(item);
            return this;
        }
        /// <summary>
        /// Return the sum of Hit of all IAttackItems added to this
        /// </summary>
        /// <returns></returns>
        public int Hit()
        {
            return _attackItems.Count == 0 ? 0 : _attackItems.Sum(a => a.Hit());
        }
        /// <summary>
        /// calls LayDown on all IAttackItems added to this
        /// </summary>
        /// <param name="creature"></param>
        public void LayDown()
        {
            foreach (var attackItem in _attackItems)
                attackItem.LayDown();
        }
        /// <summary>
        /// The sum of name of all IAttackItems added to this
        /// </summary>
        /// <returns></returns>

        public string Name()
        {
            if (_attackItems.Count == 0)
                return "...";
            string name = "";
            foreach (string individualName in _attackItems.Select(a => a.Name()))
                name += individualName + " ";
            return name;
        }
        /// <summary>
        /// calls PickUp on all IAttackItems added to this
        /// </summary>
        /// <param name="creature"></param>
        public void PickUp(Creature creature)
        {
            foreach (var  attackItem in _attackItems)
                attackItem.PickUp(creature);
        }

        /// <summary>
        /// Return the average Range of all IAttackItems added to this
        /// </summary>
        /// <returns></returns>
        public int Range()
        {
            if (_attackItems.Count == 0)
                return 0;
            return (int)Math.Ceiling(_attackItems.Average(a => a.Range()));
        }
    }
}
