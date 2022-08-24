using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;
    public float velocity;
	public float range;
	[SerializeField] Rigidbody2D rb;
	Vector2 prePos;
	float traveled;

	void OnEnable()
	{
		traveled -= traveled;
		prePos = rb.position;
	}

	void LateUpdate()
	{
		//Get the distance between current position and previous
		traveled += Vector2.Distance(prePos, rb.position);
		//todo: use pooling
		//Destroy the game object when reached range
		if(traveled >= range) Destroy(gameObject);
		//Move the attack in the red arrow
		rb.velocity = transform.right * velocity;
		//Update the precvious position
		prePos = rb.position;
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		other.gameObject.GetComponent<Health>().TakeDamage(damage);
		//todo: use pooling
		Destroy(gameObject);
	}
}