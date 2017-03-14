using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    public LegGenes Genes;

    DistanceJoint2D distanceJoint;

    float initialDistance;

    void Start()
    {
        distanceJoint = GetComponent<DistanceJoint2D>();
        initialDistance = distanceJoint.distance;
    }

    void Update()
    {
        distanceJoint.distance = Genes.Evaluate() + initialDistance;
    }
}
