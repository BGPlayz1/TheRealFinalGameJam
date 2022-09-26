using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    public GameObject interactableNotification;

    public void pickupItem()
    {
        Destroy(gameObject);
        Destroy(interactableNotification);
        

    }
}
