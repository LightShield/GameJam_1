using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference : https://answers.unity.com/questions/1077171/how-to-make-camera-follow-player-position-and-rota.html
public class CameraFollow: MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

  
    //late update - to update AFTER movment of player
    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {

        // compute position
        transform.position = target.TransformPoint(offsetPosition);
        
        // compute rotation
        transform.LookAt(target);
    }
}
