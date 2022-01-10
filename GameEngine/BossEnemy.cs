namespace GameEngine
{
    public class BossEnemy : Enemy
    {
        public override double TotalSpecialPower { get => 1000; }
        public override double SpecialPowerUses { get => 6; }
    }
}
