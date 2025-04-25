using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class AttackItemDecorator : IAttackItem
    {
        private IAttackItem? _attackItem;
        protected Creature _creature;
        public string NameValue { get; set; }


        public IAttackItem AddIAttackItem(IAttackItem item)
        {
            if (item == null || item == this)
                return this;
            if (_attackItem != null)
                _attackItem = _attackItem.AddIAttackItem(item);
            return this;
        }
        /// <summary>
        /// When the creature is low on health, it will deal less damage
        /// </summary>
        /// <returns></returns>
        public int Hit()
        {
            if (_attackItem == null)
                return 1;
            int damage = _attackItem.Hit();
            if (_creature != null && _creature.HitPoints < 5)
                damage /= 2;
            return damage;
        }

        public string Name()
        {
            return NameValue;
        }

        public void PickUp(Creature creature)
        {
            _creature = creature;
        }

        public int Range()
        {
            if (_attackItem == null)
                return 1;
            return _attackItem.Range();
        }

        public void LayDown()
        {
            _creature = null;
        }
    }
}
