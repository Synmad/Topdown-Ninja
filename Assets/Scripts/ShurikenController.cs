using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    private void OnBecameInvisible(){ Destroy(gameObject); }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.CompareTag("Enemy")){ Destroy(gameObject); }
    }
}
