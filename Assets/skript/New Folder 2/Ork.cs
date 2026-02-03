using UnityEngine;

public class Ork : MonoBehaviour
{
    public Animator ork;
    public bool canattack = true;
    
    void Update()
    {
        AnimatorClipInfo[] clipInfo = ork.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(clipInfo[0].clip.name +" + canAttack = "+ canattack );
        if (Input.GetKey(KeyCode.W))
        {
            ork.SetBool("Walk", true);
        }else if (Input.GetKeyDown(KeyCode.E) && canattack == true)
        {
            canattack = false;
            ork.SetTrigger("Attack");
        }
        else
        {   
            ork.SetBool("Walk", false);
        }

        if (clipInfo[0].clip.name == "Zombie Attack")
        {
            canattack = false;
        }
        else canattack = true;
    }
}
