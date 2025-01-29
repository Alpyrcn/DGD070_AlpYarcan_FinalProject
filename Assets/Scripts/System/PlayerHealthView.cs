using UnityEngine;
using Entitas;

public class PlayerHealthView : MonoBehaviour
{
    private GameContext _context;
    private IGroup<GameEntity> _healthEntities;

    void Start()
    {
        _context = Contexts.sharedInstance.game;
        _healthEntities = _context.GetGroup(GameMatcher.PlayerHealth);
    }

    void OnGUI()
    {
        foreach (var entity in _healthEntities)
        {
            GUI.Label(new Rect(10, 10, 200, 20), $"Player Health: {entity.playerHealth.Value}");
        }
    }
}
