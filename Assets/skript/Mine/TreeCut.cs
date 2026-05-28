using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public static int TreeHP = 3;

    public GameObject Axe;

    void Update()
    {
       if (TreeHP < 1) 
       {
        TreeHP = 3;
        Axe.SetActive(false);
        Destroy(gameObject);
       }
    }
}
