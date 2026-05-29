using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public int treeHP = 3;

    public void TakeDamage(int damage)
    {
        treeHP -= damage;
        if (treeHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            Destroy(gameObject);
        }
    }
}