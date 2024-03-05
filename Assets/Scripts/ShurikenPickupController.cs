using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenPickupController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerAttack>().ShurikenPickup(5);
            gameObject.SetActive(false);
        }
    }
}
