using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.TakeDamage(damageAmount);
            Debug.Log("Player Health: " + GameManager.Instance.health);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.TakeDamage(damageAmount);
            Debug.Log("Player Health: " + GameManager.Instance.health);
            Destroy(gameObject);
        
        }
    }


}
