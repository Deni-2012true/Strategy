using UnityEngine;

public class TreeCut : MonoBehaviour
{
    public static int HP = 3;

    public GameObject Axe;

    void Update()
    {
       if (HP < 1) 
       {
        HP = 3;
        Axe.SetActive(false);
        Destroy(gameObject);
       }
    }
}
