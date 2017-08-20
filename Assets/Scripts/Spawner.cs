using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public static GameObject spawnedObstacle;
    static public bool canCreate = true;
    public float xRight;
    public float yRight;
    public float xLeft;
    public float yLeft;
    public bool Boolean;
    public static bool SpawnedShrink;
    public GameObject Algae;
    public GameObject ob1m1;
    public GameObject ob2m1;
    public GameObject ob3m1;
    public GameObject ob1m2;
    public GameObject ob2m2;
    public GameObject ob3m2;
    public GameObject ob1m3;
    public GameObject ob2m3;
    public GameObject ob3m3;
    public GameObject Creat1;
    public GameObject Creat2;
    public GameObject Creat3;
    public GameObject Pill;
    public GameObject ShrinkBoost;

    public List<GameObject> Creatures;
    public List<GameObject> World1;
    public List<GameObject> World2;
    public List<GameObject> World3;

    void Start()
    {
        InvokeRepeating("spawnPill", Random.Range(5, 8), Random.Range(4, 6));
        InvokeRepeating("spawnShrinkBoost", Random.Range(5, 8), Random.Range(4, 6));

        InvokeRepeating("spawnAlgae", Random.Range(10, 20), 10);
        InvokeRepeating("spawnObstacle", 1f, 1f);
        InvokeRepeating("spawnCreatures", Random.Range(6, 9), 4f);
        GameManager.difficulty = 0.75f;
        canCreate = true;
        ///////////////////Declaring the Lists
        World1 = new List<GameObject>();
        World2 = new List<GameObject>();
        World3 = new List<GameObject>();
        Creatures = new List<GameObject>();
        ////////////////////Adding Obstacles to the Obstacles List
        World1.Add(ob1m1);
        World1.Add(ob2m1);
        World1.Add(ob3m1);
        World2.Add(ob1m2);
        World2.Add(ob2m2);
        World2.Add(ob3m2);
        World3.Add(ob1m3);
        World3.Add(ob2m3);
        World3.Add(ob3m3);
        ////////////////////Adding Creatures to the Creatures List
        Creatures.Add(Creat1);
        Creatures.Add(Creat2);
        Creatures.Add(Creat3);

    }


    void Update()
    {
        /// <summary>
        /// Empty
        /// </summary>
    }

    /// <summary>
    /// Spawns the pill
    /// </summary>
    void spawnPill()
    {
        Instantiate(Pill, new Vector2(Random.Range(xLeft + 0.5f, xRight - 0.5f), 10), Quaternion.identity);
    }

    void spawnShrinkBoost()
    {
        SpawnedShrink = true;
        Instantiate(ShrinkBoost, new Vector2(Random.Range(xLeft + 0.5f, xRight - 0.5f), 10), Quaternion.identity);
    }
    /// <summary>
    /// Spawns the obstacles
    /// </summary>
    void spawnObstacle()
    {
        if (canCreate)
        {
            if (GameManager.World == 1)
            {
                spawnedObstacle = Instantiate(World1[Random.Range(0, 3)], new Vector2(-3.292426f, yRight), Quaternion.identity) as GameObject;
            }
            else if (GameManager.World == 2)
            {
                spawnedObstacle = Instantiate(World2[Random.Range(0, 3)], new Vector2(0, yRight), Quaternion.identity) as GameObject;
            }
            else if (GameManager.World == 3)
            {
                spawnedObstacle = Instantiate(World3[Random.Range(0, 3)], new Vector2(0, yRight), Quaternion.identity) as GameObject;
            }

            canCreate = false;
        }
    }
    /// <summary>
    /// Spawns the creatures
    /// </summary>
    void spawnCreatures()
    {
        if (GameManager.canCreatures)
        {
            Instantiate(Creatures[Random.Range(0, 3)], new Vector2(Random.Range(xLeft + 0.5f, xRight - 0.5f), 10), Quaternion.identity);
        }
    }
    /// <summary>
    /// Spawns the algae
    /// </summary>
    void spawnAlgae()
    {
        if (GameManager.canCreateAlgae)
        {
            Instantiate(Algae, new Vector2(Random.Range(xLeft + 0.5f, xRight - 0.5f), 10), Quaternion.identity);
        }
    }
}
