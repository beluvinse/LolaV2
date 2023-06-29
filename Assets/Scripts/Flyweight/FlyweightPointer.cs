using UnityEngine;

public static class FlyweightPointer
{
    public static readonly Flyweight CommonZombie = new Flyweight
    {
        maxLife = 100f,
        damage = 20f,
        chaseRadius = 10f,
        attackRadius = 2f,
        attackDelay = 2f
    };

    public static readonly Flyweight RangeZombie = new Flyweight
    {
        maxLife = 120f,
        damage = 15f,
        chaseRadius = 10f,
        attackRadius = 8f,
        attackDelay = 1f
    };

    public static readonly Flyweight Boss = new Flyweight
    {
        maxLife = 3000f,
        damage = 40f,
        chaseRadius = 12.5f,
        attackRadius = 15f,
        attackDelay = 1f
    };
}
