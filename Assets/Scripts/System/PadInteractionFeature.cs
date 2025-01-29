using Entitas;
using UnityEngine;

public class PadInteractionFeature : IFeature
{
    private readonly Contexts _contexts;
    private int _padsTouched = 0;

    public PadInteractionFeature(Contexts contexts, GameController gameController)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        foreach (var pad in _contexts.game.padEntities)
        {
            if (pad.isTriggered) 
            {
                _padsTouched++;
                pad.isTriggered = false; 
                pad.ReplaceColor(Color.green); 
            }
        }

        if (_padsTouched >= 4) 
        {
            
            _gameController.GameOver();
        }
    }
}