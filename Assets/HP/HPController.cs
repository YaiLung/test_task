using System;
using UnityEngine;


// Отвечает за управление состоянием здоровья

public class HPController : MonoBehaviour
{
    public int MaxHealth { get; private set; } = 100;
    private int currentHealth;

    public event Action<int, int> OnHealthChanged; // Событие изменения здоровья 
    public event Action OnDeath; // Событие поражения

    private void Start()
    {
        currentHealth = MaxHealth;
        OnHealthChanged?.Invoke(currentHealth, MaxHealth);
    }

    
    // Уменьшает здоровье на указанное количество
   
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        // Уведомляем слушателей об изменении здоровья
        OnHealthChanged?.Invoke(currentHealth, MaxHealth);

        // Если здоровье закончилось вызываем событие поражения
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    
    // Возвращает текущее здоровье
    
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}




