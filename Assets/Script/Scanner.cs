using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] 
    private GameObject bugPlane, nobugPlane;

    [SerializeField]
    private AudioSource bagIsOK, bagHasBugs;

    public bool scanDone = false;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Trashbag"))
        {
            nobugPlane.SetActive(true);
            bugPlane.SetActive(false);
            bagIsOK.Play();
        }
        else if (other.CompareTag("Bug"))
        {
            bugPlane.SetActive(true);
            nobugPlane.SetActive(false);
            bagHasBugs.Play();
        }
        else
        {
            nobugPlane.SetActive(false);
            bugPlane.SetActive(false);
        }
        scanDone = true;
    }

}
