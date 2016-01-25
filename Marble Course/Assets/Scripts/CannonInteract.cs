using UnityEngine;
using System.Collections;

public class CannonInteract : MonoBehaviour {

	//bools needed to control the interaction
	bool readyFire;
	bool startMoving = false;
	bool inPosition = false;

	//gameObjects that are referenced to
	public GameObject trigger;
	public GameObject marble;
	public GameObject cannon;
	public GameObject launchText;
	public GameObject closeText;

	//lights that are referenced to
	public Light redLight;
	public Light greenLight;
	public Light thirdSectionLight;
	public Light fourthSectionLight;

	void Update () {

		//gets the bool value from the cannons trigger
		readyFire = trigger.GetComponent<CannonInteractTrigger> ().ableToFire;

		//when the marble falls into the cannon the text apears to allow the player to close it, turns on a red feedback light, and turns off the third section lighting
		if (readyFire && !startMoving && !inPosition) {
			closeText.SetActive(true);
			redLight.gameObject.SetActive(true);
			thirdSectionLight.gameObject.SetActive(false);
		}

		//a raycast is sent when the player clicks in the game world and the marble has interacted with the cannon trigger
		if (Input.GetMouseButtonDown(0) && readyFire) {

			//refered to object that the raycast hits
			RaycastHit hit;

			//how the ray casts. In this instance its from the mousePosition on screen relative to the main camera
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//if the ray hits something
			if (Physics.Raycast(ray, out hit)){

				//it will check the hit objects tag to determine what to do with the cast. inPosition referes to the cannon being closed or not.
				if (hit.collider.tag == "CannonInteract" && !inPosition){
					//this disables the "Close" text that is shown on screen for the player to close the cannon, preventing further interaction
					closeText.SetActive(false);

					//allows the next step in the interaction for the cannon
					startMoving = true;
				}

				//when the "LAUNCH!!!" text appears on screen the player can click on it to 'launch' the marble
				if (hit.collider.tag == "CannonInteract" && inPosition) {

					//add velocity to the marble up and right
					marble.GetComponent<Rigidbody>().AddForce(new Vector3(75, 70, 0), ForceMode.VelocityChange);

					//disables the "LAUNCH!!!" text
					launchText.SetActive(false);

					//disables the green feedback light
					greenLight.gameObject.SetActive(false);

				}
			}
		}

		//when the player presses the "Close" text on screen it animates the cannon to a closed position
		if (startMoving && !inPosition) {

			//rotates the cannon's top part to a closed position
			cannon.transform.Rotate(0.0f, 0.0f, -45.0f * Time.deltaTime);

			//when the cannon has rotated far enough it stops and allows the next step in the interaction
			//first it stops the cannon from closing any further, then tells that the marble is in position,
			//enables the "LAUNCH!!!" text so the player can interact with the cannon once again
			//disables the red feedback light and turns on a green feedback light
			//and turns on the light at the target
			if (cannon.transform.rotation.z < -0.36f) {
				startMoving = false;
				inPosition = true;
				launchText.SetActive(true);
				redLight.gameObject.SetActive(false);
				greenLight.gameObject.SetActive(true);
				fourthSectionLight.gameObject.SetActive(true);
			}
		}
	}//Update
}//CannonInteract
