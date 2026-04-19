using UnityEngine;

public class picking : MonoBehaviour
{
    public static int HerbHP = 1;

    void Update()
    {
        if (HerbHP < 1) 
        {
        HerbHP = 3;
        Destroy(gameObject);
        }
    }
}
