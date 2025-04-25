using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class WorldObject : Entity, INamed
    {
        public string MyName { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
        public List<IAttackItem> AttackItems { get; set; } = new List<IAttackItem>();
        public List<IDefenceItem> DefenceItems { get; set; } = new List<IDefenceItem>();
        public WorldObject(Vector2 position, World world) : base(position, world)
        {
            PositionIsFixed = true;
            world.AddWorldObject(this);
        }

        /// <summary>
        /// When a creature loots this world object, it consumes it (usually removing it from the grid)
        /// </summary>
        /// <param name="creature">the creature consuming it</param>
        public virtual void Consume(Creature? creature = null)
        {
            if (Removeable)
                RemoveEntity();
        }
        /// <summary>
        /// Returns the name of this WorldObject
        /// </summary>
        /// <returns>MyName</returns>
        public string Name()
        {
            return MyName;
        }
    }
}
