using UnityEngine;


// Управляет отображением полоски здоровья

public class HealthBarHandler : MonoBehaviour
{
    [SerializeField] private HPController hpController;
    [SerializeField] private HealthBar healthBar;

    private void OnEnable()
    {
        hpController.OnHealthChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        hpController.OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }
}
