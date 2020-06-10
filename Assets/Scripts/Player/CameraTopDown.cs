using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTopDown : MonoBehaviour
{
    public GameObject player;
    public int x;
    public int y;
    public int z;
    //private float m_CameraOffset;
    Camera cam;
    
    private void Start()
    {
        cam = FindObjectOfType<Camera>();     
    }

    private void Update()
    {
        //Vector3 m_CameraPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + m_CameraOffset);
        //transform.position = m_CameraPos;
        FollowingPlayer();   
    }
    public void FollowingPlayer()
    {
        transform.position = new Vector3(player.transform.position.x + (x), player.transform.position.y + y, player.transform.position.z + z);
    }
}
