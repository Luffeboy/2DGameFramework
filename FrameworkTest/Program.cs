using _2DGameFramework;
using FrameworkTest;
using System.Diagnostics;
using System.Text;
//Logger.Instance.AddTraceListener(new ConsoleTraceListener());

//World world = new World(null, 3, 3);
World world = new World();
WorldObject wo = new WorldObject(new Vector2(1, 1), world) { MyName = "SwordShrine", Lootable = true, Removeable = false };
wo.AttackItems.Add(new AttackItem() { HitValue=5, NameValue="Sword", RangeValue=2 });
WorldObject wo2 = new WorldObject(new Vector2(1, 2), world) { MyName = "Nothing", Lootable = true, Removeable = true };

var c = new ConcreteCreature(new Vector2(1, 0), world);
c.MyLootStrategy = new UnableToLootStrategy();

new KillerCreature(new Vector2(5, 0), world);
new KillerCreature(new Vector2(world.WorldSize.x - 1, world.WorldSize.y - 1), world);

new PlayerCreature(new Vector2(world.WorldSize.x / 2, world.WorldSize.y / 2), world);

for (int i = 0; i < 20; i++)
    AddCreatureAtRandomPosition(world);

DrawWorld(world);
for (int i = 0; i < 100; i++)
{
    world.UpdateWorld();
    DrawWorld(world);
    Thread.Sleep(10);
}
Logger.Instance.Stop();

void AddCreatureAtRandomPosition(World world)
{
    Random r = new Random();
    int x = r.Next(world.WorldSize.x);
    int y = r.Next(world.WorldSize.y);
    if (world.EntityGrid[x, y] == null)
        new ConcreteCreature(new Vector2(x, y), world);
}

void DrawWorld(World world)
{
    Console.Clear();
    StringBuilder sb = new StringBuilder();
    for (int x = 0; x < world.WorldSize.x + 2; x++)
        sb.Append("-");
    sb.Append("\n");
    for (int y = 0; y  < world.WorldSize.y; y++)
    {
        sb.Append("|");
        for (int x = 0; x < world.WorldSize.x; x++)
        {
            char c = ' ';
            var entity = world.EntityGrid[x, y];
            if (entity != null)
            {
                if (entity.GetType() == typeof(KillerCreature))
                    c = 'K';
                if (entity.GetType() == typeof(PlayerCreature))
                    c = 'P';
                else if (entity.GetType().BaseType == typeof(Creature))
                    c = 'C';
                else if (entity.GetType() == typeof(WorldObject))
                    c = 'O';
            }
            sb.Append(c);
        }
        sb.Append("|\n");
    }
    for (int x = 0; x < world.WorldSize.x + 2; x++)
        sb.Append("-");
    Console.Write(sb.ToString());
}