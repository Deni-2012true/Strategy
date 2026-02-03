using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Playercontroler;
    public bool canattack = true;
    public float speed = 100f;
    private Rigidbody rb;
    public float angleLeft = -1f;
    
    void Update()
    {
        AnimatorClipInfo[] clipInfo = Playercontroler.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(clipInfo[0].clip.name +" + canAttack = "+ canattack );
        if (Input.GetKey(KeyCode.W))
        {
            Playercontroler.SetBool("Walk", true);
            //transform.Translate(new Vector3 (0, 0, 1) * Time.deltaTime);
            //transform.Rotate(new Vector3 (1, 0, 0));
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
            //transform.Translate(new Vector3 (0, 0, -1) * Time.deltaTime);
            //transform.Rotate(new Vector3 (-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Playercontroler.SetBool("Walk", true);
            //transform.Translate(new Vector3 (1, 0, 0) * Time.deltaTime);
            //transform.Rotate(new Vector3 (0, 0, 1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Playercontroler.SetBool("Walk", true);
            //transform.Translate(new Vector3 (-1, 0, 0) * Time.deltaTime);
            //transform.Rotate(new Vector3 (0, angleLeft, 0));
            //Debug.Log("поворот влево = " + angleLeft);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }
}