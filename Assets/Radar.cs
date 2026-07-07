using UnityEngine;

public class Radar : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private float findTime = 0f;

    public Vector3 treePosition;
    public bool inFind = false;
    public GameObject currentTarget;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        inFind = true;
        currentTarget = null;
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
                currentTarget = null;
            }
        }
        else
        {
            if (currentTarget != null && !currentTarget.activeInHierarchy)
            {
                ResetRadar();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tree"))
        {
            treePosition = other.gameObject.transform.position;
            currentTarget = other.gameObject;
            inFind = false;
            sphereCollider.radius = 0.5f;
        }
    }

    public void ResetRadar()
    {
        inFind = true;
        findTime = 0f;
        sphereCollider.radius = 0.5f;
        currentTarget = null;
        treePosition = Vector3.zero;
    }
}