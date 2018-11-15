using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastManager : MonoBehaviour
{

    public LayerMask layerMask;
    public float raycastDistance;
    public float timer;
    GameObject lastObjectHit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Raycasting();

    }

    void Raycasting()
    {

        // give me which direction i'm facing
        Vector3 fwd = GetComponentInChildren<Camera>().transform.TransformDirection(Vector3.forward);

        // prepare a thing in which you're going to record whatever i encounter
        RaycastHit hit = new RaycastHit();


        //if the ray starting from this position, in the forward direction, for a certain distance
        if (Physics.Raycast(transform.position, fwd, out hit, raycastDistance))
        {

            hit.transform.gameObject.GetComponent<SphereManager>().ShowSphere(); //we call the function on the object we just hit
            lastObjectHit = hit.transform.gameObject;
        }
        else
        {
            Debug.Log("hit nothing");
            Debug.DrawRay(transform.position, fwd*raycastDistance, Color.red);

            lastObjectHit.GetComponent<SphereManager>().Reset();
        }
    }

}
