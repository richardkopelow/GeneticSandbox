using System.Collections.Generic;
using UnityEngine;

public struct BodyGenome
{
    public LegGenes LeftGenes;
    public LegGenes RightGenes;

    public void Mutate()
    {
        LeftGenes.Mutate();
        RightGenes.Mutate();
    }
}

public struct LegGenes
{
    public float Amplitude;
    public float YOffset;
    public float TimeScale;
    public float TimeOffset;

    public LegGenes(float a, float y, float tS, float tO)
    {
        Amplitude = a;
        YOffset = y;
        TimeScale = tS;
        TimeOffset = tO;
    }

    public void Mutate()
    {
        int rand = Random.Range(0, 4);
        float shift = Random.Range(-0.3f,0.3f);
        switch (rand)
        {
            case 0:
                Amplitude += shift;
                break;
            case 1:
                YOffset += shift;
                break;
            case 2:
                TimeScale += shift;
                break;
            case 3:
                TimeOffset += shift;
                break;
            default:
                break;
        }
    }

    public float Evaluate()
    {
        return Amplitude * Mathf.Sin(TimeScale * (Time.time - Simulation.TimeOffset) + TimeOffset) + YOffset;
    }
}
