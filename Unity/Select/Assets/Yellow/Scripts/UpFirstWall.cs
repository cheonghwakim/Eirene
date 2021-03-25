using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpFirstWall : MonoBehaviour
{
    public GameObject firstWall;
    public GameObject firstBookcase;
    public GameObject firstBookcase2;
    public GameObject candle1;
    public GameObject candle2;
    private float initialFirstWallY;
    private float rotationSpeed = 40.0f;
    public bool isClick = false;


    private float upSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        initialFirstWallY = firstWall.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick && candle1.transform.rotation.x < 0.7)
        {
            candle1.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (0.7 <= candle1.transform.rotation.x && 0.7 <= candle2.transform.rotation.x)
        {
            if (firstWall.transform.position.y < initialFirstWallY + 6.0f)
            {
                firstWall.transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
                firstBookcase2.transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
                firstBookcase.transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
            }
        }

    }

    public void FirstDone()
    {
        isClick = true;
    }
}
