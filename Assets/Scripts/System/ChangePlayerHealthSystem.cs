using Entitas;
using UnityEngine;

public class ChangePlayerHealthSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _healthEntities;

    public ChangePlayerHealthSystem(Contexts contexts)
    {
        _context = contexts.game;
        _healthEntities = _context.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var entity in _healthEntities)
            {
                entity.isPlayerDamaged = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            foreach (var entity in _healthEntities)
            {
                entity.isPlayerHealed = true;
            }
        }
    }
}