using System.Collections.Generic;
using UnityEngine;
// ������ ��� ������ ����������� ���������, � ���� ����� ������� �������� �� ������� ����� �������, ����� ����� ��� ��������, ��� �������� ������ ����� ������ I

// ������ ����� ��������� ������� ������ ��������� ����� ���������

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private List<GameObject> items; // ������ ���� ��������� ��� ���������� � ������ ���������� ������� � items � inspector
    [SerializeField] private GameObject uiListPanel; // ������ UI ��� ����������� ������
    [SerializeField] private GameObject itemEntryPrefab; // ������ ��� ����������� ��������

    private List<string> collectedItems = new List<string>(); // ������ ��������� ���������

    private void Start()
    {
        uiListPanel.SetActive(false); // ������ ������ �� ���������
    }

    private void Update()
    {
        // ������� ������� I ��� �����������/������� ������
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUIList();
        }
    }

    // ����� ��� ���������� �������� � ������
    public void CollectItem(string itemName, GameObject item)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
            UpdateUI();
            Destroy(item); // ������� ������� � �������
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
        if (items.Contains(other.gameObject)) // ���������, ���� �� ������� � ������
        {
            CollectItem(other.gameObject.name, other.gameObject);
        }
    }
}



