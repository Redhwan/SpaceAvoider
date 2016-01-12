using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	private Rigidbody alien;
	private Vector2 orPos;
	public Vector2 moveHor;
	public Vector2 moveVer;
	public float orPosX, xMin, xMax, yMin, yMax;


	// Use this for initialization
	void Start () {

		alien = gameObject.GetComponent<Rigidbody> ();
		moveHor = new Vector2 (1.0f, 0.0f);
		moveVer = new Vector2 (0.0f, 1.0f);
		xMin = -4.0F; 
		xMax = 4.0F;
		yMin = -2.0F;
		yMax = 8.0F;
	
	}
	
	// Update is called once per frame
	void Update () {

		movePlayers();
	}

	void movePlayers(){

		orPos = transform.position;

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			alien.MovePosition (orPos + moveHor);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			alien.MovePosition (orPos - moveHor);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			alien.MovePosition (orPos + moveVer);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			alien.MovePosition (orPos - moveVer);
		}


		GetComponent<Rigidbody>().position = new Vector2 (Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax), Mathf.Clamp(GetComponent<Rigidbody>().position.y, yMin, yMax));


	}
}
