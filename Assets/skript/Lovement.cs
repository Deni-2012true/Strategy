using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 900f;

    public Animator animator;           
    private bool canAttack = true;      

    public static int HP = 100;

    private AudioSource aidioPlay;
    public AudioClip GrasWalkSound;
    private float TimerSound = 4f;

    void Update()
    {
        aidioPlay = GetComponent<AudioSource>();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            aidioPlay.Stop();
            TimerSound = 0f;
        }
        if (movement.magnitude > 0.1f && TimerSound <= 0)
        {
            TimerSound = 0f;
            aidioPlay.PlayOneShot(GrasWalkSound, 1f);
        }
        if (TimerSound > 0)
        {
            TimerSound -= Time.deltaTime;
        }


        bool isWalking = movement.magnitude > 0.1f;
        
            animator.SetBool("Walk", isWalking);
            

        
        if (Input.GetKeyDown(KeyCode.E) && canAttack)
        {
            canAttack = false;
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