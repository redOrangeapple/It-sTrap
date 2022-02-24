using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("총구섬광")]
    [SerializeField]  ParticleSystem ps_MuzzleFalsh;

    [Header("총항 플리팹")]
    [SerializeField] GameObject go_bullet_Prefab;
    
    [Header("총알 스피드")]
    [SerializeField] float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        TryFire();
        LockOnMouse();
    }

    void LockOnMouse()
    {
               //카메라의 좌표값
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 moussPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x,Input.mousePosition.y,cameraPos.x));

        Vector3 target = new Vector3(0f,moussPos.y,moussPos.z);
        transform.LookAt(target);
    }
    void TryFire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    void Fire()
    {   
        Debug.Log("총 발사");
        ps_MuzzleFalsh.Play();
        var clone = Instantiate(go_bullet_Prefab,ps_MuzzleFalsh.transform.position,Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed);
    }
}
