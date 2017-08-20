using UnityEngine;
using System.Collections;


public class SubMarineSelector : MonoBehaviour
{

    public GameObject[] Submarines;

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < SceneManagerP.SubSum; i++)
        {
            if (PlayerPrefs.GetFloat("SelectedSub") == i)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Submarines[i].GetComponent<SpriteRenderer>().sprite as Sprite;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
