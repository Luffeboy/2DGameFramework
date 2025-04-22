using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public interface IAttackItem : INamed
    {
        /// <summary>
        /// Return the damage this item does
        /// </summary>
        /// <returns></returns>
        int Hit();
        /// <summary>
        /// Returns the range of the item
        /// </summary>
        /// <returns></returns>
        int Range();
        /// <summary>
        /// Returns the IAttackItem, that results in adding an IAttackItem to this
        /// </summary>
        /// <param name="item">The IAttackItem to add</param>
        /// <returns></returns>
        IAttackItem AddIAttackItem(IAttackItem item);
        /// <summary>
        /// When a creature picks up an item, this method is called, with that creature as a parameter
        /// </summary>
        /// <param name="creature"></param>
        void PickUp(Creature creature);

        /// <summary>
        /// When a creature puts this item down.
        /// </summary>
        void LayDown();
    }
}
