using System.Xml;

namespace _2DGameFramework
{
    public class World
    {
        private CreatureManager _creatureManager;
        private List<WorldObject> _worldObjects = new List<WorldObject>();
        private int MaxX {  get; set; }
        private int MaxY {  get; set; }
        public Vector2 WorldSize { get { return new Vector2(MaxX, MaxY); } }
        public string LevelOfTheGame { get; set; }
        public Entity?[,] EntityGrid {  get; private set; }

        public List<Creature> Creatures { get { return new List<Creature>(_creatureManager.Creatures); } }
        public List<WorldObject> WorldObjects { get { return new List<WorldObject>(_worldObjects); } }

        /// <summary>
        /// Reads MaxX, MaxY and LevelOfTheGame from "Config.xml", if such a file is doesn't exist or "fileName" is set to null, it uses the rest of the values provided in the constructor.
        /// </summary>
        /// <param name="fileName">the name of the xml file, null or file not existing, will use the rest of the parameterlist instead</param>
        /// <param name="maxX">the MaxX, if not reading from file, or no such value was found</param>
        /// <param name="maxY">the MaxY, if not reading from file, or no such value was found</param>
        /// <param name="levelOfTheGame">the levelOfTheGame, if not reading from file, or no such value was found</param>
        public World(string? fileName = "Config.xml", int maxX = 10, int maxY = 10, LevelsOfTheGame levelOfTheGame_ = LevelsOfTheGame.Normal)
        {
            XmlDocument configDoc = new XmlDocument();
            if (fileName != null && File.Exists(fileName))
            {
                configDoc.Load("Config.xml");
                XmlNode? maxXNode = configDoc.DocumentElement.SelectSingleNode("MaxX");
                if (maxXNode != null)
                    MaxX = int.Parse(maxXNode.InnerText.Trim());
                else
                    MaxX = maxX;
                XmlNode? maxYNode = configDoc.DocumentElement.SelectSingleNode("MaxY");
                if (maxYNode != null)
                    MaxY = int.Parse(maxYNode.InnerText.Trim());
                else
                    MaxY = maxY;
                XmlNode? LevelOfTheGameNode = configDoc.DocumentElement.SelectSingleNode("LevelOfTheGame");
                if (LevelOfTheGameNode != null)
                    LevelOfTheGame = LevelOfTheGameNode.InnerText;
                else LevelOfTheGame = levelOfTheGame_.ToString();

            }
            else
            {
                // xml file doesn't exist
                MaxX = maxX;
                MaxY = maxY;
                LevelOfTheGame = levelOfTheGame_.ToString();
            }
            EntityGrid = new Entity[MaxX, MaxY];
            Logger.Instance.Log($"World created with MaxX: {MaxX},  MaxY: {MaxY}, Level of the game: {LevelOfTheGame}", System.Diagnostics.TraceEventType.Information);

            _creatureManager = new CreatureManager(this);
        }
        /// <summary>
        /// Returns the entity at the coordinates, if there is an entity there.
        /// This function check if the x and y coordinates are inside the map
        /// </summary>
        /// <param name="x">The x</param>
        /// <param name="y">The y</param>
        /// <returns>The Entity or null</returns>
        public Entity? GetEntity(int x, int y)
        {
            if (x < 0 || x >= MaxX || y < 0 || y >= MaxY) 
                return null;
            return EntityGrid[x, y];
        }
        /// <summary>
        /// Returns the entity at the coordinates, if there is an entity there.
        /// This function check if the x and y coordinates are inside the map
        /// </summary>
        /// <param name="pos">The position</param>
        /// <returns>The Entity or null</returns>
        public Entity? GetEntity(Vector2 pos)
        {
            return GetEntity(pos.x, pos.y);
        }
        /// <summary>
        /// Updates all Creatures in the world
        /// </summary>
        public void UpdateWorld()
        {
            _creatureManager.UpdateCreatures();
        }
        /// <summary>
        /// Adds a Creature to the world
        /// </summary>
        /// <param name="creature"></param>
        public void AddCreature(Creature creature)
        {
            _creatureManager.AddCreature(creature);
        }
        //public void RemoveCreature(Creature creature)
        //{
        //    _creatureManager.RemoveCreatures(creature);
        //}
        /// <summary>
        /// Adds a WorldObject to the world
        /// </summary>
        /// <param name="obj"></param>
        public void AddWorldObject(WorldObject obj)
        {
            _worldObjects.Add(obj);
        }
    }
}
