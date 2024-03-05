using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenPool : MonoBehaviour
{
    [SerializeField] GameObject shurikenPrefab;
    [SerializeField] int poolSize;

    public static ShurikenPool instance;

    List<GameObject> pooledShurikens;

    void Awake()
    {
        CreatePool();

        if(instance != null && instance != this) 
        {
            Destroy(this);
        }
        else instance = this;
    }

    void CreatePool()
    {
        pooledShurikens = new List<GameObject>();
        GameObject shurikenInstance;

        for (int i = 0; i < poolSize; i++)
        {
            shurikenInstance = Instantiate(shurikenPrefab);
            shurikenInstance.SetActive(false);
            pooledShurikens.Add(shurikenInstance);
        }
    }

    public GameObject GetPooledShurikens()
    {
        for (int i = 0; i < poolSize; i++) { if (!pooledShurikens[i].activeInHierarchy) { return pooledShurikens[i]; } }
        return null;
    }
}
