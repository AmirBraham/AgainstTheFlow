using UnityEngine;
using System.Collections;

public class RandomMovement2 : MonoBehaviour {

	public Rigidbody2D Rig;
	public float speed;
	void Start () {
		Rig = GetComponent<Rigidbody2D> ();
	}
	void Update () {


		if (Submarine.shaker == true && SceneManagerP.ClickedStartButton != true)
		{
			Rig.velocity = (new Vector2(Random.Range(speed, speed + 0.12f), -GameManager.gameSpeed/3));
		}
		else if (SceneManagerP.ClickedStartButton == true)
		{
			Rig.velocity = (new Vector2(5f, 0f));
		}
	}

}

