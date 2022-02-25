using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("피격 이벤트")]
    [SerializeField] GameObject go_RicochetEffect;

    [Header("총알 데미지")]
    [SerializeField] int damage;

    [Header("피격효과음")]
    [SerializeField] string sound_Ricochet;
    

    //다른 콜라이더와 충돌하는 순간 호출 되는 함수
    void OnCollisionEnter(Collision other) {
        
        ContactPoint contactPoint = other.contacts[0];

        SoundManager.instance.PlaySE(sound_Ricochet);

        var clone = Instantiate(go_RicochetEffect,contactPoint.point
                        ,Quaternion.LookRotation(contactPoint.normal)); //LookRotation 특정방향을 보도록만듬

        Destroy(clone,0.5f);
        Destroy(gameObject);
    }
}
