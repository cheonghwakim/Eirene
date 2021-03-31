using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public GameObject gameMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) || Input.GetMouseButtonDown(1))
        {
            gameMenu.SetActive(true);
        }
    }

    public void ClickGameMenu()
    {
        gameMenu.SetActive(true);
    }
}
