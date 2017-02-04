using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EggBehave : MonoBehaviour {
	//Declarations
	public Rigidbody2D eggRigidBody;
	public Transform eggTransform;
	public PolygonCollider2D eggCollider;
	[SerializeField]
	public float rotSpeed;
	[SerializeField]
	public float smoothingRatio;
	[SerializeField]
	public float smoothingTime;
	[SerializeField]
	public float currentVelocity;
	[SerializeField]
	public float eggVelocity;
    public Image HealthBar;
	// Start
	void Start () {
		eggRigidBody = GetComponent<Rigidbody2D> ();
		eggTransform = GetComponent<Transform>();
		eggCollider = GetComponent<PolygonCollider2D> ();
		rotSpeed= 5f;
		eggRigidBody.velocity=new Vector2(0,0);
	}
	
	// Update
	void Update () {
        if(HealthBar != null)
        HealthBar.fillAmount = GameManager.fuel / 100;


        if (GameManager.fuel!=0) {

			if (Input.GetKey (KeyCode.Space)||Input.touchCount > 0) {
				eggRigidBody.velocity = new Vector2 (Mathf.SmoothDamp (eggRigidBody.velocity.x, -eggVelocity, ref smoothingRatio, smoothingTime), eggRigidBody.velocity.y);
				eggTransform.rotation = Quaternion.Euler (eggTransform.rotation.x, eggTransform.rotation.y, -eggRigidBody.velocity.x * rotSpeed * 0.75f);
			} else {
				eggRigidBody.velocity = new Vector2 (Mathf.SmoothDamp(eggRigidBody.velocity.x, eggVelocity,ref smoothingRatio,smoothingTime),eggRigidBody.velocity.y);
				eggTransform.rotation = Quaternion.Euler (eggTransform.rotation.x, eggTransform.rotation.y, -eggRigidBody.velocity.x * rotSpeed*0.75f);
			}
		} 
		else {
				Die ();
			}
	
		if (GameManager.fuel == 0)
			Die ();	
		
	}
	//Collision
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag=="Obstacle"){
			GameManager.fuel=0;
		}
		if (col.gameObject.tag=="Malus"){
			GameManager.fuel=0;
		}
		if(col.gameObject.tag=="Algae"){
			GameManager.SlowDown=true;
		}
	}
	//Trigger
	void OnTriggerEnter2D(Collider2D trig){
		if(trig.gameObject.tag=="walls"){
			GameManager.fuel = 0;
		}
		if (trig.gameObject.tag=="Pill"){
			GameManager.fuel += 50;
			GameManager.Extrafuel += 50;
		}

	}
	//Dying
	void Die(){
		eggRigidBody.constraints = RigidbodyConstraints2D.None;
		eggCollider.enabled=false;
		eggRigidBody.velocity=new Vector2(0,-5f);
	
	}
}
