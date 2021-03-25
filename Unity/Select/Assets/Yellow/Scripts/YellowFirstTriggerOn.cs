using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFirstTriggerOn : MonoBehaviour
{
    public GameObject firstCandle;
    public GameObject firstCandle2;
    public MeshCollider firstCollider;
    public MeshCollider firstCollider2;
    // Start is called before the first frame update
    void Start()
    {
        // firstCollider2 = firstCandle.GetComponent<MeshCollider>();
        firstCollider = firstCandle.GetComponent<MeshCollider>();
        firstCollider2 = firstCandle2.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectActivate()
    {
        firstCollider.enabled = true;
        firstCollider2.enabled = true;
        Debug.Log(firstCollider);
    }
}
