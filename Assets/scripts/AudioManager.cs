using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    private static AudioManager m_Instance;

    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static AudioManager GetInstance()
    {
        return m_Instance;
    }

    #endregion

    [SerializeField]
    private AudioClip miniGameSuccess;
    [SerializeField]
    private AudioClip punchingMusic;
    [SerializeField]
    private AudioClip punch;
    [SerializeField]
    private AudioClip miniGameFailed;
    [SerializeField]
    private AudioClip miniGameStart;
    [SerializeField]
    private AudioClip click;
    [SerializeField]
    private AudioPool audioPool;


    public void playSound(string soundToPlay, Vector3 pos)
    {
        switch (soundToPlay)
        {
            case "miniGameWin":
                audioPool.GetAvailableAudio(pos).PlayOneShot(miniGameSuccess);
                break;
            case "punch":
                audioPool.GetAvailableAudio(pos).PlayOneShot(punch);
                break;

            case "OST":
                audioPool.GetAvailableAudio(pos).PlayOneShot(punchingMusic);
                break;
            case "miniGameFail":
                audioPool.GetAvailableAudio(pos).PlayOneShot(miniGameFailed);
                break;
            case "miniGameStart":
                audioPool.GetAvailableAudio(pos).PlayOneShot(miniGameStart);
                break;
            case "click":
                audioPool.GetAvailableAudio(pos).PlayOneShot(click);
                break;

        }
    }
}
