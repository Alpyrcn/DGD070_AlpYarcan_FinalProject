using Entitas;
using System;

[Game]
public class PlayerHealthComponent : IComponent
{
    public float Value;
}

[Game]
public class PlayerDamagedComponent : IComponent
{
    public int damageAmount;
}

[Game]
public class PlayerHealedComponent : IComponent
{
    public int healAmount;
}