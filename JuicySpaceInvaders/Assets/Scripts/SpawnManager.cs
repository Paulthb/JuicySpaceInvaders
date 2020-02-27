using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Spawn> SpawnList;
    [SerializeField]
    private List<Transform> StartPositionList;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform playerDestination;

    #region SINGLETON PATTERN
    private static SpawnManager _instance;

    public static SpawnManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator SpawnPlayer()
    {
        float elapsedTime = 0;
        float waitTime = 1f;

        Vector3 basePos = playerTransform.position;

        while (elapsedTime < waitTime)
        {
            playerTransform.position = Vector3.Lerp(basePos, playerDestination.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        playerTransform.position = playerDestination.position;
        SpawnManager.Instance.SpawnEnemy();
    }

    public IEnumerator SpawnEnemy()
    {
        int rdmSpawnId;
        int rdmStartPositionId;

        while (StartPositionList.Count != 0)
        {
            rdmSpawnId = Random.Range(0, SpawnList.Count);
            rdmStartPositionId = Random.Range(0, StartPositionList.Count);

            //fonction spawn avec le spawner choisie et la destination
            SpawnList[rdmSpawnId].SpawnEnemy(StartPositionList[rdmStartPositionId]);

            //on retire la destination de la liste
            StartPositionList.Remove(StartPositionList[rdmStartPositionId]);
            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(0.2f);

        GameManager.Instance.StartGame();
    }
}
