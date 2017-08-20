using UnityEngine;
using System.Collections;

public class Submarine : MonoBehaviour
{
    // Use this for initialization
    static public bool shaker = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShakeItOff();
    }


    void ShakeItOff()
    {
        //transform.position = new Vector2 (transform.position.x + Random.Range(0.1f, 1f), transform.position.y + Random.Range(0.1f, 1f));

    }
    void OnBecameInvisible()
    {
        enabled = false;
        Submarine.shaker = false;

    }
    void OnBecameVisible()
    {
        enabled = true;
    }
}
