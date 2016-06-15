using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DamagePlayer : MonoBehaviour {


    public int playerHealth = 30;
    int damage = 10;

    void Start()
    {
        print(playerHealth);
    }

    void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.tag == "Goomba")
        {
            playerHealth -= damage;
            print("I was touched." + playerHealth);
            if(playerHealth < 0)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
