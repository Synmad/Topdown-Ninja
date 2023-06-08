using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackForce;


    [SerializeField] GameObject shurikenprefab;
    [SerializeField] Transform attackpoint;

    public void Shuriken()
    {
        GameObject shuriken = Instantiate(shurikenprefab, attackpoint.position, Quaternion.identity);
        shuriken.GetComponent<Rigidbody2D>().AddForce(attackpoint.right * attackForce);
    }
}
