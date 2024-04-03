//Author: Kim Bolender
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //CAREFUL: START POINT MUST ME EXACTLY ON PLATFORM'S POSITION

    [SerializeField]
    private GameObject pathStart; //Start point

    [SerializeField]
    private GameObject pathEnd; //End point

    [SerializeField]
    private float speed; //Speed at which the platform moves

    //start and end positions
    private Vector3 startPosition;
    private Vector3 endPosition;

    private Rigidbody myRigidbody;

    void Start()
    {
        //get Rigidbody2D
        myRigidbody = GetComponent<Rigidbody>();
        //get positions
        startPosition = pathStart.transform.position;
        endPosition = pathEnd.transform.position;
    }

    void Update()
    {
        if (myRigidbody.position == endPosition) //if platform is at end point
        {
            StartCoroutine(MovePlatform(gameObject, startPosition, speed)); //move to start point
        }
        else if (myRigidbody.position == startPosition) //if platform is at start point
        {
            StartCoroutine(MovePlatform(gameObject, endPosition, speed)); //move to end point
        }
    }

    /**
     * moves object from current position to end position at set speed
     * obj: moved object
     * pathDestination: position obj is getting moved to
     * speed: speed at which obj moves
     */
    IEnumerator MovePlatform(GameObject obj, Vector3 pathDestination, float speed)
    {
        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (myRigidbody.position != pathDestination)
        {
            obj.transform.position = Vector3.Lerp(
                startPosition,
                pathDestination,
                (time / Vector3.Distance(startPosition, pathDestination)) * speed
            );
            time += Time.deltaTime;
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Set player as child to give its movement
        if (other.tag == "Player")
            other.transform.SetParent(gameObject.transform, true);
    }

    void OnTriggerExit(Collider other)
    {
        //Free player
        if (other.tag == "Player")
            other.transform.parent = null;
    }
}
