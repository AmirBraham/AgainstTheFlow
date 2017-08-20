using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubPosText : MonoBehaviour
{
    public Text SubMarinePositionText;
    private int SubTruePos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManagerP.SelectState)
        {
            SubTruePos = SceneManagerP.MinSub + 1;
            SubMarinePositionText.text = SubTruePos.ToString() + "/" + SceneManagerP.SubSum.ToString();
        }
        else
        {

            SubTruePos = SceneManagerP.MinAcces + 1;
            SubMarinePositionText.text = SubTruePos.ToString() + "/" + SceneManagerP.AccesSum.ToString();
        }

    }
}