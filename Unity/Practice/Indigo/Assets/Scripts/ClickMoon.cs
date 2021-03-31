using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoon : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.50f;
    public Vector3 upDirect = new Vector3(0, 1, 1);

    public GameObject boat;
    public GameObject moon;
    public float moonDistance;
    public bool onClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moonDistance = moon.transform.position.y;
        if (onClicked && moonDistance < 100)
        {
            moon.transform.position = moon.transform.position + upDirect * speed * Time.deltaTime;
        }
    }
    public void OnClickItem()
    {
        if (19 < moonDistance)
        {
            onClicked = true;
        }

    }
}
