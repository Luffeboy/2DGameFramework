using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public interface ILootStrategy
    {
        /// <summary>
        /// How a Creature should interace with a WorldObject, when trying to loot it
        /// </summary>
        /// <param name="creature">The creature looting</param>
        /// <param name="obj">The WorldObject being looted</param>
        public void Loot(Creature creature, WorldObject obj);
    }
}
