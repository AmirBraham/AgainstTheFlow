using UnityEngine;
using System.Collections;

public class ObstacleEndBehave : MonoBehaviour {
	public Rigidbody2D ObstacleEndRigidBody;

	// Use this for initialization
	void Start () {
		ObstacleEndRigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		ObstacleEndRigidBody.velocity =new Vector2(ObstacleEndRigidBody.velocity.x, -GameManager.gameSpeed) ;
	}
	void OnTriggerEnter2D(Collider2D trig){
		if (trig.gameObject.tag=="yPosVerifier"){
			////////Veryfiying if we can create the Obstacle
			Spawner.canCreate=true;
		}
		if (trig.gameObject.tag=="Destroyer"){
			Destroy(gameObject);
		}
	}
}
