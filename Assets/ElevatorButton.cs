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

    public Sprite Bpressed;

    public Sprite Bunpressed;

    public SpriteRenderer button;

    public Collider trigger;

    public float distance;

    public Animator ElvDoor0;
    public Animator ElvDoor1;
    public Animator ElvDoor2;

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
            this.button.sprite = Bunpressed;
            this.audioDevice.PlayOneShot(this.aud_Release, 1);
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
                this.ElvDoor0.SetTrigger("Open");

            }
        }
    }
    private void CallElevator()
    {
        if (this.currentMode == ElevatorButton.Mode.Up)
        {
        }
        else if (this.currentMode == ElevatorButton.Mode.Down)
        {
        }
    }

    private void ButtonPress()
    {

       this.audioDevice.PlayOneShot(this.aud_Press, 1);
       this.button.material = pressed;
       this.button.sprite = Bpressed;

        this.stillsPressed = true;
    }
}
