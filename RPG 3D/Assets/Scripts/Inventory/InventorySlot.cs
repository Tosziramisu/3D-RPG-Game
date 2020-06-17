using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    
    public GameObject itemDiscardWindow;
    public Button yesButton;
    public Button noButton;

    Item item;

    void Start()
    {
        if(yesButton != null)
        {
            yesButton.onClick.AddListener(onYesButton);
        }
        if(noButton != null)
        {
            noButton.onClick.AddListener(onNoButton);
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        //itemDiscardWindow.SetActive(!itemDiscardWindow.activeSelf);
        
        Inventory.instance.Remove(item);
    }

    public void onYesButton()
    {
        Inventory.instance.Remove(item);
        itemDiscardWindow.SetActive(!itemDiscardWindow.activeSelf);
    }

    public void onNoButton()
    {
        itemDiscardWindow.SetActive(!itemDiscardWindow.activeSelf);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
