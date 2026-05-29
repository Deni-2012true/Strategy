using UnityEngine;

public class OreMine : MonoBehaviour
{
    public int oreHP = 8;

    public void TakeDamage(int damage)
    {
        oreHP -= damage;
        if (oreHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            Destroy(gameObject);
        }
    }
}