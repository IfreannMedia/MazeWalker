using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private int DNALength = 2;
    //public float timeAlive;
    //public float timeWalking;
    public float distanceTravelled;
    public DNA dna;
    public GameObject eyes;
    private bool alive = true;
    private bool touchingWall = false;
    private Vector3 startPos;

    //public GameObject ethanPrefab;
    //GameObject ethan;

    //private void OnDestroy()
    //{
    //    Destroy(ethan);
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            touchingWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            touchingWall = false;
        }
    }

    public void Init()
    {
        /*
         init DNA
        0 forward
        1 left
        2 right
         */
        startPos = transform.position;
        dna = new DNA(DNALength, 3);
        //timeAlive = 0;
        //alive = true;

        //ethan = Instantiate(ethanPrefab, transform.position, transform.rotation);
        //ethan.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = transform;
    }

    private void Update()
    {
        //if (!alive) return;

        //Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 10, Color.red, .2f);
        //seeGround = false;
        //RaycastHit hit;
        //if(Physics.Raycast(eyes.transform.position, eyes.transform.forward * 10, out hit))
        //{
        //    if(hit.collider.gameObject.tag == "platform")
        //    {
        //        seeGround = true;
        //    }
        //}
        //timeAlive = PopulationManager.elapsed;

        float h = 0;
        float v = 0;
        if (!touchingWall)
        {
            if (dna.GetGene(0) == 0) { v = 1; }
            else if (dna.GetGene(0) == 1) h = -90;
            else if (dna.GetGene(0) == 2) h = 90;
        } else
        {
            if (dna.GetGene(1) == 0) { v = 1; }
            else if (dna.GetGene(1) == 1) h = -90;
            else if (dna.GetGene(1) == 2) h = 90;
        }
        transform.Translate(0, 0, v * 0.1f);
        transform.Rotate(0, h, 0);
        distanceTravelled = Vector3.Distance(startPos, transform.position);
    }
}

