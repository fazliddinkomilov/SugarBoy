using UnityEngine;

public class Jump : MonoBehaviour
{
	public Vector3 jump;

	public float jumpForce = 2f;

	public bool isGrounded;

	public AudioSource jump_audio;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0f, 2f, 0f);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
			jump_audio.Play();
		}
	}
}
