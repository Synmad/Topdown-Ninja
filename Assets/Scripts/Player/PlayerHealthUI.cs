using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
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

    private void Start() { UpdateHealth(); }

    void UpdateHealth()
    {
        curHealth = player.curHealth; maxHealth = player.maxHealth;

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

}
