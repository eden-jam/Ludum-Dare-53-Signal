namespace DENT
{
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
		[SerializeField] private float _speed = 100;
		private Rigidbody _rigidbody;
		[SerializeField] private Scanner _scanner = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			Vector2 vector = _movementInput.action.ReadValue<Vector2>();
			_rigidbody.velocity = new Vector3(vector.x, 0.0f, vector.y) * _speed * Time.deltaTime;
			if (_scanInput.action.IsPressed())
			{
				_scanner.PlaceRaycast(transform.position);
			}
		}
		#endregion Methods
	}
}