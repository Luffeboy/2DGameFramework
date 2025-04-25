using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    // Liskov Substitution Principle
    public class AttackItem : IAttackItem
    {
        public string NameValue { get; set; }
        public int HitValue {  get; set; }
        public int RangeValue {  get; set; }
        /// <summary>
        /// Returns this, or the IAttackItem, whichever has the greater Hit() value
        /// </summary>
        /// <param name="item"></param>
        /// <returns>This or item</returns>
        public IAttackItem AddIAttackItem(IAttackItem item)
        {
            if (item == null)
                return this;
            return (item.Hit() > Hit()) ? item : this;
        }
        /// <summary>
        /// Return HirValue
        /// </summary>
        /// <returns></returns>
        public int Hit()
        {
            return HitValue;
        }
        /// <summary>
        /// Does nothing
        /// </summary>
        public void LayDown()
        {
        }
        /// <summary>
        /// Returns NameValue
        /// </summary>
        /// <returns></returns>

        public string Name()
        {
            return NameValue;
        }
        /// <summary>
        /// Does nothing
        /// </summary>
        /// <param name="creature"></param>
        public void PickUp(Creature creature)
        {
        }
        /// <summary>
        /// Returns RangeValue
        /// </summary>
        /// <returns></returns>
        public int Range()
        {
            return RangeValue;
        }

    }
}
