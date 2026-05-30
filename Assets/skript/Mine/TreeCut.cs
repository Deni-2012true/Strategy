using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public int treeHP = 3;
    public Animator animator;

    public void TakeDamage(int damage)
    {
        treeHP -= damage;
        if (treeHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            animator.SetTrigger("Fall");
            Destroy(gameObject, 2.2f);
        }
        else
        {
            animator.SetTrigger("Hit");
        }
        
    }
}