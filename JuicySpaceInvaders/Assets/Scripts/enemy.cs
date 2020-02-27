using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Collider2D collider;

    [SerializeField]
    private GameObject enemyBulletPrefab;

    [SerializeField]
    private GameObject explosionParent;

    public GameObject explosionAnim;

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
            GameManager.Instance.DeleteFromEnemyList(this);

            LaunchEnemyDeathAnim(gameObject.transform.position, explosionParent);    // lance l'anim d'explosion du vaisseau enemy

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    public void EnemyShoot()
    {
        Debug.Log("enemy SHOOOOOOOOT");
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }

    public void LaunchEnemyDeathAnim(Vector3 enemyPos, GameObject exploParent)
    {
        Instantiate(explosionAnim, enemyPos, Quaternion.identity, exploParent.transform);
        //StartCoroutine(WaitForDeleteExploAnim(exploParent));
    }

    public IEnumerator WaitForDeleteExploAnim(GameObject exploParent)
    {
        if (exploParent.transform.childCount > 0)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("Destroy");
            for(int i = 0; i <= exploParent.transform.childCount; i++)
                Destroy(exploParent.transform.GetChild(i).gameObject);
        }
    }
}
