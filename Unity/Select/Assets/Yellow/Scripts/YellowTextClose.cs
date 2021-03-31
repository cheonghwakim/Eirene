using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTextClose : MonoBehaviour
{
    public GameObject closeBtn;
    public GameObject closeTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickClose()
    {
        closeTarget.SetActive(false);
    }
}
