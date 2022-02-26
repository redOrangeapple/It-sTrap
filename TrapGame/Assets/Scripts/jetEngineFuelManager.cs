using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class jetEngineFuelManager : MonoBehaviour
{

    [SerializeField] float maxFuel; // 최대 연료

    float currentFuel;

    [SerializeField]  //재충전 대기시간
    float  waitReachargeFuel;

    float currentWaitRechargeFuel ; // 계산
    [SerializeField]
    float rechargespeed; // 재충전속도

    [SerializeField] Slider slider_jetEngine;
    [SerializeField] Text txt_jetEngine;

    PlayerController thePC;
    public bool IsFuel{get; private set;}


    // Start is called before the first frame update
    void Start()
    {
        currentFuel = maxFuel;
        slider_jetEngine.maxValue = maxFuel;
        slider_jetEngine.value = currentFuel;
        thePC = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFuel();
         
        Usedfuel();

            slider_jetEngine.value = currentFuel;
            txt_jetEngine.text = Mathf.Round((currentFuel/maxFuel  *100f)).ToString() + " %";


    }


    void CheckFuel()
    {
        if(currentFuel >0)
        IsFuel = true;
        else 
        IsFuel = false;

    }
    void Usedfuel()
    {
        if(thePC.IsJet)
        {
            slider_jetEngine.gameObject.SetActive(true);
            currentFuel -= Time.deltaTime;
            currentWaitRechargeFuel=0;
            if(currentFuel <=0)
                currentFuel = 0;
        }
        else
        {
            FuelRecharge();
        }

    }

    void FuelRecharge()
    {
        if(currentFuel < maxFuel)
        {
            currentWaitRechargeFuel += Time.deltaTime;

            if(currentWaitRechargeFuel >= waitReachargeFuel)
            {
                currentFuel += rechargespeed *Time.deltaTime;

            }



        }
        else
        {
            slider_jetEngine.gameObject.SetActive(false);

        }


    }
}
