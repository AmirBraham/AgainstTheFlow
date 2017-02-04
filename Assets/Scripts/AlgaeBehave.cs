using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class AlgaeBehave : MonoBehaviour {
	public Rigidbody2D MalusRigidBody;
	public Transform MalusTransform;
	public float yscale;
	// Use this for initialization
	void Start () {
		MalusRigidBody = GetComponent<Rigidbody2D> ();
		MalusTransform = GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {
		MalusRigidBody.velocity =new Vector2(MalusRigidBody.velocity.x, -GameManager.gameSpeed) ;
		if (gameObject.GetComponent<Renderer> ().isVisible)
		{
		}
		else 
		{
			//Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D trig){
		if (trig.gameObject.tag=="Player"){
			Destroy (gameObject);
			if (trig.gameObject.tag=="Destroyer"){
				Destroy (gameObject);
			}
		}

	}
	void OnTriggerStay2D(Collider2D stay){
		if (stay.gameObject.tag == "Obstacle") {
			gameObject.transform.Translate(new Vector2(0,2));

		}
	}
}
