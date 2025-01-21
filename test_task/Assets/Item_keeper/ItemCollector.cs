using System.Collections.Generic;
using UnityEngine;
// скрипт для записи подобранных предметов, в него можно вложить предметы на которые будет триггер, после сбора они пропадут, для открытия списка нужно нажать I

// Важно! пока к самим предметам на не привязывал только к кубам, так как с предметами труднее и не все реагуруют

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject item1; // Первый предмет
    [SerializeField] private GameObject item2; // Второй предмет
    [SerializeField] private GameObject item3; // Третий предмет

    [SerializeField] private GameObject uiListPanel; // Панель UI для отображения списка
    [SerializeField] private GameObject itemEntryPrefab; // Префаб для отображения предмета

    private List<string> collectedItems = new List<string>(); // Список собранных предметов

    private void Start()
    {
        uiListPanel.SetActive(false); // Панель скрыта по умолчанию
    }

    private void Update()
    {
        //  нажатия клавиши I для отображения/скрытия списка
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUIList();
        }
    }

    // Метод для добавления предмета в список
    public void CollectItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            UpdateUI();
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
        if (other.gameObject == item1)
        {
            CollectItem("Item 1");
            Destroy(item1); // Убираем предмет с локации
        }
        else if (other.gameObject == item2)
        {
            CollectItem("Item 2");
            Destroy(item2); 
        }
        else if (other.gameObject == item3)
        {
            CollectItem("Item 3");
            Destroy(item3); 
        }
    }
}


