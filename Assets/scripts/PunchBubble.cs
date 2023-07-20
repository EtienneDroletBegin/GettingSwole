using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchBubble : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("BuffaloHot-Sauce");
    }
    public void DestroyBubble(string success)
    {
        if (success == "true")
        {

            player.GetComponent<Controls>().incrementPunchBar();
        }
        Transform parent = transform.parent;
        Destroy(parent.gameObject);
    }
}
