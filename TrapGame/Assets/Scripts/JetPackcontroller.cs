using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackcontroller : FollowPlayer
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPos = tf_player.position -this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal")>0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position
             , tf_player.position-CurrentPos,speed);
             transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,0),spinspeed);

        }
        else if(Input.GetAxisRaw("Horizontal")<0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position
             , tf_player.position-new Vector3(CurrentPos.x,CurrentPos.y,-CurrentPos.z),speed);
             transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(-152,0,0),spinspeed);

        }
        else if(Input.GetAxisRaw("Horizontal") == 0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position
             , tf_player.position-new Vector3(CurrentPos.x,CurrentPos.y, 0),speed);
             transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(-90,0,0),spinspeed);
        }
    }
}
