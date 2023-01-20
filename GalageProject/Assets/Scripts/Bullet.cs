using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        Invoke("DestroyBullet", 1.5f);
    }

    public void DestroyBullet()
    {
        ObjectPool.ReturnObject(this);
        CancelInvoke();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyOne")
        {
            EnemyOne monster = other.GetComponent<EnemyOne>();
           
           
            if (monster != null)
            {
                monster.Die();
                Invoke("DestroyBullet", 0);
                GameManager manager = FindObjectOfType<GameManager>();
                //manager.ScoreAdd();
            }
        }

    }
    void Update()
    {
        transform.Translate(direction);
    }
}
