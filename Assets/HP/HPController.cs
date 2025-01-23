using UnityEngine;

// скрипт для хп c методами получения урона и концом игры 
public class HPController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isGameOver = false;

    private HealthBar healthBar;
    private DamageProcessor damageProcessor;
    private GameOverHandler gameOverHandler;

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar = GetComponentInChildren<HealthBar>();
        damageProcessor = GetComponent<DamageProcessor>();
        gameOverHandler = GetComponent<GameOverHandler>();

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
        else
        {
            Debug.LogError("HealthBar not found in Character's hierarchy!"); // подключение отсутсвует
        }

        if (damageProcessor != null)
        {
            damageProcessor.Initialize(this); // Передаем ссылку на HPController
        }

        if (gameOverHandler == null)
        {
            Debug.LogError("GameOverHandler not found!"); // подключение отсутсвует
        }
    }

    public void TakeDamage(int damage) // хоть был создан новый класс для конца игры, метод для получения урона остался (будет передоватся в скрипт DamageProcessor)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }

        Debug.Log($"Player took {damage} damage. Current HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            isGameOver = true;
            if (gameOverHandler != null)
            {
                gameOverHandler.TriggerGameOver();
            }
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
