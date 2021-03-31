using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetItem;
    public GameObject player;
    public GameObject boat;
    private MeshCollider itemCollider;

    private Vector3 offset = new Vector3(0, 2, 0);
    public bool onClicked = false;
    public void OnClickItem(bool isClickAt)
    {
        onClicked = true;
        itemCollider.enabled = false;
    }

    void Start()
    {
        itemCollider = targetItem.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onClicked)
        {
            targetItem.transform.position = player.transform.position + player.transform.forward + offset;
            targetItem.transform.rotation = player.transform.rotation;
        }
    }

    public void ClickBoat()
    {
        onClicked = false;
    }
}
