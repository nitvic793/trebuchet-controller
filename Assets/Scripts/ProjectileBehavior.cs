using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    SwingArm armData;

    float armRotation;
    float baseRotation;
    Vector3 trebuchetDirection;
    Rigidbody projectileRigidBody;

    // Use this for initialization
    void Start()
    {
        var beam = GameObject.Find("Beam");
        armData = beam.GetComponent<SwingArm>();
        trebuchetDirection = armData.trebuchetDirection;
        armRotation = armData.armRotation - 138;
        baseRotation = armData.trebuchetRotation;
        projectileRigidBody = GetComponent<Rigidbody>();
        var actualForce = Normalize(armRotation, 120, 0);
        var totalForce = new Vector3(-1000 * actualForce, 300 * actualForce, 0);
        totalForce = Quaternion.Euler(0, baseRotation, 0) * totalForce;
        projectileRigidBody.AddForce(totalForce);
    }

    float Normalize(float value, float max, float min)
    {
        var normalized = (value - min) / (max - min);
        return normalized;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
