using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bug"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Sell"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Ticks"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trashbag"))
        {
            Destroy(other.gameObject);
        }
    }
}
