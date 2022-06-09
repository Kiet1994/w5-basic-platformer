using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance; //kho?ng cách phía tr??c
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Follow player
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed); 
    }
}

