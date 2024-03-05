using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StageController : MonoBehaviour
{
    [SerializeField] int stageID;
    [SerializeField] GameObject cinemachineCam;
    public static Action onPlayerChangeStage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StageManager.currentStage = stageID;
            Debug.Log("Current stage is now" +  stageID);
            cinemachineCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cinemachineCam.SetActive(false);
            onPlayerChangeStage?.Invoke();
        }
    }
}
