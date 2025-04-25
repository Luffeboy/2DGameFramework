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

            MoveOrAttackOrInteract(dir);
        }
    }
}
