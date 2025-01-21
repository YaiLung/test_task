using UnityEngine;

//�� ���������� ��� ������


public class HPController : MonoBehaviour // ���� ����� ��� �����������
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
            Debug.LogError("HealthBar not found in Character's hierarchy!"); // ���� ������,����� ���� ��������, ������ ����������
        }
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        // ������ ������ ��������
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
        Debug.Log("Game Over!"); //����� ����
        
    }
}
