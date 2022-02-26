using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;


    [SerializeField] MeshRenderer mesh_PlayerGraphics;


    public void DrecreaseHp(int _num)
    {
        SoundManager.instance.PlaySE("HitSound");
        StopAllCoroutines();
        StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        for(int i = 0 ; i< blinkCount*2;i++)
        {
            mesh_PlayerGraphics.enabled =! mesh_PlayerGraphics.enabled;

            yield return new WaitForSeconds(blinkSpeed);

        }

    }

}
