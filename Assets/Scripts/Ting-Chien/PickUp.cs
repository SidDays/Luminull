using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public Vector3 rotate = new Vector3(0, 60, 0);
    public float floatingSpeed = 2.0f;
    public float floatingHeight = 0.3f;

    private float yOriginPos;
    private float count;

	// Use this for initialization
	void Start () {
        yOriginPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotate * Time.deltaTime);

        Vector3 movement = transform.position;
        movement.y = EvaluatefloatingY();
        transform.position = movement;
	}

    private float EvaluatefloatingY()
    {
        count = count + floatingSpeed * Time.deltaTime;
        if (count > 2 * Mathf.PI) count %= Mathf.PI;

        float offset = floatingHeight * Mathf.Sin(count);

        return yOriginPos + offset;
    }

    public virtual void OnPickUp()
    {
        gameObject.SetActive(false);
    }
}
