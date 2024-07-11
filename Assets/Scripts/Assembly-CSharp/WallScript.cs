using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        if (thisWall == null)
        {
            thisWall = gameObject;
        }

        if (gcAudio == null)
        {
            gcAudio = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
        }
    }

    //The code for placing the portal poster on a wall
    public void PlacePortal()
    {
        if (!portalPlaced)
        {
            if (otherWall != null)
            {
                thisWall.GetComponent<MeshCollider>().enabled = false;
                otherWall.GetComponent<MeshCollider>().enabled = false;

                thisWall.GetComponent<MeshRenderer>().material = portalWallThis;
                otherWall.GetComponent<MeshRenderer>().material = portalWallOther;

                thisWall.GetComponent<WallScript>().portalPlaced = true;
                otherWall.GetComponent<WallScript>().portalPlaced = true;

                gcAudio.PlayOneShot(audSuccess);
            }
            else
            {
                gcAudio.PlayOneShot(audFailure);
            }
        }
    }

    public AudioSource gcAudio;
    public bool portalPlaced = false;

    public GameObject thisWall;
    public GameObject otherWall;

    public Material portalWallThis;
    public Material portalWallOther;

    public AudioClip audSuccess;
    public AudioClip audFailure;
}