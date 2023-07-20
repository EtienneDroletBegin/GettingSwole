using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStates
{
    protected Controls m_me;

    public PlayerStates(Controls player)
    {
        m_me = player;
    }

    public abstract void incrementBar(int value);
    public abstract void onUpdate();
    public abstract void OnTriggerStay(Collider collision);
    public abstract void OnTriggerExit(Collider collision);

}
