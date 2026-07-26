using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Enventory inventory;
    public GameObject slotPrefab;
    public Transform slotsParent;
    public int stackSize = 20;

    public void RefreshUI()
    {
        foreach (Transform child in slotsParent)
            Destroy(child.gameObject);

        CreateSlotsForResource(inventory.pineQuantity, inventory.pineIcon);
        CreateSlotsForResource(inventory.stoneQuantity, inventory.stoneIcon);
        CreateSlotsForResource(inventory.copperQuantity, inventory.copperIcon);
        CreateSlotsForResource(inventory.herbQuantity, inventory.herbIcon);
    }

    void CreateSlotsForResource(int totalAmount, Sprite icon)
    {
        if (totalAmount <= 0 || icon == null) return;

        int fullStacks = totalAmount / stackSize;
        int remainder = totalAmount % stackSize;

        for (int i = 0; i < fullStacks; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotsParent);
            slot.GetComponentInChildren<Image>().sprite = icon;
            slot.GetComponentInChildren<TextMeshProUGUI>().text = stackSize.ToString();
        }

        if (remainder > 0)
        {
            GameObject slot = Instantiate(slotPrefab, slotsParent);
            slot.GetComponentInChildren<Image>().sprite = icon;
            slot.GetComponentInChildren<TextMeshProUGUI>().text = remainder.ToString();
        }
    }

    private void Start()
    {
        RefreshUI();
    }
}