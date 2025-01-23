using UnityEngine;
using UnityEngine.UI;
// для отображения ХП_бара
public class HealthBar : MonoBehaviour
{
    public Image Bar; // Ссылка на UI Image

    // Обновление полосы здоровья
    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        Bar.fillAmount = healthPercentage;
    }
}
