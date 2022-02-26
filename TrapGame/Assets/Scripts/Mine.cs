using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{   
    [SerializeField] float verticalDistance; // 수직움직임

    [SerializeField] float horizontalDistance;// 수평 움직임

    [Range(0,1)]
    [SerializeField] float moveSpeed;

    [SerializeField] int Mine_Hp;
    [SerializeField] int damage;
    [SerializeField] GameObject go_EffectPrefab;

    Vector3 endPos1;
    Vector3 endPos2;

    Vector3 currentDestination;

    void Start() 
    {
        Vector3 originPos = transform.position;

        endPos1.Set(originPos.x,originPos.y+verticalDistance,originPos.z + horizontalDistance);
        endPos2.Set(originPos.x,originPos.y-verticalDistance,originPos.z - horizontalDistance);

        currentDestination = endPos1;
    }

    void Update() {

        if((transform.position - endPos1).sqrMagnitude<=0.1f) // 거듭제곱의 형태
            currentDestination = endPos2;
            else if((transform.position - endPos2).sqrMagnitude<=0.1f)
            currentDestination= endPos1;

        transform.position = Vector3.Lerp(transform.position,currentDestination,moveSpeed)
;    } 


     void OnCollisionEnter(Collision other) {
        if(other.transform.name=="Player")
        {

            Debug.Log("플레이어와 충돌했습니다");
            other.transform.GetComponent<StatusManager>().DrecreaseHp(damage);
               Explosion();
                   
        }
  

    }
    public void Damaged(int _num)
    {
        Mine_Hp -= _num;
        if(Mine_Hp<=0)
        {
            Explosion();
        }

    }

    void Explosion()
    {
            var clone = Instantiate(go_EffectPrefab,transform.position,Quaternion.identity);
            Destroy(clone,2f);

            Destroy(gameObject); 

    }
}
