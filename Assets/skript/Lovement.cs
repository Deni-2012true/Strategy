using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Скорость поворота в градусах в секунду. 
    // Попробуй значения от 720 до 1200 в Инспекторе.
    public float rotationSpeed = 900f; 

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            
            // Фиксируем, куда нужно повернуться
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            
            // Поворачиваемся плавно, но с четкой скоростью в градусах
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);                     
        }
    }
}
