using System;

namespace DPINT_Wk2_Decorator.Model
{
    public class MinionFighterDecorator : BaseFighterDecorator
    {
        public int MinionLives { get; set; }

        public override void Defend(Attack attack) {
            if (MinionLives > 0) {
                int tmpLives = MinionLives;
                MinionLives -= Math.Max(0, attack.Value);
                attack.Value -= Math.Max(0, tmpLives - MinionLives);
                attack.Messages.Add("Minion defended from the attack: -" + attack.Value);
            }
            else {
                attack.Messages.Add("No minions left to help defend.");
            }
        }

        public override Attack Attack() {
            Attack attack = base.NextFighterDecorator.Attack();
            int minionAttackValue = attack.Value/2;
            if (MinionLives > 0) {
                attack.Messages.Add("Minion helping the attack: " + minionAttackValue);
                attack.Value += minionAttackValue;
                MinionLives--;
            }
            else {
                attack.Messages.Add("No minions left to help with the attack.");
            }
            return attack;
        }

        public MinionFighterDecorator(IFighter nextFighterDecorator) : base(nextFighterDecorator) {
            MinionLives = nextFighterDecorator.Lives/2;
        }
    }
}