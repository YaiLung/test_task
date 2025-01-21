using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Joystick joystick; // ������ �� ��������
    [SerializeField] private float moveSpeed = 5f; // �������� ��������

    private void Update()
    {
        Vector3 movement = new Vector3(joystick.InputVector.x, 0, joystick.InputVector.y);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // ������� ��������� � ����������� ��������
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}

