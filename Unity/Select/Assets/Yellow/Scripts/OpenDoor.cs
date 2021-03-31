using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject notKeyMsg;
    public GameObject door;
    public GameObject key;
    public GameObject realDoor;

    private float doorSpeed = 5.0f;

    private bool haveKey = false;
    private bool openDoor = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(openDoor && -17 <= realDoor.transform.position.z)
        {
            realDoor.transform.position -= new Vector3(0, 0, 1) * doorSpeed * Time.deltaTime;
        }
    }

    public void ClickDoor()
    {
        if (haveKey)
        {
            openDoor = true;
        }
        else
        {
            notKeyMsg.SetActive(true);
        }
    }

    public void ClickKey()
    {
        haveKey = true;
        key.SetActive(false);
    }
}
