using UnityEngine;
using UnityEngine.UI;
// ������ ��� ����������� ������ � ������ (��������),��� ����� ������������ ������ ������, ����� ���������� ������ �� �� Vertical Loyaut Group � ������ (���� ��� ��� ���� ���� ������ ������������)
public class ItemEntry : MonoBehaviour
{
    [SerializeField] private Text itemText; // ���� ��� ���������� Text, ��������� ���� ����, ��� ��� � �������� �������������

    // ��������� ������ ��� ����������� ����� ��������
    public void SetItemData(string itemName)
    {
        if (itemText != null)
        {
            itemText.text = itemName;
        }
        else
        {
            Debug.LogWarning("Item Text is not assigned in the inspector!");
        }
    }
}


