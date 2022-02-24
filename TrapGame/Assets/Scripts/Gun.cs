using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum WeapinType
    {
        Normal_Gun,

    }

    [Header("총종류")]
    public WeapinType weapinType;

    [Header("연사속도조정")]
    public float ShootingRate;

    [Header("총알 개수")]
    public int bulletcount;
    public int maxBulletCount;

    [Header("섬광효과")]
    public ParticleSystem ps_Muzzle_Flash;

    [Header("Bullet Prefab")]
    public GameObject go_Bullet_Prefab;

    [Header("총알 스피드")]
    public float speed;



}
