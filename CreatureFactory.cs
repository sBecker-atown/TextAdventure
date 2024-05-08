namespace TextAdventure;



public class CreatureFactory
{
    private readonly Creature _skeleton = new (
        "Skeleton",
        Bonus.Weak,
        Damage.Minor,
        Bonus.Weak,
        HitPoints.Low,
        []
    );

    private readonly Creature _zombie = new (
        "Zombie",
        Bonus.Normal,
        Damage.Normal,
        Bonus.Normal,
        HitPoints.Low,
        []
    );

    private readonly Creature _mummy = new (
        "Mummy",
        Bonus.Strong,
        Damage.Major,
        Bonus.Strong,
        HitPoints.High,
        []
    );

    private readonly Creature _lich = new (
        "Lich",
        Bonus.Magic,
        Damage.Heavy,
        Bonus.Magic,
        HitPoints.MiniBoss,
        []
    );

    public Creature BirthSkeleton()
    {
        return _skeleton;
    }

    public Creature BirthZombie()
    {
        return _zombie;
    }
}