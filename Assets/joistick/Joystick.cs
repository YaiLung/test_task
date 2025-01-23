using UnityEngine;
using UnityEngine.EventSystems;
// ��� ���������� ���������� ����� ��� ��������: 1 ������(�����) 2 ��������(�������)
public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler // ��� ��������� �����
{
    [SerializeField] private RectTransform joystickBackground; // ��� 
    [SerializeField] private RectTransform joystickHandle;     // ����� 
    [SerializeField] private float handleRange = 100f;         // �������� �����

    private Vector2 inputVector = Vector2.zero;

    public Vector2 InputVector => inputVector; // �������� �������� ��� ��������� ������� �����

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBackground,
            eventData.position,
            eventData.pressEventCamera,
            out pos
        );

        pos = Vector2.ClampMagnitude(pos, handleRange); // ������������ ����� �������� handleRange
        joystickHandle.anchoredPosition = pos;

        inputVector = pos / handleRange; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero; // ���������� ����� � �����
    }
}
