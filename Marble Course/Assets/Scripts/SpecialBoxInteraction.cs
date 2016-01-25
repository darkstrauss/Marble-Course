using UnityEngine;
using System.Collections;

public class SpecialBoxInteraction : MonoBehaviour {

	//player marble
	public GameObject marble;

	//the special box that is rotated
	public GameObject movingPart;

	//"Press Me" text
	public GameObject text;

	//bool gotten from the EnableZ component in the trigger that is attached as a child
	public bool ableToRotate;

	//bool that is passed on to the MoveBackPlate component on the BackPlate gameObject that is attached as a child
	public bool moveBackPlate = false;

	//bool used to determine if the box should be moving or not
	bool startMoving = false;

	void Update(){
		//this bool is set when the marble interacts with the trigger attached to the special box
		ableToRotate = gameObject.GetComponentInChildren<EnableZ>().ableToChange;

		//when the player clicks on the left mouse button and the ableToRotate is true a ray is cast from the mousePostion on screen relative to the main camera
		if (Input.GetMouseButtonDown(0) && ableToRotate) {

			//whatever the ray hits
			RaycastHit hit;

			//from where the ray is cast
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//if the ray hits something it checks its tag. If the hit object's tag is "MouseInteract" the startMoving bool is set to true and the "Press Me" text is disabled
			if (Physics.Raycast(ray, out hit)){
				
				if (hit.collider.tag == "MouseInteract"){;
					startMoving = true;
					text.SetActive(false);
				}
			}
		}

		//when startMoving is set to true it rotates the special box around
		if (startMoving) {
			movingPart.transform.Rotate(0.0f, 45.0f * Time.deltaTime, 0.0f);

			//transform.rotation.y is calulated in Pi. When the course has reached the opposite side it stops rotating by setting startMoving to false,
			//then it re-freezes the z position transformation for the marble to prevent it from falling off course
			//and finally sets the moveBackPlate bool to true, which is used in the MoveBackPlate component in the back plate object connected as a child to this gameObject
			if (movingPart.transform.rotation.y > 0.99998) {
				gameObject.GetComponentInChildren<EnableZ>().ableToChange = false;
				startMoving = false;
				marble.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
				moveBackPlate = true;
			}
		}
	}//Update
}//SpecialBoxInteraction
