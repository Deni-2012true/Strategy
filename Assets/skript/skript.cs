using UnityEngine;

public class skript : MonoBehaviour
{
    public string playname = "Strategy";
    public float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Debug.Log (playname);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3 (1, 0, 0) * Time.deltaTime * speed);
    }
}
