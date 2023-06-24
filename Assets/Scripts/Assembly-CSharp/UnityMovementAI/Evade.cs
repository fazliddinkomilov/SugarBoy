using UnityEngine;

namespace UnityMovementAI
{
	[RequireComponent(typeof(Flee))]
	public class Evade : MonoBehaviour
	{
		public float maxPrediction = 1f;

		private Flee flee;

		private void Awake()
		{
			flee = GetComponent<Flee>();
		}

		public Vector3 GetSteering(MovementAIRigidbody target)
		{
			float magnitude = (target.Position - base.transform.position).magnitude;
			float magnitude2 = target.Velocity.magnitude;
			float num;
			if (magnitude2 <= magnitude / maxPrediction)
			{
				num = maxPrediction;
			}
			else
			{
				num = magnitude / magnitude2;
				num *= 0.9f;
			}
			Vector3 targetPosition = target.Position + target.Velocity * num;
			return flee.GetSteering(targetPosition);
		}
	}
}
