using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoColorWorld : MonoBehaviour
{
    // public string thisColor;
    public string nextScene;
    public GameObject textColor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {
        // SceneManager.LoadScene(nextScene);
    }

    public void ClickObject()
    {
        // SceneManager.LoadScene(nextScene);
        LoadingSceneManager.LoadScene(nextScene);
    }
}
