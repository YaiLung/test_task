using UnityEngine;

//ХП контролеер для игрока


public class HPController : MonoBehaviour // публ класс для отоброжания
{
    public int maxHealth = 100; 
    private int currentHealth; 
    private bool isGameOver = false;

    private HealthBar healthBar; 

    private void Start()
    {
        currentHealth = maxHealth;

        
        healthBar = GetComponentInChildren<HealthBar>();

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
        else
        {
            Debug.LogError("HealthBar not found in Character's hierarchy!"); // были ошибки,нужна была проверка, сейчас бесполезен
        }
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        // рефреш полосы здоровья
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }

        Debug.Log($"Player took {damage} damage. Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!"); //конец игры
        
    }
}
