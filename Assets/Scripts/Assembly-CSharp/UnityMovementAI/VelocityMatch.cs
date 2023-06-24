using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityMovementAI
{
	[RequireComponent(typeof(SteeringBasics))]
	public class VelocityMatch : MonoBehaviour
	{
		public float facingCosine = 90f;

		public float timeToTarget = 0.1f;

		public float maxAcceleration = 4f;

		private float facingCosineVal;

		private MovementAIRigidbody rb;

		private SteeringBasics steeringBasics;

		private void Awake()
		{
			facingCosineVal = Mathf.Cos(facingCosine * ((float)Math.PI / 180f));
			rb = GetComponent<MovementAIRigidbody>();
			steeringBasics = GetComponent<SteeringBasics>();
		}

		public Vector3 GetSteering(ICollection<MovementAIRigidbody> targets)
		{
			Vector3 result = Vector3.zero;
			int num = 0;
			foreach (MovementAIRigidbody target in targets)
			{
				if (steeringBasics.IsFacing(target.Position, facingCosineVal))
				{
					Vector3 vector = target.Velocity - rb.Velocity;
					vector /= timeToTarget;
					result += vector;
					num++;
				}
			}
			if (num > 0)
			{
				result /= (float)num;
				if (result.magnitude > maxAcceleration)
				{
					result = result.normalized * maxAcceleration;
				}
			}
			return result;
		}
	}
}
