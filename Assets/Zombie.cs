using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] public GameObject zombie;
    [SerializeField] public GameObject player;
    [SerializeField] public float detectableRange;
    [SerializeField] public float speed;
    private bool shouldWalk;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Zombies!!!");
        shouldWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(zombie.transform.position, player.transform.position) <= detectableRange)
        {
            shouldWalk = true;
        }
        else
        {
            shouldWalk = false;
        }
        Debug.Log("Distance from zombie to player is " + Vector3.Distance(zombie.transform.position, player.transform.position));

        if(shouldWalk)
        {
            ChangeToWalk();
        }
        else
        {
            ChangeToIdle();
        }
    }

    private void ChangeToIdle()
    {
        zombie.GetComponent<Animation>().Play("idle");
    }

    public void ChangeToWalk()
    {
        zombie.GetComponent<Animation>().Play("walk");
        float step = speed * Time.deltaTime;
        zombie.transform.position = Vector3.MoveTowards(zombie.transform.position, player.transform.position, step);

        Vector3 newDir = Vector3.RotateTowards(transform.forward, player.transform.position, step, 0.0f);
        //Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);

    }
}
