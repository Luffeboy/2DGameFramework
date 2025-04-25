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
        public ConcreteCreature(Vector2 position, World world, ILootStrategy? lootStrategy = null) : base(position, world, lootStrategy)
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
            
            MoveOrAttackOrInteract(dir);
        }
    }
}
