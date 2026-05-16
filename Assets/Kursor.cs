using UnityEngine;

public class Kursor : MonoBehaviour
{
    public static bool Moving = false;
    private Rigidbody rb;
    float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {        
        currentSpeed = rb.linearVelocity.magnitude;
        if (currentSpeed == 1f)
        {
            Moving = false;
            Debug.Log("Скорость = 0!");
        } else 
        {
            Moving = true;
            Debug.Log("Скорость больше чем 0");
        }
    } 
}

