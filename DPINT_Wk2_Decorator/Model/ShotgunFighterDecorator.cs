namespace DPINT_Wk2_Decorator.Model
{
    public class ShotgunFighterDecorator : BaseFighterDecorator
    {
        public int ShotgunRoundsFired { get; set; }

        public override void Defend(Attack attack) {
            base.NextFighterDecorator.Defend(attack);
        }

        public override Attack Attack() {
            Attack attack = base.NextFighterDecorator.Attack();

            if (ShotgunRoundsFired < 2) {
                attack.Messages.Add("Shotgun: 20");
                attack.Value += 20;
                ShotgunRoundsFired++;
            }
            else {
                attack.Messages.Add("Shotgun reloading, no extra damage.");
                ShotgunRoundsFired = 0;
            }
            return attack;
        }

        public ShotgunFighterDecorator(IFighter nextFighterDecorator) : base(nextFighterDecorator) {
            ShotgunRoundsFired = 0;
        }
    }
}