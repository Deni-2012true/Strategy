using UnityEngine;

public class RockMine : MonoBehaviour
{
    public static int RockHP = 3;

    public GameObject Pick;

    void Update()
    {
        if (RockHP < 1) 
        {
        RockHP = 3;
        Pick.SetActive(false);
        Destroy(gameObject);
        }
    }
}
