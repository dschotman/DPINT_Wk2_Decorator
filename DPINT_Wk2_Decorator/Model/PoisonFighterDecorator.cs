namespace DPINT_Wk2_Decorator.Model
{
    public class PoisonFighterDecorator : BaseFighterDecorator
    {
        private int _poisonStrength;

        public int PoisonStrength {
            get { return _poisonStrength; }
            set { _poisonStrength = value < 0 ? 0 : value; }
        }

        public override void Defend(Attack attack) {
            base.NextFighterDecorator.Defend(attack);
        }

        public override Attack Attack() {
            Attack attack = base.NextFighterDecorator.Attack();
            attack.Value += AttackValue;
            attack.Messages.Add("Doubled the original attack value: " + AttackValue);
            if (PoisonStrength > 0) {
                attack.Messages.Add("Poison weakening, current value: " + PoisonStrength);
                attack.Value += PoisonStrength;
                PoisonStrength -= 2;
            }
            else {
                attack.Messages.Add("Poison ran out.");
            }
            return attack;
        }

        public PoisonFighterDecorator(IFighter nextFighterDecorator) : base(nextFighterDecorator) {
            _poisonStrength = 10;
        }
    }
}