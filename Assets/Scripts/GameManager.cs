using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float bulletSpeed = 10.0f;
	public GameObject bullet;
	private Vector3 spawnPosition;
	private float bulletX, bulletY, bulletZ;
	public bool gameOver, callGamover, callRestart;
	public GameObject gameOverText, restartText;

	// Use this for initialization
	void Start () {
		bulletY = bullet.transform.position.y;
		bulletZ = bullet.transform.position.z;

		InvokeRepeating ("spawnBulletWave", 3, 0.1F);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver){
			if(callGamover){
				gameIsOver();
				Invoke("setCallRestart", 2);
				callGamover = false;
			}
			if(callRestart){
				restart ();
			}
//			return;
		}


	}


	void spawnBulletWave() {
		bulletX = Mathf.Round (Random.Range (-4.0f, 4.0f));
		Instantiate(bullet, new Vector3(bulletX, bulletY, bulletZ), Quaternion.identity);
	}

	public void playerDied(){
		gameOver = true;
		callGamover = true;
	}

	void gameIsOver(){
		gameOverText.SetActive (true);
		CancelInvoke ("spawnBulletWave");
	}

	void setCallRestart(){
		callRestart = true;
		restartText.SetActive (true);
	}

	void restart(){
		if (Input.anyKeyDown)
			Application.LoadLevel (Application.loadedLevel);
	}

}
