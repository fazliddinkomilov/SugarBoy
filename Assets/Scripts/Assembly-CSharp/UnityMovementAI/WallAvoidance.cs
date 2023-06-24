using System;
using UnityEngine;

namespace UnityMovementAI
{
	[RequireComponent(typeof(SteeringBasics))]
	public class WallAvoidance : MonoBehaviour
	{
		public enum WallDetection
		{
			Raycast = 0,
			Spherecast = 1
		}

		private struct GenericCastHit
		{
			public Vector3 point;

			public Vector3 normal;

			public GenericCastHit(RaycastHit h)
			{
				point = h.point;
				normal = h.normal;
			}

			public GenericCastHit(RaycastHit2D h)
			{
				point = h.point;
				normal = h.normal;
			}
		}

		public float maxAcceleration = 40f;

		public WallDetection wallDetection = WallDetection.Spherecast;

		public LayerMask castMask = -5;

		public float wallAvoidDistance = 0.5f;

		public float mainWhiskerLen = 1.25f;

		public float sideWhiskerLen = 0.701f;

		public float sideWhiskerAngle = 45f;

		private MovementAIRigidbody rb;

		private SteeringBasics steeringBasics;

		private void Awake()
		{
			rb = GetComponent<MovementAIRigidbody>();
			steeringBasics = GetComponent<SteeringBasics>();
		}

		public Vector3 GetSteering()
		{
			if (rb.Velocity.magnitude > 0.005f)
			{
				return GetSteering(rb.Velocity);
			}
			return GetSteering(rb.RotationAsVector);
		}

		public Vector3 GetSteering(Vector3 facingDir)
		{
			Vector3 zero = Vector3.zero;
			if (!FindObstacle(facingDir, out var firstHit))
			{
				return zero;
			}
			Vector3 targetPosition = firstHit.point + firstHit.normal * wallAvoidDistance;
			float num = Vector3.Angle(rb.Velocity, firstHit.normal);
			if (num > 165f)
			{
				Vector3 vector = ((!rb.is3D) ? new Vector3(0f - firstHit.normal.y, firstHit.normal.x, firstHit.normal.z) : new Vector3(0f - firstHit.normal.z, firstHit.normal.y, firstHit.normal.x));
				targetPosition += vector * Mathf.Sin((num - 165f) * ((float)Math.PI / 180f)) * 2f * wallAvoidDistance;
			}
			return steeringBasics.Seek(targetPosition, maxAcceleration);
		}

		private bool FindObstacle(Vector3 facingDir, out GenericCastHit firstHit)
		{
			facingDir = rb.ConvertVector(facingDir).normalized;
			Vector3[] array = new Vector3[3]
			{
				facingDir,
				default(Vector3),
				default(Vector3)
			};
			float num = SteeringBasics.VectorToOrientation(facingDir, rb.is3D);
			array[1] = SteeringBasics.OrientationToVector(num + sideWhiskerAngle * ((float)Math.PI / 180f), rb.is3D);
			array[2] = SteeringBasics.OrientationToVector(num - sideWhiskerAngle * ((float)Math.PI / 180f), rb.is3D);
			return CastWhiskers(array, out firstHit);
		}

		private bool CastWhiskers(Vector3[] dirs, out GenericCastHit firstHit)
		{
			firstHit = default(GenericCastHit);
			bool result = false;
			for (int i = 0; i < dirs.Length; i++)
			{
				float distance = ((i == 0) ? mainWhiskerLen : sideWhiskerLen);
				if (GenericCast(dirs[i], out var hit, distance))
				{
					result = true;
					firstHit = hit;
					break;
				}
			}
			return result;
		}

		private bool GenericCast(Vector3 direction, out GenericCastHit hit, float distance = float.PositiveInfinity)
		{
			bool flag = false;
			Vector3 colliderPosition = rb.ColliderPosition;
			if (rb.is3D)
			{
				flag = ((wallDetection != 0) ? Physics.SphereCast(colliderPosition, rb.Radius * 0.5f, direction, out var hitInfo, distance, castMask.value) : Physics.Raycast(colliderPosition, direction, out hitInfo, distance, castMask.value));
				hit = new GenericCastHit(hitInfo);
				if (!rb.canFly && flag && Vector3.Angle(Vector3.up, hit.normal) < rb.slopeLimit)
				{
					hit.normal = rb.ConvertVector(hit.normal);
					flag = false;
				}
			}
			else
			{
				bool queriesStartInColliders = Physics2D.queriesStartInColliders;
				Physics2D.queriesStartInColliders = false;
				RaycastHit2D h = ((wallDetection != 0) ? Physics2D.CircleCast(colliderPosition, rb.Radius * 0.5f, direction, distance, castMask.value) : Physics2D.Raycast(colliderPosition, direction, distance, castMask.value));
				flag = h.collider != null;
				hit = new GenericCastHit(h);
				Physics2D.queriesStartInColliders = queriesStartInColliders;
			}
			return flag;
		}
	}
}
