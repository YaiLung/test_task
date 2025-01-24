using UnityEngine;
using UnityEngine.UI;
// отображением полоску здоровья 
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthFillImage; // Ссылка на компонент Image

    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        if (healthFillImage == null)
        {
            Debug.LogError("HealthFillImage не назначен!");
            return;
        }

        float healthPercentage = (float)currentHealth / maxHealth;
        healthFillImage.fillAmount = healthPercentage; // Обновляем fillAmount
    }
}


