using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewEnemyFlash : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    [SerializeField] float flashDuration;
    [SerializeField] int flashCount;
    [SerializeField] SpriteRenderer sprite;

    Material defaultMaterial;

    private void Awake()
    {
        defaultMaterial = sprite.material;
    }

    public void StartFlashing()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        int flashesDone = 0;

        while(flashesDone < flashCount)
        {
            sprite.material = flashMaterial;
            yield return new WaitForSeconds(flashDuration);
            sprite.material = defaultMaterial;
            flashesDone++;
            yield return new WaitForSeconds(flashDuration);
        }
        
    }
}
