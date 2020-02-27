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

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActiveExplosion();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveTrail();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ActiveFireworks();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ActiveShakeScreen();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ActiveSoundEffect();
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ActiveParalax();
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ActiveSmoothMove();
        }
    }

    public void ActiveExplosion()
    {
        if (explosionAnim)
            explosionAnim = false;
        else
            explosionAnim = true;
        Debug.Log("active explosion");
    }

    public void ActiveTrail()
    {
        if (trail)
            trail = false;
        else
            trail = true;
        Debug.Log("active trail");
    }

    public void ActiveFireworks()
    {
        if (fireworks)
            fireworks = false;
        else
            fireworks = true;
        Debug.Log("active fireworks");
    }

    public void ActiveShakeScreen()
    {
        if (shakeScreen)
            shakeScreen = false;
        else
            shakeScreen = true;
        Debug.Log("active shakeScreen");
    }

    public void ActiveSoundEffect()
    {
        if (soundEffect)
            soundEffect = false;
        else
            soundEffect = true;
        Debug.Log("active soundEffect");
    }

    public void ActiveParalax()
    {
        if (paralax)
            paralax = false;
        else
            paralax = true;
        Debug.Log("active paralax");
    }

    public void ActiveSmoothMove()
    {
        if (smoothMove)
            smoothMove = false;
        else
            smoothMove = true;
        Debug.Log("active smoothMove");
    }
}
