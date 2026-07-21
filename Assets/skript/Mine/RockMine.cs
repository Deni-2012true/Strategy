using UnityEngine;

public class RockMine : MonoBehaviour
{
    public BoxCollider BoxCol;
    public CapsuleCollider CapCol;

    private AudioSource audioSource;
    public AudioClip PickMiningSound;

    public int rockHP = 5;

    public Enventory enventory;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BoxCol = GetComponent<BoxCollider>();
        CapCol = GetComponent<CapsuleCollider>();
    }
    public void TakeDamage(int damage)
    {
        rockHP -= damage;
        if (rockHP <= 0)
        {
            BoxCol.enabled = false;
            CapCol.enabled = false;
            enventory.stoneQuantity += 3;
            Destroy(gameObject);
        }
        else
        {
            audioSource.PlayOneShot(PickMiningSound, 1f);
        }
    }
}