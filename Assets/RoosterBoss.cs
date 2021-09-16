using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(RoosterBrain))]
[RequireComponent(typeof(RoosterController))]
public class RoosterBoss : MonoBehaviour
{

    private RoosterBrain brain;
    private RoosterController controller;

    public Direction Direction
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        Direction = Direction.LEFT;
        brain = GetComponent<RoosterBrain>();
    }

    private void Update()
    {
        ///////
        // TODO: REMOVE DEBUG
        Debug.Log(brain.state.ToString());
        Debug.ClearDeveloperConsole();
        ///////

        brain.PonderAction();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        brain.PonderMovement();
    }

}
