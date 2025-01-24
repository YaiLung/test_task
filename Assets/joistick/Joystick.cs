using UnityEngine;
using UnityEngine.EventSystems;
// для управления джойстиком нужны две картинки: 1 внутри(ручка) 2 бэкгрунд(снаружи)
public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler // для поведения ручки
{
    [SerializeField] private RectTransform joystickBackground; // Фон 
    [SerializeField] private RectTransform joystickHandle;     // Ручка 
    [SerializeField] private float handleRange = 100f;         // смещение ручки

    private Vector2 inputVector = Vector2.zero;

    public Vector2 InputVector => inputVector; // Открытое свойство для получения вектора ввода

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground,
            eventData.position,
            eventData.pressEventCamera,
            out pos
        );

        pos = Vector2.ClampMagnitude(pos, handleRange); // Ограничиваем ручку радиусом handleRange
        joystickHandle.anchoredPosition = pos;

        inputVector = pos / handleRange;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero; // Возвращаем ручку в центр
    }
}
