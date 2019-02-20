using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruneValidMoveSpaces : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 10 || other.gameObject.layer == 12)
		{
			Debug.Log(other.gameObject + " is not valid");
			//other.gameObject.transform.parent.gameObject;
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}
