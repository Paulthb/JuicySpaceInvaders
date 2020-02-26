using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(Transform destination)
    {
        GameObject enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        StartCoroutine(EnemyPlacement(destination, enemyObject.transform));
    }

    public IEnumerator EnemyPlacement(Transform destination, Transform enemyTransform)
    {
        //Gotoposition = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);

        float elapsedTime = 0;
        float waitTime = 2f;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(enemyTransform.position, destination.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        SpawnManager.Instance.SpawnEnemy();
    }
}
