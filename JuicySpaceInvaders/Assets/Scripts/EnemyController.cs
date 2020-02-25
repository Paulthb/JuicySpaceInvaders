using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    public float screenLimit = 10.5f;
    
    //public GameObject shot;
    //public float fireRate = 0.997f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.2f, 1f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            
            if (enemy.position.x < -screenLimit || enemy.position.x > screenLimit)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (enemy.position.y <= -4)
            {
                //perdu
            }
        }

        if(enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }
    }
}
