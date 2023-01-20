using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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
        

        float xSpeed = xInput*speed;
        
        Vector3 newVelocity = new Vector3();
        Vector3 pos = this.transform.position;

        newVelocity = new Vector3(xSpeed, 0f, 0f);
        
    
        playerRigidbody.velocity = newVelocity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = ObjectPool.GetObject(); 
            if (bullet != null)
            {

                var direction = new Vector3(0, 0, 0.03f);
                bullet.transform.position = pos;
                bullet.Shoot(direction);

            }
            else { }

        }
    }


    public void Die() 
    {
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
    }
}
