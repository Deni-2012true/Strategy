using UnityEngine;

public class Radar : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private float findTime = 0f;
    public Vector3 treePosition;
    public bool inFind = false;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        inFind = true;
    }

    void Update()
    {
        if (inFind)
        {
            if (findTime <= 280f)
            {
                findTime += Time.deltaTime * 10f;
                sphereCollider.radius = findTime;
            }
            else
            {
                sphereCollider.radius = 0.5f;
                inFind = false;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tree"))
        {
           treePosition = other.gameObject.transform.position;
           inFind = false;
           sphereCollider.radius = 0.5f;
        }
        else
        {
            inFind = true;
        }
    }
}
