using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CinemachineScript : NetworkBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public bool hostset = false;

    // Start is called before the first frame update
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void lookAtNew( GameObject player, bool hostStatues ) {

        if (IsOwner)
        {
            virtualCamera.Priority = 1;
            //hostset = true;
            //virtualCamera.LookAt = player.transform;
            //virtualCamera.Follow = player.transform;
        }
        else
        {
            virtualCamera.Priority = 0;
        }

        

    }
}
