using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Collider2D collider;

    [SerializeField]
    private GameObject enemyBulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();

        GameManager.Instance.RegisterToEnemyList(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            GameManager.Instance.DeleteFromEnemyList(this);

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void EnemyShoot()
    {
        Debug.Log("enemy SHOOOOOOOOT");
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }
}
