using UnityEngine;

using System.Collections;

public class SceneFadeInOut : MonoBehaviour

{

    public float fadeSpeed = 0.3f; // Speed that the screen fades to and from black.

    private bool sceneStarting = true; // Whether or not the scene is still fading in.

    public GUITexture guiTexturee;
    void Start()
    {
        guiTexturee = GetComponent<GUITexture>();
    }
    void Awake()

    {

        // Set the texture so that it is the the size of the screen and covers it.

        guiTexturee.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);

    }

    void Update()

    {

        // If the scene is starting…

        if (sceneStarting)

            // … call the StartScene function.

            StartScene();

    }

    public void FadeToClear()

    {

        // Lerp the colour of the texture between itself and transparent.

        guiTexturee.color = Color.Lerp(guiTexturee.color, Color.clear, fadeSpeed * Time.deltaTime);

    }

    public void FadeToBlack()

    {

        // Lerp the colour of the texture between itself and black.

        guiTexturee.color = Color.Lerp(guiTexturee.color, Color.black, fadeSpeed * Time.deltaTime);

    }

    void StartScene()

    {

        // Fade the texture to clear.

        FadeToClear();

        // If the texture is almost clear…

        if (guiTexturee.color.a <= 0.05f)

        {

            // … set the colour to clear and disable the guiTexturee.

            guiTexturee.color = Color.clear;

            guiTexturee.enabled = false;

            // The scene is no longer starting.

            sceneStarting = false;

        }

    }

    public void EndScene(string name)

    {

        // Make sure the texture is enabled.

        guiTexturee.enabled = true;

        // Start fading towards black.

        FadeToBlack();

        // If the screen is almost black…

        //if (guiTexturee.color.a >= 0.95f) Application.LoadLevel(name);

        // … reload the level.



    }

}

