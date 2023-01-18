using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;   //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; //이동 속력
      
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        
        
        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput*speed;
        

        //Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3();
        newVelocity =new Vector3(xSpeed, 0f, 0f);
        
        //리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;       
    }

    public void Die() 
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
    }
}
