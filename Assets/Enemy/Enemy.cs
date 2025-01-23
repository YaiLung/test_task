using UnityEngine;
// ��� ���������� ����� ��� ������������ box collaider
public class Enemy : MonoBehaviour
{
    public int damage = 50; // ���� ������� ������� ����

    private void OnCollisionEnter(Collision collision)
    {
        // ��������� ���� �� � ������� � ������� ��������� ������������ ��������� HPController
        HPController playerHP = collision.gameObject.GetComponent<HPController>();

        if (playerHP != null)
        {
            // �������� �������� � ������
            playerHP.TakeDamage(damage);
        }
    }
}

