using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    PlayerController player;
    int maxHealth; int curHealth;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        PlayerController.onPlayerHurt += UpdateHealth;
    }

    private void Start()
    {
        UpdateHealth();
    }

    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < curHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void UpdateHealth()
    {
        curHealth = player.CurHealth; maxHealth = player.MaxHealth;
    }

}
