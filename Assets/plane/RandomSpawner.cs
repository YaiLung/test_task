using System.Collections.Generic;
using UnityEngine;
// рандомный спавнер предметов на карте
public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject item1; // типы
    [SerializeField] private GameObject item2;
    [SerializeField] private GameObject item3;

    [SerializeField] private int spawnCount = 3; // Количество предметов
    [SerializeField] private Vector2 spawnAreaSize = new Vector2(25f, 25f); // Размер савна

    private void Start()
    {

        HideInitialItems();


        SpawnItems();
    }

    private void HideInitialItems()
    {

        item1.SetActive(false);
        item2.SetActive(false);
        item3.SetActive(false);
    }

    private void SpawnItems()
    {

        List<GameObject> items = new List<GameObject> { item1, item2, item3 };

        for (int i = 0; i < spawnCount; i++)
        {
            if (items.Count == 0)
            {
                Debug.LogWarning("Недостаточно уникальных предметов для спавна");
                break;
            }

            // Выбираем случайный объект из списка
            int randomIndex = Random.Range(0, items.Count);
            GameObject randomItem = items[randomIndex];

            // Генерируем случайную позицию 
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                0, // Высота 
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
            );

            // Создаём объект на случайной позиции
            Instantiate(randomItem, randomPosition, Quaternion.identity).SetActive(true);

            // Удаляем выбранный объект из списка, чтобы он не спаунился повторно
            items.RemoveAt(randomIndex);
        }
    }
}


