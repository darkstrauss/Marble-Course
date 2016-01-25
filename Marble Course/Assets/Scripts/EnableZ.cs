using UnityEngine;
using System.Collections;

public class EnableZ : MonoBehaviour {

	//player marble
	public GameObject marble;

	//"Press Me" text
	public GameObject text;

	//bool needed to determine if the track should change or not
	public bool ableToChange = false;

	//refered to lights
	public Light thirdAreaLight;
	public Light marbleLight;

	//when the marble reaches the special box trigger
	void OnTriggerEnter(Collider other){
		//enables the "Press Me" text
		text.SetActive (true);

		//allows the track to be changed
		ableToChange = true;

		//detroys the marbles connected light
		Destroy (marbleLight.gameObject);

		//removes all constraints from the marble so when the trach changes it doesn't fall off
		other.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;

		//eluminates the third section
		thirdAreaLight.gameObject.SetActive (true);
	}//OnTriggerEnter
}//EnableZ
