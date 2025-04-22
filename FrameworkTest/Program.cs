using _2DGameFramework;
using FrameworkTest;
using System.Diagnostics;

Logger.Instance.AddTraceListener(new ConsoleTraceListener());
World world = new World(null, 3, 3);
Creature c1 = new ConcreteCreature(new Vector2(), world);
Creature c2 = new ConcreteCreature(new Vector2(2, 2), world);
WorldObject wo = new WorldObject(new Vector2(1, 1), world) { Lootable = true, Removeable = false };
wo.AttackItems.Add(new AttackItem() { HitValue=5, NameValue="Sword", RangeValue=2 });
world.AddCreature(c1);
world.AddCreature(c2);
world.AddWorldObject(wo);
for (int i = 0; i < 100; i++)
    world.UpdateWorld();
Logger.Instance.Stop();