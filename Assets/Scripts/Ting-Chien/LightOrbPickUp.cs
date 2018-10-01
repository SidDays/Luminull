using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOrbPickUp : PickUp {

    public float brightness;

	public override void OnPickUp()
    {
        base.OnPickUp();
        Destroy(gameObject);
    }
}
