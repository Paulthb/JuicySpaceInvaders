using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject bulletPrefab;

    private Rigidbody2D rb;

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

        if (Input.GetAxisRaw("Shoot") != 0)
            Instantiate(bulletPrefab);
    }
}
