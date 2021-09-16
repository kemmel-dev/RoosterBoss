using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(RoosterBoss))]
[RequireComponent(typeof(RoosterMotor))]

public class RoosterBrain : MonoBehaviour
{
    private RoosterBoss roosterBoss;
    private Transform player;
    private RoosterMotor motor;

    public RoosterState state = RoosterState.IDLE;

    private bool performingAction = false;
    private float idleTime = 2;
    private float maxChargeTime = 4;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        roosterBoss = GetComponent<RoosterBoss>();
        motor = GetComponent<RoosterMotor>();
        motor.TurnOn();
    }

    public void PonderAction()
    {
        switch (state)
        {
            case RoosterState.IDLE:
                Idle();
                return;
            case RoosterState.CHARGE_HIGH_TOP:
                ChargeHighTop();
                return;
            case RoosterState.CHARGE_HIGH_CENTER:
                ChargeHighCenter();
                return;
            case RoosterState.CHARGE_LOW_CENTER:
                ChargeLowCenter();
                return;
            case RoosterState.CHARGE_LOW_BOTTOM:
                ChargeLowBottom();
                return;
            default:
                throw new NotImplementedException();
        }
    }

    private void ChargeLowBottom()
    {
        if (!performingAction)
        {
            InitiateChargeLowBottom();
            return;
        }
        throw new NotImplementedException();
    }

    private void InitiateChargeLowBottom()
    {
        performingAction = true;
        InitiateCharge();
    }

    private void ChargeLowCenter()
    {
        if (!performingAction)
        {
            IntitiateChargeLowCenter();
            return;
        }
        throw new NotImplementedException();
    }

    private void IntitiateChargeLowCenter()
    {
        performingAction = true;
        InitiateCharge();
        throw new NotImplementedException();
    }

    private void ChargeHighCenter()
    {
        if (!performingAction)
        {
            InitiateChargeHighCenter();
            return;
        }
        throw new NotImplementedException();
    }

    private void InitiateChargeHighCenter()
    {
        performingAction = true;
        InitiateCharge();
        throw new NotImplementedException();
    }

    private void ChargeHighTop()
    {
        if (!performingAction)
        {
            InitiateChargeHighTop();
            return;
        }
        throw new NotImplementedException();
    }

    private void InitiateChargeHighTop()
    {
        performingAction = true;
        InitiateCharge();
    }

    private void InitiateCharge()
    {
        motor.TurnOn();
        StartCoroutine(ChargeRoutine(maxChargeTime));
    }

    private void Idle()
    {
        if (!performingAction)
        {
            InitiateIdle();
            return;
        }
    }

    private void InitiateIdle()
    {
        performingAction = true;
        StartCoroutine(IdleRoutine(idleTime));
        motor.TurnOff();
    }


    private IEnumerator IdleRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SwitchState(PickRandomActionState());
    }

    private IEnumerator ChargeRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SwitchState(RoosterState.IDLE);
    }

    private void SwitchState(RoosterState roosterState)
    {
        performingAction = false;
        state = roosterState;
    }

    private RoosterState PickRandomActionState()
    {
        RoosterState[] values = (RoosterState[]) Enum.GetValues(typeof(RoosterState));
        return values[Random.Range(1, values.Length)];
    }

    public void PonderMovement()
    {
        if (GetPlayerDirection() != roosterBoss.Direction)
        {
            TurnAround();
        }
        motor.Propel();
    }

    public Direction GetPlayerDirection()
    {
        if (player.position.x > transform.position.x)
        {
            return Direction.RIGHT;
        }
        return Direction.LEFT;
    }

    public void TurnAround()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        switch (roosterBoss.Direction)
        {
            case Direction.LEFT:
                roosterBoss.Direction = Direction.RIGHT;
                return;
            case Direction.RIGHT:
                roosterBoss.Direction = Direction.LEFT;
                return;
        }
    }

}
