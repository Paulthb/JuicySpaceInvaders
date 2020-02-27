using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 10 * Time.deltaTime);
        if (JuicyManager.Instance.trail)
            trail.enabled = true;
        else
            trail.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "killzone")
        {
            //SoundManager.Instance.PlayerFuckSound();
            Destroy(gameObject);
            //Debug.Log("bullet destroy normally");
        }
    }
}
