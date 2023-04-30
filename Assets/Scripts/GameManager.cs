namespace DENT
{
	using UnityEngine;

	/// <summary>
	/// 
	/// </summary>
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private GameObject _fog = null;
		[SerializeField] private Camera _azekfjghwxdkuiv = null;
		[SerializeField] private CharacterController _characterController = null;
		[SerializeField] private Transform _startSpawn = null;
		public void Start()
		{
			_fog.SetActive(true);
			_characterController.transform.position = _startSpawn.position;
			_azekfjghwxdkuiv.gameObject.SetActive(true);
		}

		public void Die()
		{
			_characterController.transform.position = _startSpawn.position;
			Debug.Log("You are dead !");
		}

		public void Win()
		{
			FindObjectOfType<SceneManagement>().LoadEndScene();
		}
		public void UpdateCamera()
		{
			_azekfjghwxdkuiv.gameObject.SetActive(false);
			_azekfjghwxdkuiv.gameObject.SetActive(true);
		}
	}
}