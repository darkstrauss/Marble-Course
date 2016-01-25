using UnityEngine;
using System.Collections;

public class MoveBackPlate : MonoBehaviour {

	//bool gotten from the SpecialBoxInteraction component on the parent gameObject
	bool move;

	void Update () {
		//sets move every frame to the value that SpecialBoxInteraction.moveBackPlate has
		move = gameObject.GetComponentInParent<SpecialBoxInteraction> ().moveBackPlate;

		//when move is set to true the cube holding the marble in place moves down to let it continue
		if (move) {
			gameObject.transform.Translate(0.0f, -0.5f * Time.deltaTime, 0.0f);

			//when the back plate reaches the disired height it stops and sets the bool in SpecialBoxInteraction back to false
			if (gameObject.transform.position.y < 9.7f) {
				gameObject.GetComponentInParent<SpecialBoxInteraction>().moveBackPlate = false;
			}
		}
	}//Update
}//MoveBackPlate
