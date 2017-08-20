using UnityEngine;
using System.Collections;

public class ShrinkIt : MonoBehaviour
{

    void Start()
    {
        if (GameManager.Player.gameObject.transform.localScale.x < 0.3f)
        {
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && GameManager.ShrinkedSubmarine == false)
        {
            col.gameObject.transform.localScale = col.gameObject.transform.localScale / (2f);
        }


    }

}




