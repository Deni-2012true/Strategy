using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public static int HP = 3;

    void Start()
    {
        
    }

    void Update()
    {
       if (HP < 1) 
       {
        Destroy(gameObject);
       }
    }
}
