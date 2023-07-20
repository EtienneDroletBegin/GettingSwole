using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private Canvas _pressE;
    public Canvas pressE
    {
        get
        {
            return _pressE;
        }
    }
    [SerializeField] private GameObject punchBag;
    [SerializeField] private GameObject treadmill;
    [SerializeField] private GameObject bike;
    [SerializeField] private Canvas runBar;
    [SerializeField] private Canvas punch;
    [SerializeField] private GameObject PunchBubble;
    [SerializeField] private Canvas PauseMenu;
  public  GameObject _PunchBubble
    {
        get
        {
            return PunchBubble;
        }
    }
    public Canvas _runbar
    {
        get
        {
            return runBar;
        }

    }
    public Canvas _punch
    {
        get
        {
            return punch;
        }

    }
    public Canvas _pause
    {
        get
        {
            return PauseMenu;
        }

    }

    private PlayerStates m_currentState;
    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        AudioManager.GetInstance().playSound("OST", transform.position);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        m_currentState = new Hub(this);
    }

    void Update()
    {
        anim.SetFloat("vel", rb.velocity.magnitude);
        m_currentState.onUpdate();
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeState(new Pause(this));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        m_currentState.OnTriggerStay(other);
    }

    public void ChangeState(PlayerStates newstate)
    {
        m_currentState = newstate;
    }

    private void OnTriggerExit(Collider other)
    {

        m_currentState.OnTriggerExit(other);
    }

    public void incrementPunchBar()
    {
        AudioManager.GetInstance().playSound("punch", transform.position);
        m_currentState.incrementBar(10);
    }

    public float getSpeed()
    {
        return speed;
    }

    public GameObject getTreadmill()
    {
        return treadmill;
    }
}
