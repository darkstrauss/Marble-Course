using UnityEngine;
using System.Collections;

public class AnimateCrusher : MonoBehaviour {

	//variable to be set in the editor
	public float ROTATE_SPEED;

	void Update () {
		//rotates the connected gameObject
		gameObject.transform.Rotate (0, 0, ROTATE_SPEED * Time.deltaTime);
	}//Update
}//AnimateCrusher
