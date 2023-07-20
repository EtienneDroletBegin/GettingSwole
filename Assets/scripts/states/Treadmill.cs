using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treadmill : PlayerStates
{
    private KeyCode currentKeyToClick = KeyCode.A;
    public Action timerChange;
    private float runGaugeValue = 0;
    private Slider runGauge;
    private Transform A;
    private Transform D;
    private Text time;
    private float timer;


    public Treadmill(Controls player) : base(player)
    {
        AudioManager.GetInstance().playSound("miniGameStart", m_me.transform.position);
        runGauge = m_me._runbar.transform.GetChild(0).GetComponent<Slider>();
        A = m_me._runbar.transform.GetChild(1);
        D = m_me._runbar.transform.GetChild(2);
        time = m_me._runbar.transform.GetChild(3).GetComponent<Text>();
        runGauge.gameObject.SetActive(true);
        A.gameObject.SetActive(true);
        D.gameObject.SetActive(true);
        time.gameObject.SetActive(true);
        A.localScale = new Vector3(1,1,1);
        D.localScale = new Vector3(0.5f,0.5f,0.5f);
        timer = 5.0f;
        
    }

    public override void onUpdate()
    {
        m_me.transform.position = new Vector3(m_me.getTreadmill().transform.position.x, m_me.getTreadmill().transform.position.y+0.3f, m_me.getTreadmill().transform.position.z);
        m_me.transform.forward = m_me.getTreadmill().transform.forward;

        if (Input. GetKey(KeyCode.A))
        {
            if(currentKeyToClick == KeyCode.A)
            {
                currentKeyToClick = KeyCode.D;
                incrementBar(5);
                runGauge.value = runGaugeValue;
                A.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                D.localScale = new Vector3(1, 1, 1);
            }

            if (runGaugeValue >= 100)
            {
                runGauge.value = 0;
                AudioManager.GetInstance().playSound("miniGameWin", m_me.transform.position);
                runGauge.gameObject.SetActive(false);
                A.gameObject.SetActive(false);
                D.gameObject.SetActive(false);
                time.gameObject.SetActive(false);
                InvManager.GetInstance().AddToInventory(EInventoryItem.FAST);
                m_me.ChangeState(new Hub(m_me));
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            if (currentKeyToClick == KeyCode.D)
            {
                currentKeyToClick = KeyCode.A;
                incrementBar(5);
                runGauge.value = runGaugeValue;
                D.localScale = new Vector3(0.5f,0.5f,0.5f);
                A.localScale = new Vector3(1, 1, 1);
            }

            if(runGaugeValue >= 100)
            {
                runGauge.value = 0;
                AudioManager.GetInstance().playSound("miniGameWin", m_me.transform.position);
                runGauge.gameObject.SetActive(false);
                A.gameObject.SetActive(false);
                D.gameObject.SetActive(false);
                time.gameObject.SetActive(false);
                InvManager.GetInstance().AddToInventory(EInventoryItem.FAST);
                m_me.ChangeState(new Hub(m_me));
            }
        }
        timer -= Time.deltaTime;
        GameObject.Find("RUN").GetComponent<UI>().ChangeTimer(timer);
    }


    public override void OnTriggerExit(Collider collision)
    {

    }

    public override void incrementBar(int value)
    {
        runGaugeValue += value;
    }
    public override void OnTriggerStay(Collider collision)
    {
        m_me.pressE.gameObject.SetActive(false);
    }
}
