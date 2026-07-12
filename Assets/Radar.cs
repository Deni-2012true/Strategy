using UnityEngine;
using UnityEngine.Android;

public class Radar : MonoBehaviour
{
    private SphereCollider sphereCollider;
    private float findTime = 0f;

    public Vector3 treePosition;
    public bool inFind = false;
    public GameObject currentTarget;
    public float maxTime = 5f;
    public float minTime = 2f;
    public float timerValue;
    public float inFindTime;


    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        inFind = true;
        currentTarget = null;
        timerValue = Random.Range(minTime, maxTime);
        inFindTime = timerValue;
        Permission();
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
                Permission();
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
    public void Permission()
    {
        if (inFindTime >= 0f)
        {
            inFindTime += Time.deltaTime;
            inFind = false;
        } 
        else if(inFindTime < 0)
        {
            inFind = true;
        }
    }
}