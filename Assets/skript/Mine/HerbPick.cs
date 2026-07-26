using UnityEngine;

public class HerbPick : MonoBehaviour
{
    public CapsuleCollider CapCol;

    private AudioSource audioSource;
    public AudioClip PickingSound;

    public Enventory enventory;
    public InventoryUI inventoryUI;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CapCol = GetComponent<CapsuleCollider>();
    }
    public void TakeDamage()
    {
        audioSource.PlayOneShot(PickingSound, 1f);
        CapCol.enabled = false;
        enventory.herbQuantity += 1;
        //Destroy(gameObject, 1f);
        inventoryUI.RefreshUI();
        gameObject.SetActive(false);
    }
}