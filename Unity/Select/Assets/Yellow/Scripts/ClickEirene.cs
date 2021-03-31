using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEirene : MonoBehaviour
{
    public GameObject eirene;
    public GameObject finalBook;
    public GameObject eireneStar;
    public MeshCollider eireneCollider;

    private string nextScene = "1_SelectStage";
    // Start is called before the first frame update
    void Start()
    {
        eireneCollider = eirene.GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBook()
    {
        eireneCollider.enabled = true;
        eireneStar.SetActive(true);
    }

    public void ClickFinal()
    {
        LoadingSceneManager.LoadScene(nextScene);
    }
}
