using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : PlayerStates
{
    private Rigidbody rb;
    private float m_speed;

    public Hub(Controls player) : base(player)
    {
        rb = m_me.GetComponent<Rigidbody>();
        m_speed = m_me.GetComponent<Controls>().getSpeed();
    }


    public override void onUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(h * m_speed, rb.velocity.y, v * m_speed);
        if (rb.velocity != Vector3.zero)
        {
            m_me.transform.forward = rb.velocity;
        }
    }


    public override void incrementBar(int value)
    {
        //throw new System.NotImplementedException();
    }
    public override void OnTriggerExit(Collider collision)
    {
        m_me.pressE.gameObject.SetActive(false);
    }
    public override void OnTriggerStay(Collider collision)
    {
        m_me.pressE.gameObject.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("state change");
            switch (collision.gameObject.tag)
            {
                case "Treadmill":
                    m_me.ChangeState(new Treadmill(m_me));
                    break;
                case "Bike":
                    break;
                case "PunchBag":
                    m_me.ChangeState(new PunchBag(m_me));
                    break;
            }
        }
    }
}
