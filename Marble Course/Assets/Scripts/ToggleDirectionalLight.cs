using UnityEngine;
using System.Collections;

public class ToggleDirectionalLight : MonoBehaviour {

	//the light that is referenced to
	public Light mainLight;

	void Update () {
		//listens for the player to press the left mouse button. When pressed it does a check to see if the sent ray hit anything.
		//if the ray that was cast hits something it checks its connected tag to determine if it has to do something or not.
		//if the connected tag was "LightInteract" it will toggle the light
		if (Input.GetMouseButtonDown(0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit)){
				
				if (hit.collider.tag == "LightInteract" && !mainLight.gameObject.activeInHierarchy){
					mainLight.gameObject.SetActive(true);
				}
				else if (hit.collider.tag == "LightInteract"){
					mainLight.gameObject.SetActive(false);
				}
			}
		}
	}//Update
}//ToggleDirectionalLight
