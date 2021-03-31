using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeLightEvent : MonoBehaviour
{
    public GameObject light;
    bool lightStatus = true;
    public GameObject lightstand;
    VRGaze vrgaze;
    public Material[] material;
    public Material[] lightmaterial;
    public Renderer rend;
    public Renderer lightrend;






    // Start is called before the first frame update
    void Start()
    {
        vrgaze = GameObject.Find("Player").GetComponent<VRGaze>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        //lightrend = lightstand.GetComponent<MeshRenderer>();
        // lightmaterial = lightrend.materials
        lightmaterial = lightstand.GetComponent<MeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnOffLight()
    {
        if (!lightStatus && vrgaze.lightonetime == 1) 
        {
            Debug.Log("Turnon");
            light.SetActive(true);
            lightStatus = true;
            Debug.Log(material[0]);
            lightmaterial[0] = material[0];
            lightstand.GetComponent<MeshRenderer>().materials = lightmaterial;



        }
        else if (lightStatus && vrgaze.lightonetime == 1)
        {
            Debug.Log("Turnoff");
            light.SetActive(false);
            lightStatus = false;
            Debug.Log(material[1]);
            // MeshRenderer lightRenderer = lightstand.GetComponent<MeshRenderer>();
            lightmaterial[0] = material[1];
            lightstand.GetComponent<MeshRenderer>().materials = lightmaterial;
            // lightstand.GetComponent<MeshRenderer>().materials[0] = material[1];


        }
    }

    // void Replace(GameObject obj1, GameObject obj2)
    // {
    //    Instantiate(obj2, obj1.transform.position, Quaternion.identity);
    //   Destroy(obj1);
    //}
}
