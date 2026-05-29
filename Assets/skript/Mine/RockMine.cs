using UnityEngine;

public class RockMine : MonoBehaviour
{
    public int rockHP = 5;

    public void TakeDamage(int damage)
    {
        rockHP -= damage;
        if (rockHP <= 0)
        {
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;
            Destroy(gameObject);
        }
    }
}