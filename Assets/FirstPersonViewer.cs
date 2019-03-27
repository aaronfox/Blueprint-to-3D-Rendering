using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonViewer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("IN FPV");
    }
    [SerializeField] public float speed = 10.0f;
    float horizontalMouseSpeed = 2.0f;
    float verticalMouseSpeed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        float leftRight = Input.GetAxis("Horizontal") * speed;
        float forwardBack = Input.GetAxis("Vertical") * speed;

        leftRight *= Time.deltaTime;
        forwardBack *= Time.deltaTime;

        transform.Translate(leftRight, 0, 0);
        transform.Translate(0, 0, forwardBack);

        // Get the mouse delta. This is not in the range -1...1
        //float h = horizontalMouseSpeed * Input.GetAxis("Mouse X");
        //float v = verticalMouseSpeed * Input.GetAxis("Mouse Y");

        //transform.Rotate(v, h, 0);

    }
}
