using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private int DNALength = 2;
    public DNA dna;
    public GameObject eyes;
    private bool seesWall = true;
    private Vector3 startPos;
    public float distanceTravelled = 0f;
    public float distanceFromGoal;
    private bool alive = true;
    public GameObject goal;



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "dead")
        {
            distanceTravelled = 0;
            distanceFromGoal = 10000f;
            alive = false;
        }
    }

    public void Init()
    {
        /*
         init DNA
        0 forward
        1 Angle turn
         */
        goal = GameObject.FindGameObjectsWithTag("Finish")[0];
        startPos = transform.position;
        distanceFromGoal = Vector3.Distance(transform.position, goal.transform.position);
        dna = new DNA(DNALength, 360);
    }

    private void Update()
    {
        if (!alive) return;

        Debug.DrawRay(eyes.transform.position, eyes.transform.forward * .5f, Color.red, .2f);
        seesWall = false;
        RaycastHit hit;
        if(Physics.SphereCast(eyes.transform.position, .1f, eyes.transform.forward, out hit, .5f))
        {
            if(hit.collider.gameObject.tag == "wall")
            {
                seesWall = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        float h = 0;
        float v = dna.GetGene(0);
        if (seesWall)
        {
            h = dna.GetGene(1);
        }
        transform.Translate(0, 0, v * 0.001f);
        transform.Rotate(0, h, 0);
        distanceTravelled = Vector3.Distance(startPos, transform.position);
        distanceFromGoal = Vector3.Distance(transform.position, goal.transform.position);
    }
}

