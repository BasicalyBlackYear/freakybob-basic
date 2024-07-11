using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class HammerThrowScript : MonoBehaviour
{
	// Token: 0x0600092A RID: 2346 RVA: 0x00020C21 File Offset: 0x0001F021
	private void Start()
	{
		this.rb = base.GetComponent<Rigidbody>(); //Get the RigidBody
		this.rb.velocity = base.transform.forward * this.speed; //Move forward
		this.lifeSpan = 30f; //Set the lifespan
        RaycastHit raycastHit7;
        Ray ray7 = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
        if (Physics.Raycast(ray7, out raycastHit7) && raycastHit7.collider.name.Contains("Window"))
        {
            WallScript wall = raycastHit7.collider.gameObject.GetComponent<WallScript>();
            if (wall != null)
            {
                wall.PlacePortal();
                if (wall.otherWall != null)
                {

                }
            }
        }
        else if (Physics.Raycast(ray7, out raycastHit7) && raycastHit7.collider.name.Contains("Wall"))
        {
            UnityEngine.Object.Destroy(base.gameObject, 0f);
        }
    }

	// Token: 0x0600092B RID: 2347 RVA: 0x00020C5C File Offset: 0x0001F05C
	private void Update()
	{
		this.rb.velocity = base.transform.forward * this.speed; //Move forward
		this.lifeSpan -= Time.deltaTime; // Decrease the lifespan variable
		if (this.lifeSpan < 0f) //When the lifespan timer ends, destroy the BSODA
		{
			UnityEngine.Object.Destroy(base.gameObject, 0f);
		}
	}

	// Token: 0x040005AD RID: 1453
	public float speed;

	// Token: 0x040005AE RID: 1454
	private float lifeSpan;

	// Token: 0x040005AF RID: 1455
	private Rigidbody rb;                   
}
