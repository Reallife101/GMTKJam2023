using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
	public float acceleration;
	public float steering;

	[SerializeField] GameObject smoke;
	[SerializeField] ParticleSystem ps;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		float h = -Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		float steer = 0f;
		float accel = 0f;

		if (Input.GetKey(KeyCode.LeftShift))
        {
			steer = steering * 2;
			accel = acceleration/2;
			if (h!=0)
            {
				smoke.SetActive(true);
			}
            else
            {
				smoke.SetActive(false);
			}

		}
		else
        {
			steer = steering;
			accel = acceleration;
			smoke.SetActive(false);
		}

		Vector2 speed = transform.up * (v * accel);
		rb.AddForce(speed);

		float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
		if (direction >= 0.0f)
		{
			rb.rotation += h * steer * (rb.velocity.magnitude / 5.0f);
			//rb.AddTorque((h * steering) * (rb.velocity.magnitude / 10.0f));
		}
		else
		{
			rb.rotation -= h * steer * (rb.velocity.magnitude / 5.0f);
			//rb.AddTorque((-h * steering) * (rb.velocity.magnitude / 10.0f));
		}

		Vector2 forward = new Vector2(0.0f, 0.5f);
		float steeringRightAngle;
		if (rb.angularVelocity > 0)
		{
			steeringRightAngle = -90;
		}
		else
		{
			steeringRightAngle = 90;
		}

		Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
		Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

		float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));

		Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);


		Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(relativeForce), Color.red);

		rb.AddForce(rb.GetRelativeVector(relativeForce));
	}
}
