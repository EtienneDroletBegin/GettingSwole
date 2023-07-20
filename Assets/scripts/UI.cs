using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Text timer;
    [SerializeField] private GameObject punchBubble;

    private Coroutine bubbleRoutine;

    public void ChangeTimer(float time)
    {
        timer.text = time.ToString("F2");
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + 4, player.position.z);
    }

    public void Load()
    {
        SaveData loadedData = SaveSystem.Load();
        InvManager.GetInstance().loadInventory(loadedData.inventory);
    }

    public void EndGame()
    {

    }

    public void StartBubbleCoroutine()
    {
        bubbleRoutine = StartCoroutine("Bubble");
    }

    public void StopBubbleRoutine()
    {
        StopCoroutine(bubbleRoutine);
    }

    IEnumerator Bubble()
    {
        Rect punchrect = GetComponent<RectTransform>().rect;
        float minX = punchrect.xMin;
        float maxX = punchrect.xMax;
        float minY = punchrect.yMin;
        float maxY = punchrect.yMax;
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            GameObject newBubble = Instantiate(punchBubble);
            newBubble.transform.SetParent(transform);
            newBubble.transform.position = new Vector2(randomX, randomY);
           
        }
    }
}
