using UnityEngine;

public class Profesion : MonoBehaviour
{
    private bool Woodcutter = false;
    private bool Mason = false;
    private bool Hanter = false;
    private bool Fisherman = false;
    private bool Herbalist = false;
    private bool Builder = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Woodcutter = true;
            Mason = false;
            Hanter = false;
            Fisherman = false;
            Herbalist = false;
            Builder = false;
            Debug.Log("Дровосек");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Woodcutter = false;
            Mason = true;
            Hanter = false;
            Fisherman = false;
            Herbalist = false;
            Builder = false;
            Debug.Log("Шахтёр");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Woodcutter = false;
            Mason = false;
            Hanter = true;
            Fisherman = false;
            Herbalist = false;
            Builder = false;
            Debug.Log("Охотник");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Woodcutter = false;
            Mason = false;
            Hanter = false;
            Fisherman = true;
            Herbalist = false;
            Builder = false;
            Debug.Log("Рыбак");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Woodcutter = false;
            Mason = false;
            Hanter = false;
            Fisherman = false;
            Herbalist = true;
            Builder = false;
            Debug.Log("Собиратель трав");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Woodcutter = false;
            Mason = false;
            Hanter = false;
            Fisherman = false;
            Herbalist = false;
            Builder = true;
            Debug.Log("Строитель");
        }
    }
    public void SetWoodcutter()
    {
        Woodcutter = true;
        Mason = false;
        Hanter = false;
        Fisherman = false;
        Herbalist = false;
        Builder = false;
    }

    public void SetMason()
    {
        Woodcutter = false;
        Mason = true;
        Hanter = false;
        Fisherman = false;
        Herbalist = false;
        Builder = false;
    }

    public void SetHunter()
    {
        Woodcutter = false;
        Mason = false;
        Hanter = true;
        Fisherman = false;
        Herbalist = false;
        Builder = false;
    }

    public void SetFisherman()
    {
        Woodcutter = false;
        Mason = false;
        Hanter = false;
        Fisherman = true;
        Herbalist = false;
        Builder = false;
    }

    public void SetHerbalist()
    {
        Woodcutter = false;
        Mason = false;
        Hanter = false;
        Fisherman = false;
        Herbalist = true;
        Builder = false;
    }

    public void SetBuilder()
    {
        Woodcutter = false;
        Mason = false;
        Hanter = false;
        Fisherman = false;
        Herbalist = false;
        Builder = true;
    }
}
