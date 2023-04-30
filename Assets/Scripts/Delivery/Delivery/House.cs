namespace DENT
{
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class House : MonoBehaviour
	{
		#region Fields
		[SerializeField] private ParticleSystem _houseEmitter = null;
		private DeliveryManager _delivery = null;
		private bool _isActive = false;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_delivery = FindObjectOfType<DeliveryManager>();
		}

		public void SetActive(bool active)
		{
			_isActive = active;
			gameObject.SetActive(_isActive);
			if (_isActive == false)
			{
				_houseEmitter.Stop();
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<CharacterController>().DisableKill();
				if (_isActive)
				{
					_delivery.CompleteQuest();
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<CharacterController>().EnableKill();
			}
		}

		public void IsScanned()
		{
			if (_isActive)
			{
				_houseEmitter.Play();
			}
		}
		#endregion Methods
	}
}