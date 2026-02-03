using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public float moveSpeed = 5f;
public float rotationSpeed = 10f;

void Update()
    {
    // Получаем ввод
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    // Создаем вектор движения
    Vector3 movement = new Vector3(horizontal, 0f, vertical);

    if (movement.magnitude > 0.1f)
        {
        // Движение
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        // Поворот в сторону движения
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 
            rotationSpeed * Time.deltaTime);                     
        }
    }
}
