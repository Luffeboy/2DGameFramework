using System.ComponentModel;

namespace _2DGameFramework
{
    // Open for extention closed for modification
    public abstract class Creature : Entity, IUpdateable, INamed, INotifyPropertyChanged
    {
        private int _hitPoints;
        public string MyName { get; set; }
        public int HitPoints 
        { 
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                NotifyPropertyChanged(nameof(HitPoints));
            }
        }
        public bool IsAlive { get { return HitPoints > 0; } }
        public int DefaultDamage { get; protected set; } = 1;
        public int DefaultRange { get; protected set; } = 1;

        public event PropertyChangedEventHandler? PropertyChanged;
        public IAttackItem? MyAttackItem { get; private set; }
        public IDefenceItem? MyDefenceItem { get; private set; }
        public ILootStrategy MyLootStrategy { get; set; }
        /// <summary>
        /// When creating a creature, it need a position in the world, the wold it is connected to.
        /// As well as a starting "loot strategy".
        /// </summary>
        /// <param name="position">the position it start at</param>
        /// <param name="world">the world it is in</param>
        /// <param name="lootStrategy">It's starting loot strategy</param>
        public Creature(Vector2 position, World world, ILootStrategy lootStrategy = null) : base(position, world)
        {
            if (lootStrategy == null)
                lootStrategy = new DefaultLootStrategy();
            MyLootStrategy = lootStrategy;
            world.AddCreature(this);
        }


        /// <summary>
        /// Trys to hit another creature, if it is not in range, it will return and do nothing
        /// If it is in range, it will call "ReceiveHit" on the other creature
        /// </summary>
        /// <param name="other">Creature it is trying to hit</param>
        public void HitCreature(Creature other)
        {
            int damage = Hit();

            int distance = (other.Position - Position).LengthSqr();
            if (MyAttackItem != null)
            {
                if (distance > MyAttackItem.Range() * MyAttackItem.Range())
                    return;
            }
            else if (distance > DefaultRange * DefaultRange)
                return;

            other.ReceiveHit(damage);
        }
        /// <summary>
        /// Gets the damage, this creature deals
        /// </summary>
        /// <returns>The amount of damage this creature deals</returns>
        public int Hit()
        {
            if (MyAttackItem != null)
            {
                int damage = Math.Max(MyAttackItem.Hit(), 1); // minimum 1 damage
                string weaponName = MyAttackItem.Name();
                Logger.Instance.Log($"{Name()} is attacking with {weaponName} to deal {damage} damage", System.Diagnostics.TraceEventType.Verbose);
                return damage;

            }
            int baseDamage = DefaultDamage;
            Logger.Instance.Log($"{Name()} is attacking with bare hands to deal {baseDamage} damage", System.Diagnostics.TraceEventType.Verbose);
            return baseDamage;
        }
        /// <summary>
        /// Make this create take damage, equal to hit -  MyDefenceItem.ReduceHitPoints
        /// If the creature get to or below 0 HitPoints, it dies
        /// </summary>
        /// <param name="hit">The amount of damage the creature should take, before any additional effects from DefenceItem</param>
        public void ReceiveHit(int hit) 
        {
            if (MyDefenceItem != null)
                hit -= MyDefenceItem.ReduceHitPoints();
            // a creature should not be able to heal, when taking a hit
            if (hit < 0) 
                hit = 0;
            HitPoints -= hit;
            Logger.Instance.Log($"{Name()} took {hit} damage", System.Diagnostics.TraceEventType.Verbose);
            if (!IsAlive)
                Die();
        }
        /// <summary>
        /// The creature died, and is promptly removed from the game
        /// </summary>
        private void Die()
        {
            Logger.Instance.Log($"{Name()} died", System.Diagnostics.TraceEventType.Information);
        }
        /// <summary>
        /// checks if the object the creature are trying to loot is close enough to the creature, for it to be looted
        /// </summary>
        /// <param name="obj">object to loot</param>
        /// <param name="maxDist">max allowed distance to object, to still allow it to be picked up</param>
        public void TryLoot(WorldObject obj, int maxDist = 1)
        {
            Vector2 diff = obj.Position - Position;
            int diffAsInt = Math.Abs(diff.x) + Math.Abs(diff.y);
            if (diffAsInt > maxDist)
                return;
            Loot(obj);
        }
        /// <summary>
        /// The creature takes the best Attack- and DefenceItem from a given WorldObject
        /// </summary>
        /// <param name="obj">object to loot</param>
        public void Loot(WorldObject obj)
        {
            if (!obj.Lootable)
                return;
            MyLootStrategy.Loot(this, obj);
        }

        /// <summary>
        /// Adds an attackitem to this creature
        /// </summary>
        /// <param name="item">The new attack item</param>
        public void AddAttackItem(IAttackItem item)
        {
            if (MyAttackItem == null)
            {
                MyAttackItem = item;
                MyAttackItem.PickUp(this);
                return;
            }
            MyAttackItem.LayDown();
            MyAttackItem = MyAttackItem.AddIAttackItem(item);
            MyAttackItem.PickUp(this);
            Logger.Instance.Log($"{Name()} now holds: " + MyAttackItem.Name(), System.Diagnostics.TraceEventType.Information);
        }
        /// <summary>
        /// Adds a defence item to this creature
        /// </summary>
        /// <param name="item">The new defence item</param>
        public void AddDefenceItem(IDefenceItem item)
        {
            if (MyDefenceItem == null)
            {
                MyDefenceItem = item;
                return;
            }
            MyDefenceItem = MyDefenceItem.AddIDefenceItem(item);
            Logger.Instance.Log($"{Name()} now holds: " + MyDefenceItem.Name(), System.Diagnostics.TraceEventType.Information);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Update();

        public string Name()
        {
            return MyName;
        }
    }
}
