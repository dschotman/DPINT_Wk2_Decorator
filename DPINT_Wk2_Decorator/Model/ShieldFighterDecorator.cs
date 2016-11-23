namespace DPINT_Wk2_Decorator.Model
{
    public class ShieldFighterDecorator:BaseFighterDecorator
    {
        public int ShieldDefends { get; set; }

        public override void Defend(Attack attack) {
            if (ShieldDefends > 0)
            {
                attack.Messages.Add("Shield protected, attack value = 0");
                attack.Value = 0;
                ShieldDefends--;
            }
        }

        public override Attack Attack() {
            return base.NextFighterDecorator.Attack();
        }

        public ShieldFighterDecorator(IFighter nextFighterDecorator) : base(nextFighterDecorator) {
            ShieldDefends = 3;
        }
    }
}