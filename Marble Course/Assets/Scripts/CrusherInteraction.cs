using UnityEngine;
using System.Collections;

public class CrusherInteraction : MonoBehaviour {

	//refered to light for the crusher
	public Light crusherLight;

	//refered to particle effect that triggers when the marble interacts with the crusher trigger
	public GameObject crusherParticle;

	//when the marble enters the trigger a red light turns on, the marble is detroyed and a 'blood' particle effect activates
	void OnTriggerEnter(Collider other){
		crusherLight.gameObject.SetActive (true);
		Destroy (other.gameObject);
		crusherParticle.SetActive (true);
	}//OnTriggerEnter
}//CrusherInteraction
