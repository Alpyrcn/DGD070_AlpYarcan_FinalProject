using Entitas;

public class CreatePlayerHealthSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public CreatePlayerHealthSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var entity = _context.CreateEntity();
        entity.AddPlayerHealth(100f);
    }
}