using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private TrailRenderer trail;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 10 * Time.deltaTime);

        if (JuicyManager.Instance.trail)
            trail.enabled = true;
        else
            trail.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "killzone")
        {
            Destroy(gameObject);
            //Debug.Log("bullet destroy normally");
        }
    }
}
