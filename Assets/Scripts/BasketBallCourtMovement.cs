using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallCourtMovement : MonoBehaviour
{
    public Transform[] Waypoint;
    public float MovementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        MovementSpeed = 1f;
        StartCoroutine(CourtMovement());
    }
    IEnumerator MoveToward(Transform target,Transform[] Destination,float Speed)
    {
        foreach(var dest in Destination)
        {
            while(Vector3.Distance(dest.position,target.position)>.05f)
            {
                target.position = Vector3.MoveTowards(target.position, dest.position, Speed*Time.deltaTime);
                yield return new WaitForSeconds(.001f);
            }
        }
    }
    IEnumerator CourtMovement()
    {
        yield return MoveToward(this.gameObject.transform, Waypoint, MovementSpeed);
        StartCoroutine(CourtMovement());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
