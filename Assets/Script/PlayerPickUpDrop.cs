using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private float pickUpDistance = 3f;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private ObjectGrabbable objectGrabbable;

    private void TryGrabObject()
    {
        // Onko esine kädessä? Tehdään raycast ja etitään esine.
        if (!objectGrabbable && Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask) &&
            raycastHit.transform.TryGetComponent(out objectGrabbable))
        {
            // Jos raycast löytää esineen se kutsuu Grab metodin.
            objectGrabbable.Grab(objectGrabPointTransform);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // If hand has no object, try grab object; else drop object. simple
            if (objectGrabbable)
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
            else
            {
                TryGrabObject();
            }
        }
    }
}
