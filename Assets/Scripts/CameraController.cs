using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public PlayerController PC;

    public void Rotation(float rspeed)
    {
        PC.SetMovement(transform.forward);
        transform.RotateAround(player.transform.position, Vector3.up, rspeed * Time.deltaTime * 150);
    }

    public void Lock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Unlock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Changeoffset(float x, float y, float z)
    {
        offset = new Vector3(x, y, z);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z - 10);
        offset = transform.position - player.transform.position;
        transform.rotation = Quaternion.Euler(45, 0, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey("escape"))
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Lock();
            }
            else
            {
                Unlock();
            }
        }
        if (PC.ControlState.Equals("ThirdPerson"))
        {
            //float Angle = transform.rotation.y;
            //float DZ = -Mathf.Cos(Angle);
            //float DX = Mathf.Sin(Angle);
            //print(DX);
            //print(DZ);
            //offset = new Vector3(10 * DX, 10, 10 * DZ);
            //transform.position = player.transform.position + offset;
            //PC.SetMovement(transform.forward);
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }

    public void Flip(float z)
    {

        Changeoffset(offset.x, offset.y, -offset.z);
        transform.rotation = Quaternion.Euler(45, 180, 0);
    }
}