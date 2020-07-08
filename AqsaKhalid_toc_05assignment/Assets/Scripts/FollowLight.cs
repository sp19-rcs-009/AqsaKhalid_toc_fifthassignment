using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{

    // Update is called once per frame
    public GameObject thePlayer;
    void Update()
        
    {
        transform.LookAt(thePlayer.transform);
    }
}
