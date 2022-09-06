using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{

    public GameObject LocalXRRigGameobject;
    public GameObject AvatarHeadGameobject;
    public GameObject AvatarBodyGameobject;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            // Player is local
            LocalXRRigGameobject.SetActive(true);

            // Disable Body and Head
            SetLayerRecursively(AvatarHeadGameobject,6);
            SetLayerRecursively(AvatarBodyGameobject, 7);

            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if (teleportationAreas.Length > 0)
            {
                Debug.Log("Found " + teleportationAreas.Length + " teleportation area. ");
                foreach (var item in teleportationAreas)
                {
                    item.teleportationProvider = LocalXRRigGameobject.GetComponent<TeleportationProvider>();
                }
            }

        }
        else
        {
            // Player is reemote
            LocalXRRigGameobject.SetActive(false);

            // Enable Body and Head
            SetLayerRecursively(AvatarHeadGameobject, 0);
            SetLayerRecursively(AvatarBodyGameobject, 0);


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the layer of Game Objects
    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }

}
