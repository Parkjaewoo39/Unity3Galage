using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;  //생성할 적의 원본 프리팹
    public float spawnRateMin = 0.5f;   //최소 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform target;   //발사할 대상
    private float spawnRate;    //생성 주기
    private float timeAfterSpawn;    //최근 생성 시점에서 지난 시간
    private Vector3 direction;
    private Vector3 direction_;

    // Start is called before the first frame update


    void Start()
    {        
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        target = FindObjectOfType<PlayerController>().transform;
        //direction = target.position;

    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn갱신
        timeAfterSpawn += Time.deltaTime;
        Vector3 pos = this.transform.position;
        //if(timeAfterSpawn >= spawnRate)
        //{            

            //timeAfterSpawn = 0f;     
            direction = target.position;
            for (int a = 0; a < 3; a++) 
            {
                if (timeAfterSpawn >= spawnRate)
                {
                    var enemyOne = EnemyPooling.GetObject();
                    if (enemyOne != null)
                    {
                        timeAfterSpawn = 0f;
                        enemyOne.transform.position = pos;
                        enemyOne.transform.LookAt(direction);
                        enemyOne.Shoot(direction);

                    }
                    spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                }
            }


        //}
    }
}
