using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("무빙 속도 조절")]
   [SerializeField] float moveSpeed;
   [SerializeField] float jetPackSpeed;

    Rigidbody theRigid;



    // Start is called before the first frame update
    void Start()
    {
        theRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Trymove();
        TryJet();
    }


    void Trymove()
    {
        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            // 좌우 방향키 리턴
            Vector3 moveDir = new Vector3(0,0,Input.GetAxisRaw("Horizontal"));
            // Addforce 특정 방향으로 힘을 가함
            theRigid.AddForce(moveDir*moveSpeed);
        }

    }

    void TryJet()
    {

        if(Input.GetKey(KeyCode.Space))
        {
            theRigid.AddForce(Vector3.up*jetPackSpeed);

        }
        else
        {
            theRigid.AddForce(Vector3.down*jetPackSpeed);

        }

    }

}
