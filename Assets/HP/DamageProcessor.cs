using UnityEngine;
// скрипт для получения урона
public class DamageProcessor : MonoBehaviour
{
    private HPController hpController;

    public void Initialize(HPController hpController)
    {
        this.hpController = hpController;
    }

    public void ApplyDamage(int damage)
    {
        if (hpController != null)
        {
            hpController.TakeDamage(damage); // передаем метод 
        }
        else
        {
            Debug.LogError("HPController is not assigned!");
        }
    }
}
