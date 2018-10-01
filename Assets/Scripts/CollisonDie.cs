using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDie : MonoBehaviour {

	private float health = 1.0f;
	private float breakBy = 0.4f;

	public void OnTriggerExit(Collider other)
    {
		if(other.gameObject.tag == "Player")
        {
			this.health -= this.breakBy;
			Debug.Log("Health is now " + this.health);

			if(health <= 0) {
				Debug.Log("Breaking this object");
				Destroy(this.gameObject);
			}
		}
	}
}
