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
		[SerializeField] private GameObject _dialogue = null;
		[SerializeField] private GameObject _root = null;
		[SerializeField] private float _dialogDuration = 2.0f;
		private DeliveryManager _delivery = null;
		private bool _isActive = false;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_dialogue.SetActive(false);
			_delivery = FindObjectOfType<DeliveryManager>();
		}

		public void SetActive(bool active)
		{
			_isActive = active;
			if (_isActive == false)
			{
				_houseEmitter.Stop();
			}
			_root.SetActive(_isActive);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				CharacterController character = other.GetComponent<CharacterController>();
				character.DisableKill();
				if (_isActive)
				{
					_dialogue.SetActive(true);
					character.DisableControl(_dialogDuration);
					_delivery.CompleteQuest();
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				_dialogue.SetActive(false);
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