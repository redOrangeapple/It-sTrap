using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool canMove = true;

    [Header("무빙 속도 조절")]
   [SerializeField] float moveSpeed;
   [SerializeField] float jetPackSpeed;

    Rigidbody theRigid;

    public bool IsJet{get ; private set;}
 
    
    [Header("부스터")]
    [SerializeField] ParticleSystem ps_LeftEngine;
    [SerializeField] ParticleSystem ps_Right_Engine;

    AudioSource audioSource;

    jetEngineFuelManager thefuel;



    // Start is called before the first frame update
    void Start()
    {
        IsJet = false;
        theRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        thefuel = FindObjectOfType<jetEngineFuelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Trymove();
        TryJet();
    }


    void Trymove()
    {
        if(Input.GetAxisRaw("Horizontal")!=0 && canMove)
        {
            // 좌우 방향키 리턴
            Vector3 moveDir = new Vector3(0,0,Input.GetAxisRaw("Horizontal"));
            // Addforce 특정 방향으로 힘을 가함
            theRigid.AddForce(moveDir*moveSpeed);
        }

    }

    void TryJet()
    {

        if(Input.GetKey(KeyCode.Space) && thefuel.IsFuel && canMove)
        {
            if(!IsJet)
            {
                ps_LeftEngine.Play();
                ps_Right_Engine.Play();
                audioSource.Play();
                IsJet = true;
            }

    
            theRigid.AddForce(Vector3.up*jetPackSpeed);
        }
        else
        {
            theRigid.AddForce(Vector3.down*jetPackSpeed);
            if(IsJet)
            {
                ps_LeftEngine.Stop();
                ps_Right_Engine.Stop();
                audioSource.Stop();

                IsJet = false;
            }

        }

    }

}
