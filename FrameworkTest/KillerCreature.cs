using _2DGameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest
{
    internal class KillerCreature : Creature
    {
        List<Vector2> visitedLocations = new List<Vector2>();
        public KillerCreature(Vector2 position, World world, ILootStrategy lootStrategy = null) : base(position, world, lootStrategy)
        {
            MyName = "Killer";
            HitPoints = 25;
            DefaultDamage = 5;
        }

        public override void Update()
        {
            // find nearest other Creature or world object
            List<Vector2> othersPositions = new List<Vector2>();
            World world = MyWorld();
            for (int x = 0; x < world.WorldSize.x; x++)
            {
                for (int y = 0; y < world.WorldSize.y; y++)
                {
                    if (x == Position.x && y == Position.y)
                        continue;
                    if (world.EntityGrid[x, y] != null && !visitedLocations.Contains(new Vector2(x, y)))
                        othersPositions.Add(new Vector2(x, y));
                }
            }
            // find closest, if there are any
            if (othersPositions.Count == 0)
                return;
            Entity closest = world.EntityGrid[othersPositions[0].x, othersPositions[0].y];
            int closestDist = (othersPositions[0] - Position).LengthSqr();
            for (int i = 1; i < othersPositions.Count; i++)
            {
                int dist = (othersPositions[i] - Position).LengthSqr();
                if (dist < closestDist)
                {
                    closest = world.EntityGrid[othersPositions[i].x, othersPositions[i].y];
                    closestDist = dist;
                }
            }
            // move towards them
            Vector2 dir = closest.Position - Position;
            if (Math.Abs(dir.x) > Math.Abs(dir.y))
            {
                dir.x = dir.x / Math.Abs(dir.x);
                dir.y = 0;
            } else
            {
                dir.y = dir.y / Math.Abs(dir.y);
                dir.x = 0;
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
                    visitedLocations.Add(wo.Position); // won't move to this again
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
