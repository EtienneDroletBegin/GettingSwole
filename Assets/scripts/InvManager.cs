using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EInventoryItem
{
    FAST,
    STRONG
}

[System.Serializable]
public struct invdata{
    public EInventoryItem name;
    public string desc;
    public Sprite image;
}

public class InvManager : MonoBehaviour
{
    private List<EInventoryItem> inventory;
    [SerializeField]private invdata newItem;
    [SerializeField]private Sprite fastImage;
    [SerializeField]private Sprite strongImage;
    [SerializeField]private Sprite emptySlot;
    [SerializeField] private Button endGame;

    #region Singleton

    private static InvManager m_Instance;

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

        inventory = new List<EInventoryItem>();
    }

    public static InvManager GetInstance()
    {
        return m_Instance;
    }

    #endregion


    public void AddToInventory(EInventoryItem name)
    {
        newItem = new invdata();
        if(name == EInventoryItem.FAST)
        {
            newItem.name = EInventoryItem.FAST;
            newItem.image = fastImage;
        }
        else if (name == EInventoryItem.STRONG)
        {
            newItem.name = EInventoryItem.STRONG;
            newItem.image = strongImage;
        }
        inventory.Add(newItem.name);
        SaveSystem.Save(inventory);

        foreach(Transform child in transform)
        {
            if(child.tag != "used")
            {
                child.tag = "used";
                child.GetChild(2).GetComponent<Image>().sprite = newItem.image;
                break;
            }
        }

        if(inventory.Count == 8)
        {
            endGame.interactable = true;
        }
    }

    public void loadInventory(List<EInventoryItem>inventory)
    {
        int currentSlot = 0;
        foreach (Transform child in transform)
        {
            Sprite image = emptySlot;
            if(inventory.Count > currentSlot)
            {
                if (inventory[currentSlot] == EInventoryItem.FAST)
                {
                    image = fastImage;
                    child.tag = "used";
                }
                else if (inventory[currentSlot] == EInventoryItem.STRONG)
                {
                    image = strongImage;
                    child.tag = "used";
                }
            }
            child.GetChild(2).GetComponent<Image>().sprite = image;
            currentSlot++;
        }
    }

}
