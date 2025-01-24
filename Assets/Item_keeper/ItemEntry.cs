using UnityEngine;
using UnityEngine.UI;
// скрипт для отображения текста в панели (картинки),для этого используется префаб текста, текст получается кривым из за Vertical Loyaut Group в панели (хотя без нее хуще тест просто наслаивается)
public class ItemEntry : MonoBehaviour
{
    [SerializeField] private Text itemText; // Поле для компонента Text, принимает само себя, так как и является отобразителем

    // Установка текста для отображения имени предмета
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



