using UnityEngine;

[CreateAssetMenu(fileName = "Enventory", menuName = "Scriptable Objects/Enventory")]
public class Enventory : ScriptableObject
{
    [Header("Сосна")]
    public int pineQuantity;
    public Sprite pineIcon;

    [Header("Камень")]
    public int stoneQuantity;
    public Sprite stoneIcon;

    [Header("Руда")]
    public int copperQuantity;
    public Sprite copperIcon;

    [Header("Трава")]
    public int herbQuantity;
    public Sprite herbIcon;
}
