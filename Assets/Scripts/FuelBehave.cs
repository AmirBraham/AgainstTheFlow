using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class FuelBehave : MonoBehaviour {
	public Rigidbody2D FuelRigidBody;
	public Transform FuelTransform;
	public float yscale;
	// Use this for initialization
	void Start () {
		FuelRigidBody = GetComponent<Rigidbody2D> ();
		FuelTransform = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		FuelRigidBody.velocity =new Vector2(FuelRigidBody.velocity.x, -GameManager.gameSpeed) ;
		FuelTransform.Rotate (0, 0, 100 * Time.deltaTime);
		if (gameObject.GetComponent<Renderer> ().isVisible)
		{
		}
		else 
		{
			//Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D trig){
        try {
            if (trig.gameObject.tag == "Player") {
                Destroy(gameObject);
				GameManager.fuel += 20;
            }
            if (trig.gameObject.tag == "Destroyer") {
                Destroy(gameObject);
            }
        }
        catch { }
	}
	void OnTriggerStay2D(Collider2D stay){
		if (stay.gameObject.tag == "Obstacle")
        {
//			Debug.Log ("Stood");
			gameObject.transform.Translate (new Vector3(0,2,0) , Space.World); 
		}

	}
}
