using UnityEngine;
using TMPro;

public class AmuletPopap : MonoBehaviour
{
    public Amulet1Data amulet1Data;

    public TextMeshProUGUI protectionName_Text;
    public TextMeshProUGUI protectionNumber_Text;
    
    public TextMeshProUGUI rangName_Text;
    public TextMeshProUGUI rangNamber_Text; 

    public TextMeshProUGUI name_Text;

    void Start()
    {
        protectionName_Text.text = amulet1Data.protectionName;
        protectionNumber_Text.text = "+" + amulet1Data.protectionNumber.ToString();  

        rangName_Text.text = amulet1Data.rangName;
        rangNamber_Text.text = amulet1Data.rangNumber.ToString();

        name_Text.text = amulet1Data.name;
    }
}