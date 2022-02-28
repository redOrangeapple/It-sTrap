using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype
{
    Score,
    Normal_Gun_Bullet,
}


public class Item : MonoBehaviour
{
    public Itemtype itemtype; // 아이템 유형    
   
   public int extraScore; // 추가점수

   public int extraBullet; // 추가획득 총알


    private void Update() {
        transform.Rotate(new Vector3(0,90,0)*Time.deltaTime);
    }


}
