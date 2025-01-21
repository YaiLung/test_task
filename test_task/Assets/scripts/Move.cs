using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ��������� ����������� 
namespace Move
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float speed = 5f; // �������� ��������
        [SerializeField] private float rotationSpeed = 10f; // �������� ��������

        private Rigidbody _rb;
        //����������� ��� ������ �������
        public float Speed
        {
            get => speed;
            set => speed = value; // ��������� �������� �������� ��������
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // ���
            float horizontalInput = Input.GetAxis("Vertical");
            float verticalInput = Input.GetAxis("Horizontal"); 

            // �������� ��������
            Vector3 moveInput = new Vector3(horizontalInput, 0, verticalInput);

            
            Vector3 normalizedMoveInput = moveInput.normalized;

            // �������
            if (normalizedMoveInput != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(normalizedMoveInput);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // ����������� 
            transform.Translate(normalizedMoveInput * speed * Time.deltaTime, Space.World);
        }
    }
}

