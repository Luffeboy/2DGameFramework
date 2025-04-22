using _2DGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest
{
    public class UnableToLootStrategy : ILootStrategy
    {
        /// <summary>
        /// Creatures using this strategy, won't be able to loot anything
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="obj"></param>
        public void Loot(Creature creature, WorldObject obj)
        {
        }
    }
}
