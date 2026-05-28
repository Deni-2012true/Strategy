using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private Slider hpSlider;

    void Start()
    {
        hpSlider = GetComponent<Slider>();
    }

    void Update()
    {
        hpSlider.value = PlayerMovement.HP;
    }
}
