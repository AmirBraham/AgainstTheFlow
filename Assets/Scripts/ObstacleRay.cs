using UnityEngine;
using System.Collections;

public class ObstacleRay : MonoBehaviour
{
    public LayerMask Obstacle;
    bool ObstacleISNotOnTheSameSide;
    RaycastHit2D forwardHit;
    RaycastHit2D rightHit;
  
    void Update()
    {
        RayCastInitialization();

        //try
        //{
        //    if (forwardHit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        //    {
        //        //Debug.Log("Hit right");
        //        //if(forwardHit.collider.gameObject.transform.position.x < 0 )
        //        //{

        //        //        forwardHit.collider.gameObject.transform.position = new Vector3(forwardHit.collider.gameObject.transform.position.x - 0.01f, forwardHit.collider.gameObject.transform.position.y, forwardHit.collider.gameObject.transform.position.z);


        //        //    }
        //        //} else
        //        //{
        //        //    forwardHit.collider.gameObject.transform.position = new Vector3(forwardHit.collider.gameObject.transform.position.x + 0.01f, forwardHit.collider.gameObject.transform.position.y, forwardHit.collider.gameObject.transform.position.z);

        //        //}


        //    }
        //}
        //catch { }

        try
        {
           
                if (rightHit.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle") )
            {
                Debug.Log("Hit forward ");
                if(rightHit.collider.gameObject.transform.position.x < 0 )
                {

                     rightHit.collider.gameObject.transform.position = new Vector3(rightHit.collider.gameObject.transform.position.x - 0.01f, rightHit.collider.gameObject.transform.position.y, rightHit.collider.gameObject.transform.position.z);
                    
                } else {
                rightHit.collider.gameObject.transform.position = new Vector3(rightHit.collider.gameObject.transform.position.x + 0.01f, rightHit.collider.gameObject.transform.position.y, rightHit.collider.gameObject.transform.position.z);

            }


        }
        }
        catch {}

        
        }
    void IsTheRayCasterOnTheSameSide ()
    {

        if((gameObject.transform.position.x < 0) && (rightHit.collider.gameObject.transform.position.x < 0) )
        {
            ObstacleISNotOnTheSameSide = false;

        }
        else if (gameObject.transform.position.x > 0 && rightHit.collider.gameObject.transform.position.x > 0)
        {
            ObstacleISNotOnTheSameSide = false;
        }  else
        {
            ObstacleISNotOnTheSameSide = true;

        }



    }
   void RayCastInitialization ()
    {
        // RayCast Init

        if (gameObject.transform.parent.gameObject.transform.position.x < 0)
        {
            forwardHit = Physics2D.Raycast(transform.position, Vector2.up, 0.86f, Obstacle);
            rightHit = Physics2D.Raycast(transform.position, Vector2.right, 1.14f, Obstacle);
            //DEBUG
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + new Vector3(0, 0.86f, 0), Color.red);
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + new Vector3(1.14f, 0, 0), Color.green);
        }
        else if (gameObject.transform.parent.gameObject.transform.position.x > 0)
        {
            forwardHit = Physics2D.Raycast(transform.position, Vector2.up, 0.86f, Obstacle);
            rightHit = Physics2D.Raycast(transform.position, Vector2.left, 1.14f, Obstacle);
            //DEBUG
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + new Vector3(0, 0.86f, 0), Color.red);
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + new Vector3(-1.14f, 0, 0), Color.green);

        }

        //
    }

}

    

