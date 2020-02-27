using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuicyManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static JuicyManager _instance;

    public static JuicyManager Instance { get { return _instance; } }
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

    [System.NonSerialized]
    public bool gameStart = false;

    public bool explosionAnim = true;
    public bool trail = true;
    public bool fireworks = true;
    public bool shakeScreen = true;
    public bool soundEffect = true;
    public bool paralax = true;
    public bool smoothMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart == false)
        { 
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log("lancement Juicy!");
                GameManager.Instance.JuicyGame();
                gameStart = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("lancement normale");
                GameManager.Instance.NormaleGame();
                gameStart = true;
            }
        }
    }
}
