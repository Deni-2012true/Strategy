using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator paladin;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            paladin.SetBool("Walk", true);
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            paladin.SetTrigger("Attack");
        }
        else
        {   
            paladin.SetBool("Walk", false);
        }
        
    }
}
