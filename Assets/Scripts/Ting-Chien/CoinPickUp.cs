using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp {

	public override void OnPickUp()
    {
        base.OnPickUp();
        Destroy(gameObject);
    }
}
