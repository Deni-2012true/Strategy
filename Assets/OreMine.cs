using UnityEngine;

public class OreMine : MonoBehaviour
{
    public static int OreHP = 3;

    public GameObject Pick;

    void Update()
    {
        if (OreHP < 1) 
        {
        OreHP = 3;
        Pick.SetActive(false);
        Destroy(gameObject);
        }
    }
}
