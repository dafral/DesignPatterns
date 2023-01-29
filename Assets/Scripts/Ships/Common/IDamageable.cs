namespace Ships.Common
{
    public interface IDamageable
    {
        public void AddDamage(int amount);
        public Teams Team { get; }
    }
}
