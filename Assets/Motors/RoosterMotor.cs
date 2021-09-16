using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RoosterBoss))]
public class RoosterMotor : MonoBehaviour
{
    private RoosterBoss roosterBoss;
    private Rigidbody2D rigidBody;
    public float speed;

    private void Start()
    {
        roosterBoss = GetComponent<RoosterBoss>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    public void Propel()
    {
        if (running)
        {
            Vector2 force = roosterBoss.Direction == Direction.RIGHT ? transform.right * speed : -transform.right * speed;
            rigidBody.AddForce(force);
        }
    }

    private bool running = false;
    
    public void TurnOn()
    {
        running = true;
    }

    public void TurnOff()
    {
        running = false;
    }
}
