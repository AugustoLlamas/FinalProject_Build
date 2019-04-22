using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeZ;
    private GameController gameController;

    private Vector3 startPosition;
    private Vector3 currentPosition;


	// Use this for initialization
	void Start () {
        startPosition = transform.position;

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
	
	// Update is called once per frame
	void Update ()
    {
        currentPosition = transform.position;

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
      
       if (gameController.gameOver == true)
        {
            scrollSpeed = 0;
            transform.position = currentPosition;
        }
    }
    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (gameController.win == true)
        { 
            tileSizeZ = 60;
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
            scrollSpeed = -10;
            transform.position = currentPosition;
        }
    }
}
