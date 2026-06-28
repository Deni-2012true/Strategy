using UnityEngine;

public class HerbPick : MonoBehaviour
{
    private AudioSource audioSource;
    public int herbHP = 1;
    public AudioClip PickingSound;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
    {
        herbHP -= damage;
        if (herbHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            Destroy(gameObject);
        }
        else
        {
            audioSource.PlayOneShot(PickingSound, 1f);
        }
    }
}