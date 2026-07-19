using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public int treeHP = 3;
    public Animator animator;

    private AudioSource audioSource;
    public AudioClip TreeFallSound;
    public AudioClip AxeCutSound;
    public float Timer;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Timer = 1f;
    }

    public void TakeDamage(int damage)
    {
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
            treeHP -= damage;
            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(AxeCutSound, 1f);
        }  
    }
}