using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private Vector3 velocity;
	private GameManager gm;

	// Use this for initialization
	void Start () {

		GameObject GameManagerObject = GameObject.Find ("GameManager");
		gm = GameManagerObject.GetComponent<GameManager> ();

		velocity = GetComponent<Rigidbody>().velocity;
		velocity.y = -(gm.bulletSpeed);
 		GetComponent<Rigidbody>().velocity = velocity;

//		Invoke ("destoryAfter", 1); 

	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter(Collider col){

		if (col.name == "Player") {
			Destroy (gameObject);
			Destroy (col.gameObject);
			gm.playerDied();
		}
		if (col.name == "Boundry") {
			Destroy (gameObject);
		}
	}

//	void destoryAfter(){
//		Destroy (gameObject);
//	}

}
