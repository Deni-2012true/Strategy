using UnityEngine;

public class RockMine : MonoBehaviour
{
    private AudioSource audioSource;
    public int rockHP = 5;
    public AudioClip PickMiningSound;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
    {
        rockHP -= damage;
        if (rockHP <= 0)
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