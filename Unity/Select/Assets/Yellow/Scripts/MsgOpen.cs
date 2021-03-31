using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgOpen : MonoBehaviour
{
    public GameObject TextMsg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMsg()
    {
        TextMsg.SetActive(true);
    }
}
