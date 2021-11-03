using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverHandle : ThrowableObject
{

    public Transform leverHandlePoint;
    public Rigidbody lever;

    private Rigidbody body;
    private FixedJoint joint;

    private bool isLeverGrabbed;

    void Start()
    {
        isLeverGrabbed = false;
        body = GetComponent<Rigidbody>();
        transform.position = leverHandlePoint.position;
    }

    public override void OnHoverStart()
    {
        //base.OnHoverStart();
    }

    public override void OnHoverEnd()
    {
       // base.OnHoverEnd();
    }


    public override void OnGrabStart(Grabber hand)
    {
        base.OnGrabStart(hand);

        joint = gameObject.AddComponent<FixedJoint>();

        joint.connectedBody = lever;

        isLeverGrabbed = true;
    }

    public override void OnGrabEnd()
    {
        base.OnGrabEnd();

        joint.connectedBody = null;
        Destroy(joint);

        isLeverGrabbed = false;
    }

    private void Update()
    {
        if (!isLeverGrabbed)
        {
            transform.position = leverHandlePoint.position;
        }
    }
}
