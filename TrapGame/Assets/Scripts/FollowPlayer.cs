using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [Header("엔진 회전속도")] [Range(0,1)]
    [SerializeField]protected float spinspeed;
    
    [Header("따라갈 대상 지정")]        
    [SerializeField] protected Transform tf_player;    

    [Header("따라갈 속도지정")] [Range(0,1)]
    [SerializeField]protected float speed;


   protected  Vector3 CurrentPos;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentPos = tf_player.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {                               //lerp 보간법이용 일정한 거리 유지
        this.transform.position = Vector3.Lerp(this.transform.position , tf_player.position-CurrentPos,speed);
    }
}
