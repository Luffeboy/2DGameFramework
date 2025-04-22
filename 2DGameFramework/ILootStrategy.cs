using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public interface ILootStrategy
    {
        public void Loot(Creature creature, WorldObject obj);
    }
}
