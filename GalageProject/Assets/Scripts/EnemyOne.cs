using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//고에이 몸통 박치기 적
public class EnemyOne : MonoBehaviour
{
    public float Espeed = 10f;
    private Rigidbody enemyRigidbody;
    private Vector3 direction = default;
    
    
    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        transform.LookAt(direction);
        enemyRigidbody.velocity = transform.forward * Espeed;        

        Invoke("DestroyEnemyOne", 4f);
    }
    private void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
         
        
       
    }
    private void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
                       
            if(playerController != null)
            {
                
                playerController.Die();
                this.Die();
            }
        }
    }
    public void Die()
    {
        Invoke("DestroyEnemyOne", 0);
    }

    public void DestroyEnemyOne() 
    {
        EnemyPooling.ReturnObject(this);
        CancelInvoke();
    }
    
}
