using UnityEngine;

public class OreMine : MonoBehaviour
{
    public SphereCollider BoxCol;
    public CapsuleCollider CapCol;

    private AudioSource audioSource;
    public AudioClip PickMiningSound;

    public int oreHP = 8;

    public Enventory enventory;
    public InventoryUI inventoryUI;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BoxCol = GetComponent<SphereCollider>();
        CapCol = GetComponent<CapsuleCollider>();
    }
    public void TakeDamage(int damage)
    {
        oreHP -= damage;
        if (oreHP <= 0)
        {
            BoxCol.enabled = false;
            CapCol.enabled = false;
            enventory.copperQuantity += 3;
            inventoryUI.RefreshUI();
            Destroy(gameObject);
        }
        else
        {
            audioSource.PlayOneShot(PickMiningSound, 1f);
        }
    }
}