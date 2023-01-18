using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public bool more = true;
    public static EnemyPooling instatnce;


    public GameObject enemyOne;
    private List<GameObject> enemyPool;
    public int enemyCreateCount;
    public static EnemyPooling instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(this.gameObject);
        }
    }
    void start()
    {
        CreateEnemy();
    }
    private void CreateEnemy() 
    {
        enemyPool= new List<GameObject>();
        for (int i = 0; i < enemyCreateCount; i++) 
        {
            GameObject obj = Instantiate(enemyOne);
            obj.SetActive(false);
            enemyPool.Add(obj);
        }
    }
    public GameObject GetEnemyOne() 
    {
        foreach (GameObject tmpObj in enemyPool) 
        {
            if(!tmpObj.activeInHierarchy) return tmpObj;
        }

        if (more)
        {
            GameObject obj = Instantiate(enemyOne);
            obj.SetActive(true);
            enemyPool.Add(obj);
            return obj;
        }
        else 
        {
            return null;
        }
    }
}
