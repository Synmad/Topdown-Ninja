using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass : MonoBehaviour
{
    [SerializeField] int curHealth;
    [SerializeField] int maxHealth;

    //public void TakeDamage(int damageAmount)
    //{
    //    curHealth -= damageAmount;
    //    if (curHealth <= 0) { Destroy(gameObject); }
    //}

    public int CurHealth
    {
        get { return curHealth; }
        set 
        { 
            curHealth = value;
            if (curHealth <= 0)
            {
                Destroy(this.gameObject);
            } 
        }
    }
}
