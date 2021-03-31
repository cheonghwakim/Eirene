using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickTarget : MonoBehaviour
{
    public GameObject target;
    public bool isClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckIsClicked()
    {
        isClicked = true;
        Debug.Log(isClicked);
    }
}
