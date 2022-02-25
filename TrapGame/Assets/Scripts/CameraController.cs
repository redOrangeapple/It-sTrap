using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("따라갈 플레이어 설정")]
    [SerializeField] Transform tf_Player;

    [Header("따라갈 스피드 조정")]
    [Range(0,1f)] [SerializeField] float chaseSpeed;

    float camNormalXpos;
    [SerializeField] [Header("부스터시 떨어질 거리")]
    float camJetPos;
    float camCurrentXpos;

    PlayerController theplayer;


    // Start is called before the first frame update
    void Start()
    {
        theplayer = tf_Player.GetComponent<PlayerController>();
        camNormalXpos = this.transform.position.x;
        camCurrentXpos = camNormalXpos;
    }

    // Update is called once per frame
    void Update()
    {

        if(theplayer.IsJet)
            camCurrentXpos = camJetPos;
        else
            camCurrentXpos = camNormalXpos;
        

        Vector3 movePos = Vector3.Lerp(transform.position, tf_Player.position,chaseSpeed);

        float cameraposx = Mathf.Lerp(transform.position.x,camCurrentXpos,chaseSpeed);
        transform.position = new Vector3(cameraposx,movePos.y,movePos.z);

    }
}
