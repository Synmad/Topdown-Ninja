using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    public bool loading = false;

    Vector2 initialPosition;
    [SerializeField] GameObject sprite;

    private void OnEnable()
    {
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
        yield return new WaitForSeconds(0.7f);
        sprite.SetActive(true);
        loading = false;
    }

    private void OnDisable()
    {
        StageController.onPlayerChangeStage -= StartReload;
    }
}
