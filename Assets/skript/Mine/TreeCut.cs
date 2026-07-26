using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public BoxCollider BoxCol;
    public CapsuleCollider CapCol;

    public int treeHP = 3;
    public Animator animator;

    private AudioSource audioSource;
    public AudioClip TreeFallSound;
    public AudioClip AxeCutSound;

    public Enventory enventory;
    public InventoryUI inventoryUI;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BoxCol = GetComponent<BoxCollider>();
        CapCol = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(int damage)
    {
        if (treeHP <= 0)
        {
            BoxCol.enabled = false;
            CapCol.enabled = false;
            enventory.pineQuantity += 3;
            animator.SetTrigger("Fall");
            audioSource.PlayOneShot(TreeFallSound);
            inventoryUI.RefreshUI();
            Destroy(gameObject, 3.2f);
        }
        else
        {
            treeHP -= damage;
            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(AxeCutSound, 1f);
        }  
    }
}