using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationDirection { None = 0, Positive = 1, Negative = -1 };

public class ArticulationJointController : MonoBehaviour
{
    public RotationDirection rotationState = RotationDirection.None;
    public float speed = 300.0f;

    private ArticulationBody articulation;


    // LIFE CYCLE

    void Start()
    {
        articulation = GetComponent<ArticulationBody>();
    }

    void FixedUpdate() 
    {
        /*
        if (rotationState != RotationDirection.None) {
            float rotationChange = (float)rotationState * speed * Time.fixedDeltaTime;
            float rotationGoal = CurrentPrimaryAxisRotation() + rotationChange;
            RotateTo(rotationGoal);
        }
        */

        float torque = 100000.0f;
        if (rotationState == RotationDirection.Positive)
        {
            // apply force in one direction
            Debug.Log("adding positive torque!");
            articulation.AddRelativeTorque(new Vector3(torque, 0.0f, 0.0f));
        }
        else if (rotationState == RotationDirection.Negative)
        {
            // apply force in other direction
            articulation.AddRelativeTorque(new Vector3(-torque, 0.0f, 0.0f));
        }

        Debug.Log(CurrentPrimaryAxisRotation());
    }

    
    // MOVEMENT HELPERS

    float CurrentPrimaryAxisRotation()
    {
        float currentRotationRads = articulation.jointPosition[0];
        float currentRotation = Mathf.Rad2Deg * currentRotationRads;
        return currentRotation;
    }
    /*
    void RotateTo(float primaryAxisRotation)
    {
        var drive = articulation.xDrive;
        drive.target = primaryAxisRotation;
        articulation.xDrive = drive;
    }
    */


}
