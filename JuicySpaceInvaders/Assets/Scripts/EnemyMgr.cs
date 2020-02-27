using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : MonoBehaviour
{
    private Collider2D collider;

    [SerializeField]
    private GameObject enemyBulletPrefab;

    public GameObject explosionAnim;
    [SerializeField]
    private GameObject fallingAnim;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();

        GameManager.Instance.RegisterToEnemyList(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            SoundManager.Instance.PlayerExplosionSound();

            GameManager.Instance.DeleteFromEnemyList(this);

            LaunchEnemyDeathAnim(gameObject.transform.position);    // lance l'anim d'explosion du vaisseau enemy

            CameraShake.Instance.ShakeIt();

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void EnemyShoot()
    {
        Debug.Log("enemy SHOOOOOOOOT");
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }

    public void LaunchEnemyDeathAnim(Vector3 enemyPos)
    {
        Instantiate(explosionAnim, enemyPos, Quaternion.identity);
        Instantiate(fallingAnim, enemyPos, Quaternion.identity);
    }
}
