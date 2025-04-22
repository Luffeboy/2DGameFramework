namespace _2DGameFramework
{
    public class StrategyCreature : Creature
    {
        private Action<StrategyCreature> _currentStrategy;
        public StrategyCreature(Vector2 position, World world, Action<StrategyCreature> startStrategy) : base(position, world)
        {
            SwitchStrategy(startStrategy);
        }

        public override void Update()
        {
            _currentStrategy(this);
        }
        public void SwitchStrategy(Action<StrategyCreature> strategy)
        {
            _currentStrategy = strategy;
        }
    }
}
