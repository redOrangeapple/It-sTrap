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
    public static SoundManager instance;


    [Header("사운드등록")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;


    [Header("브금플레이어")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPalyer;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        PlayRandomBGM();
    }
    public void PlaySE(string _soundName)
    {
        for(int i = 0 ; i < sfxSounds.Length ; i++) 
        {
            if(_soundName == sfxSounds[i].soundName)
            {
                for(int x = 0 ; x <sfxPalyer.Length;x++)
                {
                    if(!sfxPalyer[x].isPlaying)
                    {
                        sfxPalyer[x].clip = sfxSounds[i].clip;
                        sfxPalyer[x].Play();
                        return;
                    }

                }
                Debug.Log("사용할수 있는 효과음 플레이어가 없습니다");
                return;
            }
            
        }
        Debug.Log("등록된 효과음이 없습니다");
    }

    // Update is called once per frame
    public void PlayRandomBGM()
    {
        int random = Random.Range(0,2);
        bgmPlayer.clip = bgmSounds[random].clip;

        bgmPlayer.Play();
    }

}
