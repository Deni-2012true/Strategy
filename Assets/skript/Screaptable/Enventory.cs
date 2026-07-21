using UnityEngine;

[CreateAssetMenu(fileName = "Enventory", menuName = "Scriptable Objects/Enventory")]
public class Enventory : ScriptableObject
{
    [Header("Сосна")]
    public int pineQuantity;

    [Header("Камень")]
    public int stoneQuantity;

    [Header("Медь")]
    public int copperQuantity;

    [Header("Трава")]
    public int herbQuantity;
}
