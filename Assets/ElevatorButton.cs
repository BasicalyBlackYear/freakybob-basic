using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorButton : MonoBehaviour
{
    public AudioSource audioDevice;

    public AudioClip aud_Press;

    public AudioClip aud_Release;

    public Material pressed;

    public Material unpressed;

    public MeshRenderer button;

    public Collider trigger;

    public float distance;

    public enum Mode
    {
        // Token: 0x04000717 RID: 1815
        Up,
        // Token: 0x04000718 RID: 1816
        Down
    }

    public ElevatorButton.Mode currentMode;

    public bool stillsPressed;

    public Transform playerTransform;

    public PlatformScript Elevator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.stillsPressed)
        {
            this.button.material = unpressed;
            this.audioDevice.PlayOneShot(this.aud_Release);
            this.stillsPressed = false;
        }
        if ((Input.GetMouseButtonDown(0) || Singleton<InputManager>.Instance.GetActionKey(InputAction.Interact)) && Time.timeScale != 0f & Vector3.Distance(this.playerTransform.position, base.transform.position) < this.distance) //If the door is left clicked and the game isn't paused

        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit) && (raycastHit.collider == this.trigger))
            {
                this.ButtonPress();
                this.CallElevator();
            }
        }
    }
    private void CallElevator()
    {
        if (this.currentMode == ElevatorButton.Mode.Up)
        {
            this.Elevator.IsCallingTheElevatorUp = true;
        }
        else if (this.currentMode == ElevatorButton.Mode.Down)
        {
            this.Elevator.IsCallingTheElevatorUp = false;
        }
    }

    private void ButtonPress()
    {
       if (this.stillsPressed)
        {
            this.audioDevice.PlayOneShot(this.aud_Release);
        }
       this.button.material = pressed;

       this.stillsPressed = true;
    }
}
