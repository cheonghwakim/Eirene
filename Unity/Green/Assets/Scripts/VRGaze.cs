using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;

    public float totalTime = 2;
    public bool gvrStatus = false;
    public bool gvrparticleStatus = false ;
    float gvrTimer;
    public float lightonetime = 0;
    

    public int distanceOfRay = 10;
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
            }
        

            if (imgGaze.fillAmount == 1 && gvrStatus && _hit.transform.CompareTag("Standinglight"))
            {
                lightonetime += 1;
                _hit.transform.GetComponent<GazeLightEvent>().OnOffLight();
             
            }

        }


    }

    public void GVROn()
    {
        gvrStatus = true;
    }
    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        lightonetime = 0;
    }

    public void particleGVRCheck()
    {
        if (gvrparticleStatus)
        {
            Debug.Log("start Particle false");
            gvrparticleStatus = false;
        } else
        {
            Debug.Log("start Particle true");
            gvrparticleStatus = true;
        }
    }
    public void particleGVROff()
    {
        gvrparticleStatus = false;
    }
}
