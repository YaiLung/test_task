using UnityEngine;
// скрипт для врага, при контакте отнимается здоровье
public class Enemy : MonoBehaviour
{
    public int damage = 50; 

    private void OnCollisionEnter(Collision collision)
    {
   
        HPController playerHP = collision.gameObject.GetComponent<HPController>();

        if (playerHP != null)
        {
            
            playerHP.TakeDamage(damage);      
        }
    }
}
