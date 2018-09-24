using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangePickUp : PickUp
{
    public float speedDiff = -1.0f;
    public float speed = 8.0f;
    public bool changeByDiff = true;

    public override void OnPickUp()
    {
        base.OnPickUp();
        Destroy(gameObject);
    }

    public float GetNewSpeed(float speed)
    {
        float NewSpeed = speed + speedDiff;
        if(changeByDiff && (speed + speedDiff)<= 0)
        {
            NewSpeed = 1;
        }
        return (changeByDiff) ? NewSpeed : this.speed;
    }
}
