using UnityEngine;
using System.Collections;

public class Broundries : MonoBehaviour {

    void Update ()
    {
		Debug.Log(GameManager.fuel);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {

        //GameManager.health = 0f;
    }


}
