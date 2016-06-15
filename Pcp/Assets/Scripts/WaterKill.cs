using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WaterKill : MonoBehaviour {

    public int level = 1;

	void OnTriggerEnter (Collider other)
    {
		if (other.gameObject.tag == "Player") 
		{
			SceneManager.LoadScene (level);
		}
    }
}
