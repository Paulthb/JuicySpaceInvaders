using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }
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

    [SerializeField]
    private List<Enemy> enemyList;
    [SerializeField]
    private float enemyShootCooldown;

    public bool isLevelStart = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnManager.Instance.SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
            StartCoroutine(RestartGame());
    }

    //call by enemy script
    #region Call By Enemy
    public void RegisterToEnemyList(Enemy theEnemy)
    {
        enemyList.Add(theEnemy);
    }

    public void DeleteFromEnemyList(Enemy theEnemy)
    {
        enemyList.Remove(theEnemy);
        CheckEnemyList();
    }
    #endregion

    public void CheckEnemyList()
    {
        if (enemyList.Count == 0)
            Victory();
    }

    public IEnumerator EnemyWillShoot()
    {
        yield return new WaitForSeconds(enemyShootCooldown);
        if (enemyList.Count != 0)
        {
            int rdmValue = Random.Range(0, enemyList.Count);
            enemyList[rdmValue].EnemyShoot();
        }
        StartCoroutine(EnemyWillShoot());
    }

    public void Victory()
    {
        Debug.Log("YOU WIN !");
    }

    public void Defeat()
    {
        Debug.Log("YOU LOOSE !");
        StartCoroutine(RestartGame());
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        isLevelStart = true;
        StartCoroutine(EnemyWillShoot());
    }
}