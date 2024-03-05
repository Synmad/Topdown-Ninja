using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    [SerializeField] float force;

    [SerializeField] int myStageID;

    GameObject player;
    Rigidbody2D rb;
    EnemyReset reset;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        reset = GetComponent<EnemyReset>();
        StageController.onPlayerChangeStage += StartShooting;
    }

    private void StartShooting()
    {
        if(StageManager.currentStage == myStageID)
        {
            StartCoroutine(Shoot());
        }
        
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Debug.Log("shootin");
            Vector2 direction = player.transform.position - transform.position;

            GameObject shuriken = ShurikenPool.instance.GetPooledShurikens();
            shuriken.tag = "Enemy";
            shuriken.SetActive(true);
            shuriken.transform.position = this.transform.position; shuriken.transform.rotation = Quaternion.identity;
            shuriken.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);

            yield return new WaitForSeconds(attackCooldown);
        }
    }
}
