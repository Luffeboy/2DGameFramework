using _2DGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest
{
    public class ConcreteCreature : Creature
    {
        Random random = new Random();
        public ConcreteCreature(Vector2 position, World world) : base(position, world)
        {
            MyName = random.Next(100).ToString();
            HitPoints = 10;
        }

        public override void Update()
        {
            Vector2 dir = new Vector2();
            int dirInt = random.Next(4);
            switch (dirInt)
            {
                case 0: dir.x = 1; break;
                case 1: dir.x = -1; break;
                case 2: dir.y = 1; break;
                case 3: dir.y = -1; break;
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
