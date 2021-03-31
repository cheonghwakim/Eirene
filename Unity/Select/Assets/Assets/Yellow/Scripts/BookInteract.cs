using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteract : MonoBehaviour
{
    public GameObject curState;
    public GameObject nextState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        nextState.SetActive(true);
        curState.SetActive(false);
    }
}
