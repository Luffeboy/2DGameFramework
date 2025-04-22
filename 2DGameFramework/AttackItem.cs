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

        public IAttackItem AddIAttackItem(IAttackItem item)
        {
            if (item == null)
                return this;
            return (item.Hit() > Hit()) ? item : this;
        }
        public int Hit()
        {
            return HitValue;
        }

        public string Name()
        {
            return NameValue;
        }

        public void PickUp(Creature creature)
        {
        }

        public int Range()
        {
            return RangeValue;
        }

    }
}
