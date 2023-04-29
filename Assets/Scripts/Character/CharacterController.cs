namespace DENT
{
	using UnityEditor.ShaderGraph.Internal;
	using UnityEngine;
	using UnityEngine.InputSystem;

	/// <summary>
	/// 
	/// </summary>
	public class CharacterController : MonoBehaviour
	{
		#region Fields
		[SerializeField] private InputActionReference _movementInput;
		[SerializeField] private InputActionReference _scanInput;
		[SerializeField] private float _force = 10;
		[SerializeField] private float _maxVelocity = 10;
		[SerializeField] private float _decreaseSpeed = 10;
		private Rigidbody _rigidbody;
		[SerializeField] private Transform _renderer = null;
		[SerializeField] private Scanner _scanner = null;
		[SerializeField] private float _cooldown = 5.0f;
		private float _cooldownTimer = 0.0f;
		[SerializeField] private bool _selectedDirectionalRadar = true;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			_cooldownTimer -= Time.deltaTime;
			Vector2 vector = _movementInput.action.ReadValue<Vector2>();
			if (vector != Vector2.zero)
			{

				_rigidbody.AddForce(new Vector3(vector.x, 0.0f, vector.y) * _force);
				_rigidbody.velocity = _rigidbody.velocity.normalized * Mathf.Min(_rigidbody.velocity.magnitude, _maxVelocity);
			}
			else
			{
				_rigidbody.AddForce(_rigidbody.velocity * _decreaseSpeed * -1.0f);
			}

			_renderer.LookAt(transform.position + _rigidbody.velocity);
			if (_scanInput.action.IsPressed() && _cooldownTimer <= 0.0f)
			{
				_cooldownTimer = _cooldown;
				//_scanner.PlaceRaycast(transform.position);
				_scanner.SpawnRaycast(transform.position, _selectedDirectionalRadar);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("You are dead !");
		}
		#endregion Methods
	}
}