using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletStartPos;
    [SerializeField]
    private float shootCooldown;
    [SerializeField]
    private GameObject ExplosionAnim;


    private Rigidbody2D rb;

    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") == 1)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetAxisRaw("Shoot") == 1 && canShoot)
        {
            canShoot = false;
            Instantiate(bulletPrefab, bulletStartPos.position, Quaternion.identity);
            StartCoroutine(TimeToShoot());
        }
    }

    IEnumerator TimeToShoot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            GameManager.Instance.Defeat();

            Instantiate(ExplosionAnim, transform.position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
