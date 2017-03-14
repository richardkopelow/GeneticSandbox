using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public BodyGenome Genome;
    public Transform bodyTransform;
    public Leg LeftLeg;
    public Leg RightLeg;

    public float Score
    {
        get { return bodyTransform.position.x - 10 * (bodyTransform.up.y < 0 ? 1 : 0); }
    }

    void Start()
    {
        LeftLeg.Genes = Genome.LeftGenes;
        RightLeg.Genes = Genome.RightGenes;
    }

    public void SetColor(Color color)
    {
        foreach (Transform child in GetComponent<Transform>())
        {
            child.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
