using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchBag : PlayerStates
{
    private float punchValue = 0;
    private Slider punchbar;

    public PunchBag(Controls player) : base(player)
    {
        AudioManager.GetInstance().playSound("miniGameStart", m_me.transform.position);
        punchbar = m_me._punch.transform.GetChild(0).GetComponent<Slider>();
        punchbar.gameObject.SetActive(true);
        m_me.GetComponent<Animator>().SetBool("Punching", true);
        m_me._punch.GetComponent<UI>().StartBubbleCoroutine();
        
    }

    public void incrementPunch(float val)
    {

    }

    public override void onUpdate()
    {
        
    }

    public override void incrementBar(int value)
    {
        punchValue += value;
        punchbar.value = punchValue;
        if(punchbar.value >= 100)
        {
            punchbar.value = 0;
            AudioManager.GetInstance().playSound("miniGameWin", m_me.transform.position);
            punchbar.gameObject.SetActive(false);
            m_me._punch.GetComponent<UI>().StopBubbleRoutine();
            InvManager.GetInstance().AddToInventory(EInventoryItem.STRONG);
            m_me.ChangeState(new Hub(m_me));
            m_me.GetComponent<Animator>().SetBool("Punching", false);
        }
    }

    public override void OnTriggerExit(Collider collision)
    {
        
    }

    public override void OnTriggerStay(Collider collision)
    {
        m_me.pressE.gameObject.SetActive(false);
    }

}
