namespace GameEngine
{
    public class NormalEnemy : Enemy
    {
        public override double TotalSpecialPower { get => 100; }
        public override double SpecialPowerUses { get => 10; }
    }
}
