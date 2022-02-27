using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
            if(other.transform.CompareTag("Item"))
            {
                Item item = other.GetComponent<Item>();

                if(item.itemtype == Itemtype.Score)
                {
                    SoundManager.instance.PlaySE("Score");
                    Debug.Log(item.extraScore+"를 획득했습니다");

                }
                Destroy(other.gameObject);
            }
    }
}
