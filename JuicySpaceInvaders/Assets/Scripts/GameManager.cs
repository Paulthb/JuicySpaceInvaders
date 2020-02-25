using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private List<enemy> enemyList;
    [SerializeField]
    private float enemyShootCooldown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyWillShoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call by enemy script
    #region Call By Enemy
    public void RegisterToEnemyList(enemy theEnemy)
    {
        enemyList.Add(theEnemy);
    }

    public void DeleteFromEnemyList(enemy theEnemy)
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

        int rdmValue = Random.Range(0, enemyList.Count);
        enemyList[rdmValue].EnemyShoot();

        StartCoroutine(EnemyWillShoot());
    }

    public void Victory()
    {
        Debug.Log("YOU WIN !");
    }

    public void Defeat()
    {
        Debug.Log("YOU LOOSE !");
    }
}
