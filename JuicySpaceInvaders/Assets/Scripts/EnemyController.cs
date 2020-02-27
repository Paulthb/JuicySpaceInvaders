using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    public float screenLimit = 10.5f;

    private bool startFight = false;
    //public GameObject shot;
    //public float fireRate = 0.997f;

    // Start is called before the first frame update
    void Start()
    {
        enemyHolder = GetComponent<Transform>();
    }

    void Update()
    {
        if (GameManager.Instance.isLevelStart && !startFight)
        {
            InvokeRepeating("MoveEnemy", 0.3f, 1f);
            startFight = true;
        }
        
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
                GameManager.Instance.Defeat();
            }
        }

        //gère l'accélération en fonction du nombre restant de vaisseaux
        if (enemyHolder.childCount <= 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.2f, 0.25f);
        }
        else if (enemyHolder.childCount < 10)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.4f, 0.4f);
        }
        else if (enemyHolder.childCount < 17)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.6f, 0.6f);
        }
        else if (enemyHolder.childCount < 25)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.8f, 0.8f);
        }
    }
}
