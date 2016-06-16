using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class DamagePlayer : MonoBehaviour {
	
	public Slider healthBarSlider;  //reference for slider
	public Text gameOverText;   //reference for text
	private bool isGameOver = false; //flag to see if game is over
    public int playerHealth = 30;
    int damage = 10;

    void Start()
    {
        print(playerHealth);
		gameOverText.enabled = false; //disable GameOver text on start
    }

    void OnCollisionEnter(Collision _collision)
	{
		if (_collision.gameObject.tag == "Goomba") {
			playerHealth -= damage;
			print ("I was touched." + playerHealth);
			if (playerHealth < 0) {
				SceneManager.LoadScene (1);
			}

		}
	}

	void OnTriggerStay(Collider other)
			{
		//if player triggers fire object and health is greater than 0
		if(other.gameObject.name=="Fire" && healthBarSlider.value>0)
			{
			healthBarSlider.value -=.011f;  //reduce health
			}

		else
			{
			isGameOver = true;    //set game over to true
			gameOverText.enabled = true; //enable GameOver text
			}
        }
}

