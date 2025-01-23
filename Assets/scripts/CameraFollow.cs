using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Управление камерой
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // Персонаж или объект, за которым следует камера
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
        // Вращение
        float horizontalInput = Input.GetAxis("Mouse X"); 
        float verticalInput = Input.GetAxis("Mouse Y"); 

        // Вращение камеры вокруг цели
        transform.RotateAround(target.position, Vector3.up, horizontalInput * rotationSpeed); //horiz
        transform.RotateAround(target.position, transform.right, -verticalInput * rotationSpeed); //vert

        // Фиксируем камеру чтобы она всегда смотрела на цель
        transform.LookAt(target);
    }
}
