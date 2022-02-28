using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int CurrentScore; // 현재점수

    public int GetCurrentScore()
    {
        return CurrentScore;
    }

    public void ResetCurrentScore()
    {
        CurrentScore = 0 ; 
        DistanceScore = 0 ;
        MaxDistance = 0 ;
        ExtraScore = 0 ;   
    }

    public static int ExtraScore;  //아이템점수
 
    int DistanceScore ; // 거리점수

    float MaxDistance; /// 플레이어가 이동한 최대거리 기억
    
    float OriginPosz; // 플레이어의 최초 위치값

    [SerializeField] Text text_Score;

    [SerializeField] Transform tf_Player; // 플레이어의 위치정보

    // Update is called once per frame

    private void Start() {
        OriginPosz = tf_Player.position.z;
    }   
    
    void Update()
    {

        if(tf_Player.position.z > MaxDistance)
        {
            MaxDistance = tf_Player.position.z;
            
            DistanceScore = Mathf.RoundToInt(MaxDistance-OriginPosz);


        }


        CurrentScore = ExtraScore + DistanceScore;
        text_Score.text = string.Format("{0:000,000}",CurrentScore);
        
    }
}
