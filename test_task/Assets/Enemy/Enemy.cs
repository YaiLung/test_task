using UnityEngine;
// для добовления урона при сталкновении box collaider
public class Enemy : MonoBehaviour
{
    public int damage = 50; // Урон который наносит враг

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем есть ли у объекта с которым произошло столкновение компонент HPController
        HPController playerHP = collision.gameObject.GetComponent<HPController>();

        if (playerHP != null)
        {
            // Отнимаем здоровье у игрока
            playerHP.TakeDamage(damage);
        }
    }
}

