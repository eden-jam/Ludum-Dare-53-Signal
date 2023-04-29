namespace DENT
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	/// <summary>
	/// 
	/// </summary>
	public class SceneManagement : MonoBehaviour
	{
		#region Fields
		#endregion Fields

		#region Methods
		public void LoadSampleScene()
		{
			SceneManager.LoadScene("SampleScene");
		}

		public void LoadStartScene()
		{
			SceneManager.LoadScene("StartScene");
		}

		public void LoadEndScene()
		{
			SceneManager.LoadScene("EndScene");
		}
		#endregion Methods
	}
}