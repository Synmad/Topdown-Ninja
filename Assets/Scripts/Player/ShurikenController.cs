using UnityEngine;

public class ShurikenController : MonoBehaviour
{
    private void OnBecameInvisible(){ gameObject.SetActive(false); }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.CompareTag("Enemy")) gameObject.SetActive(false);
    }
}
