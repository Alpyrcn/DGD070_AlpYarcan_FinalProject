using Entitas;
using UnityEngine;

public class CheckPlayerHealthSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private readonly IGroup<GameEntity> _healthEntities;

    public CheckPlayerHealthSystem(Contexts contexts)
    {
        _context = contexts.game;
        _healthEntities = _context.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute()
    {
        foreach (var entity in _healthEntities)
        {
            if (entity.hasPlayerHealed)
            {
                entity.ReplacePlayerHealth(Mathf.Min(entity.playerHealth.Value + 10f, 100f));
                entity.RemovePlayerHealed();
            }

            if (entity.hasPlayerDamaged)
            {
                entity.ReplacePlayerHealth(Mathf.Max(entity.playerHealth.Value - 10f, 0f));
                entity.RemovePlayerDamaged();
            }
        }
    }
}
