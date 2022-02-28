using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Gun[] Guns;

    GunController theGc;

    [SerializeField] Transform tf_player;

    const int NORMAL_GUN = 0 ;

    private void Start() {
        theGc = FindObjectOfType<GunController>();
    }   


    private void OnTriggerEnter(Collider other) {
            if(other.transform.CompareTag("Item"))
            {
                Item item = other.GetComponent<Item>();

                int extra = 0 ; 

                if(item.itemtype == Itemtype.Score)
                {
                    SoundManager.instance.PlaySE("Score");
                    extra = item.extraScore;
                    ScoreManager.ExtraScore += extra;
                    

                }
                else if(item.itemtype == Itemtype.Normal_Gun_Bullet)
                {

                    SoundManager.instance.PlaySE("Score");
                    extra = item.extraBullet;
                    Guns[NORMAL_GUN].bulletcount += extra;
                    theGc.BulletUISetting();

                }
                  string msg = "+" + extra;

                FloatingTextManager.instance.CreateFloatingText(tf_player.transform.position,msg);
     

            


                Destroy(other.gameObject);
            }
    }
}
