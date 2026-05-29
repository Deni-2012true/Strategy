using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Движение")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 900f;

    [Header("Анимация и атака")]
    public Animator animator;           
    private bool canAttack = true;      

    public static int HP = 100;         

    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        
        bool isWalking = movement.magnitude > 0.1f;
        if (animator != null)
            animator.SetBool("Walk", isWalking);

        
        if (Input.GetKeyDown(KeyCode.E) && canAttack)
        {
            canAttack = false;
            if (animator != null)
                animator.SetTrigger("Attack");
        }

        
        if (animator != null && animator.GetCurrentAnimatorClipInfo(0).Length > 0)
        {
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            if (clipInfo[0].clip.name == "Mutant Punch")
                canAttack = false;
            else
                canAttack = true;
        }
    }
}