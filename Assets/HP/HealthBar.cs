using UnityEngine;
using UnityEngine.UI;
// ��� ����������� ��_����
public class HealthBar : MonoBehaviour
{
    public Image Bar; // ������ �� UI Image

    // ���������� ������ ��������
    public void UpdateHealthBar(int maxHealth, int currentHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        Bar.fillAmount = healthPercentage;
    }
}
