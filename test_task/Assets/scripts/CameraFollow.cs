using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���������� �������
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // �������� ��� ������, �� ������� ������� ������
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); 
    [SerializeField] private float followSpeed = 10f; 
    [SerializeField] private float rotationSpeed = 5f; 

    private void LateUpdate()
    {
        FollowPlayer();
        RotateCamera();
    }

    
    private void FollowPlayer()
    {
        Vector3 desiredPosition = target.position + offset; 
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime); 
        transform.position = smoothedPosition;
    }

    
    private void RotateCamera()
    {
        // ��������
        float horizontalInput = Input.GetAxis("Mouse X"); 
        float verticalInput = Input.GetAxis("Mouse Y"); 

        // �������� ������ ������ ����
        transform.RotateAround(target.position, Vector3.up, horizontalInput * rotationSpeed); //horiz
        transform.RotateAround(target.position, transform.right, -verticalInput * rotationSpeed); //vert

        // ��������� ������ ����� ��� ������ �������� �� ����
        transform.LookAt(target);
    }
}
