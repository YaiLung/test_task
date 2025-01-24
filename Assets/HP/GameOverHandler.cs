using UnityEngine;


// Обрабатывает поражение игрока.

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private HPController hpController;

    private void OnEnable()
    {
        hpController.OnDeath += HandleGameOver;
    }

    private void OnDisable()
    {
        hpController.OnDeath -= HandleGameOver;
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over!");
       
    }
}
