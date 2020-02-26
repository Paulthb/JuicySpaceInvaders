using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<Spawn> SpawnList;
    [SerializeField]
    private List<Transform> StartPositionList;

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

    public void SpawnEnemy()
    {
        if (StartPositionList.Count != 0)
        {
            int rdmSpawnId = Random.Range(0, SpawnList.Count);
            int rdmStartPositionId = Random.Range(0, StartPositionList.Count);

            //fonction spawn avec le spawner choisie et la destination
            SpawnList[rdmSpawnId].SpawnEnemy(StartPositionList[rdmStartPositionId]);

            //on retire la destination de la liste
            StartPositionList.Remove(StartPositionList[rdmStartPositionId]);
        }
        else
            Debug.Log("LAUNCH GAME !");
    }
}
