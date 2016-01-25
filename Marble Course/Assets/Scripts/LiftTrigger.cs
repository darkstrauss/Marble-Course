using UnityEngine;
using System.Collections;

public class LiftTrigger : MonoBehaviour {

	//bools used to control the lift's behaviour
	public bool move = false;
	public bool rotate = true;

	void OnTriggerEnter(Collider marble){
		//when the marble enters the trigger the lift starts to move
		move = true;
	}//OnTriggerEnter

	void Update(){
		//when move is true the lift move up and slightly to the right
		if (move) {
			gameObject.transform.Translate(1.0f * Time.deltaTime, 10.0f * Time.deltaTime, 0);
		}

		//when the lift reached the desired height it stops moving up and starts rotating
		if (gameObject.transform.position.y > 20 && rotate) {
			move = false;
			gameObject.transform.Rotate(0.0f, 0.0f, -120.0f * Time.deltaTime);
		}

		//rotation.z is calulated in Pi. When the desired rotation is achives it stops
		if (gameObject.transform.rotation.z > 0.835f) {
			rotate = false;
		}
	}//Update
}//LiftTrigger
