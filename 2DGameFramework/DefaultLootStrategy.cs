using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class DefaultLootStrategy : ILootStrategy
    {
        public void Loot(Creature creature, WorldObject obj)
        {
            Logger.Instance.Log(creature.Name() + " is looting: " + obj.Name(), System.Diagnostics.TraceEventType.Information);
            for (int i = 0; i < obj.AttackItems.Count; i++)
            {
                var item = obj.AttackItems[i];
                creature.AddAttackItem(item);
            }

            for (int i = 0; i < obj.DefenceItems.Count; i++)
            {
                var item = obj.DefenceItems[i];
                creature.AddDefenceItem(item);
            }

            obj.Consume();
        }
    }
}
