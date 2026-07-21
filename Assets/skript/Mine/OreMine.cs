using UnityEngine;

public class OreMine : MonoBehaviour
{
    public BoxCollider BoxCol;
    public CapsuleCollider CapCol;

    private AudioSource audioSource;
    public AudioClip PickMiningSound;

    public int oreHP = 8;

    public Enventory enventory;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BoxCol = GetComponent<BoxCollider>();
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
            Destroy(gameObject);
        }
        else
        {
            audioSource.PlayOneShot(PickMiningSound, 1f);
        }
    }
}