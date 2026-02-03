using UnityEngine;

public class Camera1 : MonoBehaviour
{
public float moveSpeed = 5f;

void Update()
    {
    // Получаем ввод
    //float horizontal = Input.GetAxis("Horizontal");
    //float vertical = Input.GetAxis("Vertical");

    //Vector3 movement = new Vector3(horizontal, 0f, 0f);

       
        // Движение
        //transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
        {
           transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
           transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
           transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
           transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }
}