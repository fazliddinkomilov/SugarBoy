using System.Collections.Generic;
using UnityEngine;

namespace UnityMovementAI
{
	public class NearSensor : MonoBehaviour
	{
		private HashSet<MovementAIRigidbody> _targets = new HashSet<MovementAIRigidbody>();

		public SteeringBasics controll;

		public HashSet<MovementAIRigidbody> targets
		{
			get
			{
				_targets.RemoveWhere(IsNull);
				return _targets;
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (base.gameObject.tag == "Car" && other.gameObject.tag == "People")
			{
				controll.maxVelocity = 0f;
			}
		}

		private static bool IsNull(MovementAIRigidbody r)
		{
			if (!(r == null))
			{
				return r.Equals(null);
			}
			return true;
		}

		private void TryToAdd(Component other)
		{
			MovementAIRigidbody component = other.GetComponent<MovementAIRigidbody>();
			if (component != null)
			{
				_targets.Add(component);
			}
		}

		private void TryToRemove(Component other)
		{
			MovementAIRigidbody component = other.GetComponent<MovementAIRigidbody>();
			if (component != null)
			{
				_targets.Remove(component);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			TryToAdd(other);
		}

		private void OnTriggerExit(Collider other)
		{
			TryToRemove(other);
			if (other.gameObject.tag == "People")
			{
				controll.maxVelocity = controll.currentMaxVel;
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			TryToAdd(other);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			TryToRemove(other);
		}
	}
}
