using UnityEngine;
using System.Collections;

public class ObstacleBehave : MonoBehaviour {
	public Rigidbody2D WallRigidBody;
//	public  Transform cameraPosition;
	// Use this for initialization
	void Start () {
		WallRigidBody = GetComponent<Rigidbody2D> ();
		GameManager.gameSpeed=5f;

	}

	// Update is called once per frame
	void Update () {
		WallRigidBody.velocity =new Vector2(WallRigidBody.velocity.x, -GameManager.gameSpeed) ;
//		if(cameraPosition.transform.position.y > gameObject.transform.position.y){
			/*if (gameObject.GetComponent<Renderer> ().isVisible)
			{
			}
			else 
			{
				Destroy (gameObject);
			}
		*/}
	//}
	void OnTriggerEnter2D(Collider2D trig){
        try {

            if (trig.gameObject.tag == "Destroyer") {
                Destroy(gameObject);
            }
        }
        catch { }
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        try {
            if (col.gameObject.tag == "Player")
            {
				GameManager.fuel = 0f;

            }
        }

        catch { }
    }
}

