using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.CompareTag ("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();

        }
        else if (other.CompareTag("Ally"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        else if (gameController.win == true || gameController.gameOver == true)
        {
            scoreValue = 0;
        }
        gameController.AddScore(scoreValue);
        Destroy(gameObject);

    }
}
