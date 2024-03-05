using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    public bool loading;

    Vector2 initialPosition;
    GameObject sprite;

    private void Awake()
    {
        sprite = GameObject.Find("EnemySprite");
        initialPosition = transform.position;
        StageController.onPlayerChangeStage += StartReload;
    }

    void StartReload()
    {
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        loading = true;
        sprite.SetActive(false);
        transform.position = initialPosition;
        yield return new WaitForSeconds(1);
        sprite.SetActive(true);
        loading = false;
    }
}
