using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ��������� ��� ������������
public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float boostDuration = 3f; // ������������ 
    [SerializeField] private float boostCount = 2f; // ��������� 

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ��� ���������� � ��������, ������� ������ Move
        if (collision.gameObject.TryGetComponent(out Move.Move player))
        {
            
            StartCoroutine(BoostPlayerSpeed(player));
        }
    }

    private IEnumerator BoostPlayerSpeed(Move.Move player) // ���������� �������� ��������
    {
        float originalSpeed = player.Speed; 
        player.Speed *= boostCount; 
        yield return new WaitForSeconds(boostDuration); 
        player.Speed = originalSpeed; 
    }
}

