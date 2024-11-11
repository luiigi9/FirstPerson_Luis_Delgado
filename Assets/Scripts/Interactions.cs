using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distanceI;
    private Transform objectI;
    // Start is called before the first frame update
    void Start()
    {
       cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanceI))
        {
            if (hit.transform.CompareTag("Ammo"))
            {
                Debug.Log("Ammo Detected");
                objectI = hit.transform;
                //objectI.GetComponent<Outline>().enabled = true;
            }
            
        }
        else if (objectI)
        {
            //objectI.GetComponent<Outline>().enabled = false;
            objectI = null;
        }
    }
}
