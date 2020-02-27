using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;

    private float speed = 1.0F;

    private float startTime;
    private float timeOfTravel;

    private Transform currentDestination;
    private Transform currentTransform;

    private bool isSpawningEnemy = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (isSpawningEnemy)
        //{
        //    // Distance moved equals elapsed time times speed..
        //    float distCovered = (Time.time - startTime) * speed;

        //    // Fraction of journey completed equals current distance divided by total distance.
        //    float fractionOfJourney = distCovered / timeOfTravel;

        //    // Set our position as a fraction of the distance between the markers.
        //    currentTransform.position = Vector3.Lerp(transform.position, currentDestination.position, fractionOfJourney);
        //    Debug.Log(fractionOfJourney);
        //}
    }


    public void StartPlacement()
    {
        startTime = Time.time;
        timeOfTravel = Vector3.Distance(transform.position, currentTransform.position);
        isSpawningEnemy = true;
    }




    public void SpawnEnemy(Transform destination)
    {
        GameObject enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemyContainer.transform);

        //currentDestination = destination;
        //currentTransform = transform;

        //StartPlacement();
        StartCoroutine(EnemyPlacement(destination, enemyObject.transform));
    }

    public IEnumerator EnemyPlacement(Transform destination, Transform enemyTransform)
    {
        float elapsedTime = 0;
        float waitTime = 0.5f;

        Vector3 basePos = enemyTransform.position;

        while (elapsedTime < waitTime)
        {
            enemyTransform.position = Vector3.Lerp(basePos, destination.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        enemyTransform.position = destination.position;
        SpawnManager.Instance.SpawnEnemy();
    }
}
