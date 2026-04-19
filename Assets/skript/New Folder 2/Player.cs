using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public Animator Playercontroler;
    public bool canattack = true;
    public float speed = 100f;
    private Rigidbody rb;
    public float angleLeft = -1f;
    public static bool Chopping = false;
    public static bool Mining = false;
    public static bool OreMining = false;
    public static bool HerbPick = false;

    void Update()
    {
        AnimatorClipInfo[] clipInfo = Playercontroler.GetCurrentAnimatorClipInfo(0);
        if (Input.GetKey(KeyCode.W))
        {
            Playercontroler.SetBool("Walk", true);
        }else if (Input.GetKeyDown(KeyCode.E) && canattack == true)
        {
            canattack = false;
            Playercontroler.SetTrigger("Attack");
        }
        else
        {   
            Playercontroler.SetBool("Walk", false);
        }

        if (clipInfo[0].clip.name == "Mutant Punch")
        {
            canattack = false;
        }
        else 
        {
            canattack = true;
        }
        
        
        if (Input.GetKey(KeyCode.S))
        {
            Playercontroler.SetBool("Walk", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Playercontroler.SetBool("Walk", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Playercontroler.SetBool("Walk", true);
        }
    
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PlayAnimations());

            IEnumerator PlayAnimations()
            {
                Playercontroler.SetTrigger("Chopping");
                yield return new WaitForSeconds(1f);
                Chopping = true;
                Mining = true;
                OreMining = true;
                HerbPick = true;
            }
            

            
        }

    }
}