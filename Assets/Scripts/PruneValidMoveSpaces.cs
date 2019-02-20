using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruneValidMoveSpaces : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 10 || other.gameObject.layer == 12)
		{
			Destroy(gameObject.transform.parent.gameObject);
		}
		else if (other.gameObject.layer == 13)	// TODO make better, delay, something to improve this.
		{
			Destroy(gameObject.transform.parent.gameObject);
		}
	}
}
