using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleOn : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    public GameObject capsule;
    public Vector3 initialCapsulePosition;
    public float capsuleDistance;
    public Vector3 upDistance = new Vector3(0, 1, 0);

    public bool onSeen = false;

    // Start is called before the first frame update
    void Start()
    {
        initialCapsulePosition = capsule.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        capsuleDistance = Vector3.Distance(capsule.transform.position, initialCapsulePosition);
        if (onSeen)
        {
            if (capsuleDistance < 4)
            {
                Debug.Log("여긴?2");
                capsule.transform.position = capsule.transform.position + speed * upDistance * Time.deltaTime;
            }
        }
    }
    public void SeeItem()
    {
        capsuleDistance = Vector3.Distance(capsule.transform.position, initialCapsulePosition);
        if (capsuleDistance < 4)
        {
            onSeen = true;
            if (capsuleDistance < 4)
            {
                Debug.Log("되냐?");
                capsule.transform.position = capsule.transform.position + speed * upDistance * Time.deltaTime;
            }
        }
    }
    public void SeeOffItem()
    {
        capsuleDistance = Vector3.Distance(capsule.transform.position, initialCapsulePosition);
        if (onSeen)
        {
            Debug.Log("되냐2?");
            if (0 < capsuleDistance)
            {
                capsule.transform.position = capsule.transform.position - speed * upDistance * Time.deltaTime;
            }
        }
    }
}
