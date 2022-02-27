using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Itemtype
{
    Score,
    Bullet,
}


public class Item : MonoBehaviour
{
    public Itemtype itemtype; // 아이템 유형    
   
   public int extraScore; // 추가점수

}
