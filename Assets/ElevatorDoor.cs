using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public float openTime;

    public bool bDoorOpen;

    public Collider Collider;

    public Animator Door;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.openTime > 0f) // If the open time is greater then 0, decrease lockTime Decrease open time
        {
            this.openTime -= 1f * Time.deltaTime;
        }
        if (this.openTime < 0f && bDoorOpen) // If the open time is greater then 0, decrease lockTime Decrease open time
        {
            this.CloseDoor();
        }
    }

    public void OpenDoor()
    {
        this.Door.SetTrigger("Open");
        this.Collider.enabled = false;
        this.bDoorOpen = true;
        this.openTime = 3f;
    }

    public void CloseDoor()
    {
        this.Door.SetTrigger("Close");
        this.Collider.enabled = true;
        this.bDoorOpen = false;
    }
}
