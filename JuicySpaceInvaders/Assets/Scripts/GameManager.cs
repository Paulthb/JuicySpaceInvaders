using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private List<EnemyMgr> enemyList;
    [SerializeField]
    private float enemyShootCooldown;
    [SerializeField]
    private List<ParticleSystem> americanFireworks;


    public bool isLevelStart = false;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject replayBtn;
    public GameObject player;
    public GameObject enemyContainer;

    public bool isGameFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayerEagleSound();
        StartCoroutine(SpawnManager.Instance.SpawnEnemy());
        StartCoroutine(SpawnManager.Instance.SpawnPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
            RestartGame();
    }

    //call by enemy script
    #region Call By Enemy
    public void RegisterToEnemyList(EnemyMgr theEnemy)
    {
        enemyList.Add(theEnemy);
    }

    public void DeleteFromEnemyList(EnemyMgr theEnemy)
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
        if (!isGameFinished)
        {
            Debug.Log("YOU WIN !");
            SoundManager.Instance.PlayerAmericaSound();
            winScreen.SetActive(true);
            replayBtn.SetActive(true);
            player.SetActive(false);
            isGameFinished = true;
        }
    }

    public void Defeat()
    {
        if (!isGameFinished)
        {
            SoundManager.Instance.PlayerUrssSound();
            Debug.Log("YOU LOOSE !");
            loseScreen.gameObject.SetActive(true);
            replayBtn.SetActive(true);
            enemyContainer.SetActive(false);
            isGameFinished = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        winScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
        replayBtn.SetActive(false);
        isGameFinished = false;
    }

    public void StartGame()
    {
        isLevelStart = true;
        StartCoroutine(EnemyWillShoot());
        SoundManager.Instance.PlayAerobicSound();
    }

    public void PlayAmericanFirework()
    {
        foreach(ParticleSystem firework in americanFireworks)
        {
            firework.Play();
        }
    }
}