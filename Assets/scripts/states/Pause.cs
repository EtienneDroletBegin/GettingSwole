using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : PlayerStates
{
    private Canvas pauseMenu;
    public Pause(Controls player) : base(player)
    {
        pauseMenu = m_me._pause;
        pauseMenu.gameObject.SetActive(true);
    }

    public override void incrementBar(int value)
    {

    }
    public override void onUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.gameObject.SetActive(false);
            m_me.ChangeState(new Hub(m_me));
        }
    }
    public override void OnTriggerStay(Collider collision)
    {

    }
    public override void OnTriggerExit(Collider collision)
    {

    }

}
