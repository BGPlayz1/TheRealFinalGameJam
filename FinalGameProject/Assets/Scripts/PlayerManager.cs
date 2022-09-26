using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public GameObject interactableNotification;

    public void NotifyPlayer()
    {
        if (interactableNotification != null)
        interactableNotification.gameObject.SetActive(true);
        
    }

    public void DeNotifyPlayer()
    {
        if (interactableNotification != null)
            interactableNotification.gameObject.SetActive(false);
    }
}
