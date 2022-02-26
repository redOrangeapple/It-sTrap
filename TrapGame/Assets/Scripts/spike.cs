using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] float force; 

    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log("플레이어가 데미지를 받음");
            other.transform.GetComponent<Rigidbody>().AddExplosionForce(force,transform.position,5f);
            other.transform.GetComponent<StatusManager>().DrecreaseHp(damage);
        }
    }

}
