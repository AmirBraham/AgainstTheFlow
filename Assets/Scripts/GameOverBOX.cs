using UnityEngine;
using System.Collections;

public class GameOverBOX : MonoBehaviour
{
    public SpriteRenderer boxRenderer;
    public GameObject Box;

    
    // Use this for initialization
    void Start()
    {
        boxRenderer = Box.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {



    }
}
