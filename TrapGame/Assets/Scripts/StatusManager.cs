using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    [SerializeField] int maxHp;
    int cur_Hp;

    [SerializeField] Text[] text_HParray; // 체력 UI

    bool isInvinciblemode = false; // 현재 무적상태


    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;


    [SerializeField] MeshRenderer mesh_PlayerGraphics;

    private void Start() {
        cur_Hp = maxHp;
        UpdateHpState();
    }


    public void DrecreaseHp(int _num)
    {
        if(!isInvinciblemode)
        {
            cur_Hp -= _num;
            UpdateHpState();

            if( cur_Hp <=0)
            {
                PlayerDead();

            }

            SoundManager.instance.PlaySE("HitSound");
            StopAllCoroutines();
            StartCoroutine(BlinkCoroutine());
        }
    }

    public void IncreaseHp(int _num)
    {

        if(cur_Hp == maxHp)
        return;

        cur_Hp += _num;

        if(cur_Hp>= maxHp)
        cur_Hp= maxHp;
        UpdateHpState();
    }

    IEnumerator BlinkCoroutine()
    {
        isInvinciblemode = true;

        for(int i = 0 ; i< blinkCount*2;i++)
        {
            mesh_PlayerGraphics.enabled =! mesh_PlayerGraphics.enabled;

            yield return new WaitForSeconds(blinkSpeed);

        }

        isInvinciblemode = false;

    }

    void UpdateHpState()
    {
        for(int i = 0 ; i <text_HParray.Length; i++)
        {
            if( i < cur_Hp)
            {
                text_HParray[i].gameObject.SetActive(true);
            }
            else
            {
                text_HParray[i].gameObject.SetActive(false);
            }

        }

    }

    void PlayerDead()
    {
        SceneManager.LoadScene("Title");

    }

}
