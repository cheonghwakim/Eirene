using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTele : MonoBehaviour
{
    public GameObject telescope;
    public GameObject hintMsg;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickHint()
    {
        hintMsg.SetActive(false);
    }

    public void ClickTelescope()
    {
        if (Vector3.Distance(player.transform.position, telescope.transform.position) < 3)
        {
            hintMsg.SetActive(true);
        }
    }
}
