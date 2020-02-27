using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSourceSong;
    [SerializeField]
    private AudioSource audioSourceEffect;
    [SerializeField]
    private AudioSource audioSourceEffect2;

    [SerializeField]
    private AudioClip aerobic;
    [SerializeField]
    private AudioClip urss;
    [SerializeField]
    private AudioClip america;
    [SerializeField]
    private AudioClip eagle;
    [SerializeField]
    private AudioClip explosion1;
    [SerializeField]
    private AudioClip explosion2;
    [SerializeField]
    private AudioClip fuck;
    [SerializeField]
    private AudioClip shit;


    // SINGLETON ---------------------------------------------
    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }

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
    }//--------------------------------------------------------------------

    public void PlayAerobicSound()
    {
        audioSourceSong.clip = aerobic;
        audioSourceSong.Play();
    }

    public void PlayerUrssSound()
    {
        audioSourceSong.clip = urss;
        audioSourceSong.Play();
    }

    public void PlayerAmericaSound()
    {
        audioSourceSong.clip = america;
        audioSourceSong.Play();
    }

    public void PlayerExplosionSound()
    {
        int rdmsongId = Random.Range(1, 2);

        if (rdmsongId == 1)
            audioSourceEffect.clip = explosion1;
        else
            audioSourceEffect.clip = explosion2;

        audioSourceEffect.Play();
    }

    public void PlayerEagleSound()
    {
        audioSourceEffect.clip = eagle;
        audioSourceEffect.Play();
    }

    public void PlayerFuckSound()
    {
        int rdmsongId = Random.Range(1, 2);

        if (rdmsongId == 1)
            audioSourceEffect2.clip = fuck;
        else
            audioSourceEffect2.clip = shit;
        
        audioSourceEffect2.Play();
    }

}
