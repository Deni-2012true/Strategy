using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Название")]
    public string name;

    [Header("Ранг")]
    public string rangName;
    public int rangNumber; 

    [Header("Атака")]
    public string attackName;
    public int attackNumber;
}
