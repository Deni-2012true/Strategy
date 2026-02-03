using UnityEngine;

public class Playercontroler : MonoBehaviour
{
    public float speed = 3f;
    public float jump = 2f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector3 (0, 0, 1) * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        
    }
}
