using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ускорение при столкновении
public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float boostDuration = 3f; // Длительность 
    [SerializeField] private float boostCount = 2f; // Множитель 

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, что столкнулся с объектом, имеющим скрипт Move
        if (collision.gameObject.TryGetComponent(out Move.Move player))
        {

            StartCoroutine(BoostPlayerSpeed(player));
        }
    }

    private IEnumerator BoostPlayerSpeed(Move.Move player) // Возвращаем исходную скорость
    {
        float originalSpeed = player.Speed;
        player.Speed *= boostCount;
        yield return new WaitForSeconds(boostDuration);
        player.Speed = originalSpeed;
    }
}

