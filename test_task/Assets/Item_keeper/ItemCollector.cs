using System.Collections.Generic;
using UnityEngine;
// ������ ��� ������ ����������� ���������, � ���� ����� ������� �������� �� ������� ����� �������, ����� ����� ��� ��������, ��� �������� ������ ����� ������ I

// �����! ���� � ����� ��������� �� �� ���������� ������ � �����, ��� ��� � ���������� ������� � �� ��� ���������

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject item1; // ������ �������
    [SerializeField] private GameObject item2; // ������ �������
    [SerializeField] private GameObject item3; // ������ �������

    [SerializeField] private GameObject uiListPanel; // ������ UI ��� ����������� ������
    [SerializeField] private GameObject itemEntryPrefab; // ������ ��� ����������� ��������

    private List<string> collectedItems = new List<string>(); // ������ ��������� ���������

    private void Start()
    {
        uiListPanel.SetActive(false); // ������ ������ �� ���������
    }

    private void Update()
    {
        //  ������� ������� I ��� �����������/������� ������
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUIList();
        }
    }

    // ����� ��� ���������� �������� � ������
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
        // ������� ������ ������
        foreach (Transform child in uiListPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // ������� ����� ������ �� ������ ������
        foreach (string item in collectedItems)
        {
            GameObject entry = Instantiate(itemEntryPrefab, uiListPanel.transform);
            entry.GetComponent<ItemEntry>().SetItemData(item);
        }
    }

    // ����� ��� ����������� ��� ������� ������
    private void ToggleUIList()
    {
        uiListPanel.SetActive(!uiListPanel.activeSelf);
    }

    // �������������� � ����������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == item1)
        {
            CollectItem("Item 1");
            Destroy(item1); // ������� ������� � �������
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


