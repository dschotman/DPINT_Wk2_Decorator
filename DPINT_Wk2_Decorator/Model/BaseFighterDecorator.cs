namespace DPINT_Wk2_Decorator.Model
{
    public abstract class BaseFighterDecorator : IFighter
    {
        private IFighter _nextFighterDecorator;

        protected BaseFighterDecorator(IFighter nextFighterDecorator) {
            _nextFighterDecorator = nextFighterDecorator;
        }

        public IFighter NextFighterDecorator {
            get { return _nextFighterDecorator; }
            set { _nextFighterDecorator = value; }
        }

        public int Lives { get; set; }
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }

        public abstract void Defend(Attack attack);
        public abstract Attack Attack();
    }
}