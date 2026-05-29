using UnityEngine;

public class HerbPick : MonoBehaviour
{
    public int herbHP = 1;

    public void TakeDamage(int damage)
    {
        herbHP -= damage;
        if (herbHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            Destroy(gameObject);
        }
    }
}