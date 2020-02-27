using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float cloudSpeed;

    [SerializeField]
    private float CloudRespawnHeight = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (JuicyManager.Instance.paralax)
        {
            transform.Translate(Vector3.down * cloudSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CloudKillZone")
        {
            transform.position = new Vector3(transform.position.x, CloudRespawnHeight, transform.position.z);
        }
    }
}
