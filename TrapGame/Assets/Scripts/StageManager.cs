using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] Text txt_currentScore;
    [SerializeField] GameObject go_UI; 

    [SerializeField] ScoreManager theSM;

    [SerializeField] Rigidbody PlayerRigid;

    [SerializeField] GameObject[] go_Stages;

    [SerializeField] Transform tf_OriginPos;

    int CurrentStage = 0 ;

    public void ShowClearUI()
    {
        PlayerController.canMove = false;
        PlayerRigid.isKinematic = true;
        go_UI.SetActive(true);
        txt_currentScore.text = string.Format("{0:000,000}",theSM.GetCurrentScore());

    }

    public void NExtBtn()
    {
        if(CurrentStage < go_Stages.Length -1)
        {
            PlayerController.canMove = true;
            PlayerRigid.isKinematic = false;
            go_UI.SetActive(false);
            PlayerRigid.gameObject.transform.position = tf_OriginPos.position;
            go_Stages[CurrentStage++].SetActive(false);
            go_Stages[CurrentStage].SetActive(true);
            theSM.ResetCurrentScore();

        }
        else Debug.Log("모든 스테이지 클리어");
    }




}
