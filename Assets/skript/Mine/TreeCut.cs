using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public int treeHP = 3;
    public Animator animator;

    private AudioSource audioSource;
    public AudioClip TreeFallSound;
    
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        treeHP -= damage;
        if (treeHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            animator.SetTrigger("Fall");
            audioSource.PlayOneShot(TreeFallSound);
            Destroy(gameObject, 2.2f);
        }
        else
        {
            animator.SetTrigger("Hit");
        }
        
    }
}