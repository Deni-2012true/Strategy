using UnityEngine;

public class OreMine : MonoBehaviour
{
    private AudioSource audioSource;
    public int oreHP = 8;
    public AudioClip PickMiningSound;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
    {
        oreHP -= damage;
        if (oreHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            Destroy(gameObject);
        }
        else
        {
            audioSource.PlayOneShot(PickMiningSound, 1f);
        }
    }
}