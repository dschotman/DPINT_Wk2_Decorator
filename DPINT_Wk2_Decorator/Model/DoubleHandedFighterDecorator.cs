namespace DPINT_Wk2_Decorator.Model
{
    public class DoubleHandedFighterDecorator : BaseFighterDecorator
    {
        public override void Defend(Attack attack) {
            attack.Messages.Add("One hand defended the attack: -" + base.NextFighterDecorator.DefenseValue);
            attack.Value -= base.NextFighterDecorator.DefenseValue;
        }

        public override Attack Attack() {
            Attack attack = base.NextFighterDecorator.Attack();
            attack.Value *= 2;
            attack.Messages.Add("Doubled the original attack value: " + attack.Value);
            return attack;
        }

        public DoubleHandedFighterDecorator(IFighter nextFighterDecorator) : base(nextFighterDecorator) {}
    }
}