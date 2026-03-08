using UnityEngine;

public class Kursor : MonoBehaviour
{
    public static bool Moving = false;
    private Rigidbody rb;
    float currentSpeed = rb.velocity.magnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {        
        currentSpeed = rb.velocity.magnitude;
        if (currentSpeed = 0f)
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

