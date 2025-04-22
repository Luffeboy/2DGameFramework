using _2DGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest
{
    internal class PlayerCreature : Creature
    {
        public PlayerCreature(Vector2 position, World world, ILootStrategy lootStrategy = null) : base(position, world, lootStrategy)
        {
            HitPoints = 100;
        }

        public override void Update()
        {
            Vector2 dir = new Vector2();
            Console.WriteLine("");
            Console.WriteLine("Write \"W\" to move up, \"S\" to move down, \"D\" to move right, \"A\" to move Left, ");
            char dirKey = Console.ReadKey().KeyChar;

            switch (dirKey)
            {
                case 'd': case 'D': dir.x = 1; break;
                case 'a': case 'A': dir.x = -1; break;
                case 's': case 'S': dir.y = 1; break;
                case 'w': case 'W': dir.y = -1; break;
            }

            // check if there is something at the new location
            var entity = MyWorld().GetEntity(Position + dir);
            bool willMove = true;
            if (entity != null && entity != this)
            {
                willMove = false;
                if (entity is Creature c)
                {
                    HitCreature(c);
                }
                else if (entity is WorldObject wo)
                {
                    TryLoot(wo);
                }
                // if we defeated the enemy/looted the item, we can still move
                if (MyWorld().GetEntity(Position + dir) == null)
                    willMove = true;
            }
            // if not, move to it
            if (willMove)
            {
                Move(dir);
                Logger.Instance.Log(this.Name() + " is now at: " + Position, System.Diagnostics.TraceEventType.Verbose);
            }
        }
    }
}
