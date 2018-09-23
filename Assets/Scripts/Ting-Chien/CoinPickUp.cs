using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : PickUp {

    public int score = 1;

	public override void OnPickUp()
    {
        base.OnPickUp();
        Destroy(gameObject);
    }
}
