using Entitas;
using UnityEngine;

public class PlayerMovementFeature : IFeature
{
    private readonly Contexts _contexts;
    private readonly GameController _gameController;

    public PlayerMovementFeature(Contexts contexts, GameController gameController)
    {
        _contexts = contexts;
        _gameController = gameController;
    }

    public void Execute()
    {
        var playerEntity = _contexts.game.playerEntity; 
        if (playerEntity != null)
        {
            
            float moveSpeed = 5f;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            playerEntity.ReplacePosition(playerEntity.position.value + movement * moveSpeed * Time.deltaTime);

            
            if (playerEntity.position.value.x < 0 || playerEntity.position.value.x > Screen.width ||
                playerEntity.position.value.y < 0 || playerEntity.position.value.y > Screen.height)
            {
                
                playerEntity.ReplacePosition(new Vector3(
                    Mathf.Clamp(playerEntity.position.value.x, 0, Screen.width),
                    Mathf.Clamp(playerEntity.position.value.y, 0, Screen.height),
                    0));
            }
        }
    }
}