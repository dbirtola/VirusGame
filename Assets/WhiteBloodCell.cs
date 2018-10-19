using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WhiteBloodCell : MonoBehaviour {

    public GameObject target;

    [Header("Movement")]
    public float speed = 1500f;

    NavMeshPath currentPath;
    private int currentPointInPath = -1;

    //Defines how close the game object needs to be to a corner of the path before it sets the next corner as its target.
    public float cornerThreshold = 1;

    [Header("Combat")]
    public int aggroRange = 50;
    public float aggroSpeedBoost = 1.5f;

    void Start () {


        CalculateNewPath();
      
	}


    void CalculateNewPath()
    {
        NavMeshPath newPath = new NavMeshPath();



        //Create the position the GameObject would be on if it were grounded for use in calculating the NavMesh path
        Vector3 groundedPosition = GetGroundedPosition(transform.position);

        Vector3 targetGroundedPosition = GetGroundedPosition(target.transform.position);

        bool pathExists = NavMesh.CalculatePath(groundedPosition, targetGroundedPosition, GetComponent<NavMeshAgent>().areaMask, newPath);

        if (!pathExists)
        {
            Debug.LogWarning("No path found for: " + gameObject.name);
        }else 
        {
            //Update member variables to use the new path calculated
            currentPointInPath = 1;
            currentPath = newPath;
        }
    }

    //Returns the Z coordinate of the ground below the game object
    Vector3 GetGroundedPosition(Vector3 position)
    {
        return new Vector3(position.x, 0, position.z);
    }


    void UpdatePosition()
    {
        CheckForNearbyPlayer();

        if (currentPath != null)
        {
            //Check to see if were close enough to a corner of the path to switch our target to the next corner
            if ((GetGroundedPosition(transform.position) - currentPath.corners[currentPointInPath]).magnitude < cornerThreshold)
            {
                currentPointInPath++;

                //If there are no corners left to go to, nullify the currentPath so we stop moving.
                if (currentPointInPath > currentPath.corners.Length - 1)
                {

                    currentPath = null;
                    currentPointInPath = -1;
                    return;
                }
            }


            var direction = currentPath.corners[currentPointInPath] - transform.position;
            //Ignore any Y calculation in the direction since we want to control our height through other methods
            direction.y = 0;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }

    }

    void CheckForNearbyPlayer()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, aggroRange);

        //See if the player is in range of us
        foreach (Collider col in objects){

            if (col.gameObject.GetComponent<PlayerTemp>())
            {

                //Check if we canactually see the player
                RaycastHit hit;
                Vector3 direction = col.gameObject.transform.position - transform.position;
                Physics.Raycast(transform.position, direction, out hit, aggroRange);

                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.GetComponent<PlayerTemp>())
                {
                    target = hitObject;
                    speed *= aggroSpeedBoost;
                    CalculateNewPath();
                }
            }

        } //end foreach
    }

    void Update () {
        UpdatePosition();
	}


    void OnCollisionEnter(Collision coll)
    {


    }
}
