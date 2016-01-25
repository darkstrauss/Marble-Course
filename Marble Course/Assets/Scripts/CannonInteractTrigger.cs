using UnityEngine;
using System.Collections;

public class CannonInteractTrigger : MonoBehaviour {

	//bool to be passed to the CannonInteract script
	public bool ableToFire;

	void Start(){
		//on start sets the bool to false
		ableToFire = false;
	}//Start

	void OnTriggerEnter(Collider other){
		//when the marble interacts with the trigger the bool is set to true, this bool is used to determine if the cannon can be loaded
		ableToFire = true;
	}//OnTriggerEnter
}//CannonInteractTrigger
