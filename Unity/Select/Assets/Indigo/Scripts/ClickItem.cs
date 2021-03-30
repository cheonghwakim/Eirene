using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetItem;
    public GameObject player;
    private Vector3 offset = new Vector3(0, 3, 0);
    public bool onClicked = false;
    public void OnClickItem(bool isClickAt)
    {
        Debug.Log(isClickAt);
        onClicked = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onClicked)
            targetItem.transform.position = player.transform.position + player.transform.forward;
        if (onClicked)
            targetItem.transform.rotation = player.transform.rotation;
    }
}
