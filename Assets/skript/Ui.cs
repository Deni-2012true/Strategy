using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public Profesion targetWorker;

    public void ClickWoodcutter()
    {
        targetWorker.SetWoodcutter();
    }

    public void ClickMason()
    {
        targetWorker.SetMason();
    }

    public void ClickHunter()
    {
        targetWorker.SetHunter();
    }

    public void ClickFisherman()
    {
        targetWorker.SetFisherman();
    }

    public void ClickHerbalist()
    {
        targetWorker.SetHerbalist();
    }

    public void ClickBuilder()
    {
        targetWorker.SetBuilder();
    }
}

