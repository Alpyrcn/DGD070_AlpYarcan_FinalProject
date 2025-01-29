using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    private Systems _systems;
    private bool _isGameOver = false; 

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new Feature("Systems")
            .Add(new PlayerMovementFeature(contexts, this)) 
            .Add(new PadInteractionFeature(contexts, this)); 

        _systems.Initialize();
    }

    private void Update()
    {
        if (!_isGameOver) 
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
        
        Debug.Log("A WINRAR IS YOU");
    }

    private void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.TearDown();
            _systems = null;
        }
    }
}