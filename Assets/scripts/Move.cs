using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// контролер клавиаторой 
namespace Move
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float speed = 5f; // Скорость движения
        [SerializeField] private float rotationSpeed = 10f; // Скорость поворота

        private Rigidbody _rb;
        //понадобится для других скиптов
        public float Speed
        {
            get => speed;
            set => speed = value; // Позволяет изменять значение скорости
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // Оси
            float horizontalInput = Input.GetAxis("Vertical");
            float verticalInput = Input.GetAxis("Horizontal"); 

            // Создание движения
            Vector3 moveInput = new Vector3(horizontalInput, 0, verticalInput);

            
            Vector3 normalizedMoveInput = moveInput.normalized;

            // Поворот
            if (normalizedMoveInput != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(normalizedMoveInput);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // Перемещение 
            transform.Translate(normalizedMoveInput * speed * Time.deltaTime, Space.World);
        }
    }
}

