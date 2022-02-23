using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //카메라의 좌표값
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 moussPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x,Input.mousePosition.y,cameraPos.x));

        Vector3 target = new Vector3(0f,moussPos.y,moussPos.z);
        transform.LookAt(target);

    }
}
