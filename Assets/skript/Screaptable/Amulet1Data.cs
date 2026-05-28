using UnityEngine;

[CreateAssetMenu(fileName = "Amulet1Data", menuName = "Scriptable Objects/Amulet1Data")]
public class Amulet1Data : ScriptableObject
{
    [Header("Название")]
    public string AmuletName;

    [Header("Ранг")]
    public string rangName;
    public int rangNumber; 

    [Header("Защита")]
    public string protectionName;
    public int protectionNumber;

    [Header("Особенности")]
    public string feature;
    public string featureName;
    public int featureNumber; 

    //Debuff 
}
