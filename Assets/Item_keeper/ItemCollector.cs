using System.Collections.Generic;
using UnityEngine;
// скрипт для записи подобранных предметов, в него можно вложить предметы на которые будет триггер, после сбора они пропадут, для открытия списка нужно нажать I

// теперь можно добовлять сколько угодно предметов через инспектор

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private List<GameObject> items; // Список всех предметов для добовления в список перетащите предмет в items в inspector
    [SerializeField] private GameObject uiListPanel; // Панель UI для отображения списка
    [SerializeField] private GameObject itemEntryPrefab; // Префаб для отображения предмета

    private List<string> collectedItems = new List<string>(); // Список собранных предметов

    private void Start()
    {
        uiListPanel.SetActive(false); // Панель скрыта по умолчанию
    }

    private void Update()
    {
        // Нажатие клавиши I для отображения/скрытия списка
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUIList();
        }
    }

    // Метод для добавления предмета в список
    public void CollectItem(string itemName, GameObject item)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            UpdateUI();
            Destroy(item); // Убираем предмет с локации
        }
    }

    private void UpdateUI()
    {
        // Очищаем старые записи
        foreach (Transform child in uiListPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Создаем новые записи на основе списка
        foreach (string item in collectedItems)
        {
            GameObject entry = Instantiate(itemEntryPrefab, uiListPanel.transform);
            entry.GetComponent<ItemEntry>().SetItemData(item);
        }
    }

    // Метод для отображения или скрытия списка
    private void ToggleUIList()
    {
        uiListPanel.SetActive(!uiListPanel.activeSelf);
    }

    // Взаимодействие с предметами
    private void OnTriggerEnter(Collider other)
    {
        if (items.Contains(other.gameObject)) // Проверяем, есть ли предмет в списке
        {
            CollectItem(other.gameObject.name, other.gameObject);
        }
    }
}

