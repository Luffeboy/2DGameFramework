using _2DGameFramework;
using FrameworkTest;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;

bool usingLogger = false;
if (usingLogger)
    Logger.Instance.AddTraceListener(new ConsoleTraceListener() { Filter = new EventTypeFilter(SourceLevels.Information) });

//World world = new World(null, 3, 3);
World world = new World();
WorldObject wo = new WorldObject(new Vector2(1, 1), world) { MyName = "SwordShrine", Lootable = true, Removeable = false };
wo.AttackItems.Add(new AttackItem() { HitValue=5, NameValue="Sword", RangeValue=2 });
WorldObject wo2 = new WorldObject(new Vector2(1, 2), world) { MyName = "Nothing", Lootable = true, Removeable = true };
WorldObject wo3 = new WorldObject(new Vector2(world.WorldSize.x / 2, world.WorldSize.y / 2 + 1), world) { MyName = "ArmorShrine", Lootable = true, Removeable = true };
wo3.DefenceItems.Add(new CompositeDefenceItem());
wo3.DefenceItems.Add(new DefenceItem() { NameValue = "Standard armor", ReduceHitPointsValue = 2});
wo3.DefenceItems.Add(new DefenceItem() { NameValue = "Helmet", ReduceHitPointsValue = 1});

var c = new ConcreteCreature(new Vector2(1, 0), world, new UnableToLootStrategy());
//c.MyLootStrategy = new UnableToLootStrategy();

new KillerCreature(new Vector2(5, 0), world);
new KillerCreature(new Vector2(world.WorldSize.x - 1, world.WorldSize.y - 1), world);
if (!usingLogger)
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
    if (usingLogger)
        return;
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
                else if (entity.GetType() == typeof(PlayerCreature))
                    c = 'P';
                else if (entity is Creature)
                    c = 'C';
                else if (entity is WorldObject)
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