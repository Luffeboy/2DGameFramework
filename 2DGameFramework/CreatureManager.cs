using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameFramework
{
    public class CreatureManager
    {
        private World _world;
        public List<Creature> Creatures {  get; private set; } = new List<Creature>();
        public CreatureManager(World world)
        { 
            _world = world; 
        }
        /// <summary>
        /// Adds a creature to this creature manager, and adds an observer, to check if the creature is dead, 
        /// and when they are, they get removed from the world.
        /// </summary>
        /// <param name="creature"></param>
        public void AddCreature(Creature creature)
        {
            creature.PropertyChanged += RemoveCreature;
            Creatures.Add(creature);
        }

        private void RemoveCreature(object? sender, PropertyChangedEventArgs e)
        {
            if (sender == null || e.PropertyName != nameof(Creature.HitPoints)) 
                return;
            Creature creature = (Creature)sender;
            if (creature.IsAlive)
                return;
            Creatures.Remove(creature);
            Vector2 creaturePos = creature.Position;
            if (creaturePos.x >= 0 && creaturePos.x < _world.WorldSize.x && 
                creaturePos.y >= 0 && creaturePos.y < _world.WorldSize.y)
                _world.EntityGrid[creature.Position.x, creature.Position.y] = null;
            creature.PropertyChanged -= RemoveCreature;
            Logger.Instance.Log("CreatureManager: removing creature: " + creature.Name(), System.Diagnostics.TraceEventType.Information);
        }
        /// <summary>
        /// Calls the Update function, on all creatures this manages
        /// </summary>
        public void UpdateCreatures()
        {

            for (int i = 0; i < Creatures.Count; i++)
            {
                Creatures[i].Update();
            }
        }
    }
}
