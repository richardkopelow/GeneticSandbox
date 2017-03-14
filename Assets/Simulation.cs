using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulation : MonoBehaviour
{
    public static float TimeOffset = 0;
    public Transform Creature;
    public Text GenerationLabel;
    public int CreatureCount = 30;
    public float RunTime = 15;
    public Color[] Colors;
    public int GenerationCount = 0;

    Transform trans;

    List<Body> creatures;
    BodyGenome[] BestGenomes;

    IEnumerator Start()
    {
        trans = GetComponent<Transform>();

        BestGenomes = new BodyGenome[5];
        BestGenomes[0] = new BodyGenome();
        BestGenomes[0].RightGenes = new LegGenes(0.60f, 0, 4f, 0);
        BestGenomes[0].LeftGenes = new LegGenes(0.60f, 0, 4f, Mathf.PI / 2);

        creatures = new List<Body>();
        while (true)
        {
            GenerationCount++;
            GenerationLabel.text = "Generation: " + GenerationCount;
            TimeOffset = Time.time;
            for (int i = 0; i < BestGenomes.Length; i++)
            {
                Transform bodyTrans = Instantiate<Transform>(Creature);
                bodyTrans.position = trans.position;
                Body body = bodyTrans.GetComponent<Body>();
                body.Genome = BestGenomes[i];
                creatures.Add(body);
                body.SetColor(Colors[i]);
                for (int j = 1; j < CreatureCount; j++)
                {
                    bodyTrans = Instantiate<Transform>(Creature);
                    bodyTrans.position = trans.position;
                    body = bodyTrans.GetComponent<Body>();
                    body.Genome = BestGenomes[i];
                    body.Genome.Mutate();
                    creatures.Add(body);
                    body.SetColor(Color.Lerp(Colors[i], Color.white, (float)j / (float)CreatureCount / 2f));
                }
            }

            yield return new WaitForSeconds(RunTime);
            creatures.Sort(new System.Comparison<Body>((x, y) => x.Score > y.Score ? -1 : 0));
            for (int i = 0; i < BestGenomes.Length; i++)
            {
                BestGenomes[i] = creatures[i].Genome;
            }
            foreach (Body creature in creatures)
            {
                Destroy(creature.gameObject);
            }
            creatures.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
