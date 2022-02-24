using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;// mp3

}


public class SoundManager : MonoBehaviour
{   
    [Header("사운드등록")]
    [SerializeField] Sound[] bgmSounds;


    [Header("브금플레이어")]
    [SerializeField] AudioSource bgmPlayer;

    // Start is called before the first frame update
    void Start()
    {
        PlayRandomBGM();
    }

    // Update is called once per frame
    public void PlayRandomBGM()
    {
        int random = Random.Range(0,2);
        bgmPlayer.clip = bgmSounds[random].clip;

        bgmPlayer.Play();
    }

}
