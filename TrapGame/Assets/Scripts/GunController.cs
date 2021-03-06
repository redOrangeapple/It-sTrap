using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    [Header("현재 장착된 총")]
    [SerializeField] Gun currentGun;

    float currentShootingRate;

    [SerializeField] Text txt_CurrentGun;


    // Start is called before the first frame update
    void Start()
    {
        currentShootingRate = 0;
        BulletUISetting();
    }

    public void BulletUISetting()
    {
         txt_CurrentGun.text = "x "+ currentGun.bulletcount;

    }

    // Update is called once per frame
    void Update()
    {   
        ShootingRateCalc();
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
        if(Input.GetButton("Fire1") && currentGun.bulletcount >0)
        {
            if(currentShootingRate<=0)
            {
                currentShootingRate = currentGun.ShootingRate;

                Fire();
            }
            
        }

    }

    void Fire()
    {   
        // Debug.Log("총 발사");
        currentGun.bulletcount--;
        BulletUISetting();
        currentGun.ps_Muzzle_Flash.Play();
        currentGun.animator.SetTrigger("GunFire");

        SoundManager.instance.PlaySE(currentGun.sound_fire);


        var clone = Instantiate(currentGun.go_Bullet_Prefab,currentGun.ps_Muzzle_Flash.transform.position
                               ,Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward*currentGun.speed);
    }



    void ShootingRateCalc()
    {
        if(currentShootingRate >0)
        {
            currentShootingRate-= Time.deltaTime;
        }

    }
}
