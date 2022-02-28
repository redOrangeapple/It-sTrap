using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloatingText : MonoBehaviour
{
    [SerializeField] float destorytime;
    [SerializeField] Animation anime;

    // Start is called before the first frame update
    void Start()
    {
        anime.Play();
        Destroy(gameObject,destorytime);
    }

    // Update is called once per frame

}
