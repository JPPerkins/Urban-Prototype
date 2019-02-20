using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
	[SerializeField] bool isColliding = false;
	[SerializeField] bool isValidMove = false;

	public bool IsColliding
	{
		get { return isColliding;  }
	}
	public bool IsValidMove
	{
		get { return isValidMove; }
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			isValidMove = true;
			isColliding = false;
		}
		else
		{
			isValidMove = false;
			isColliding = true;
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			isValidMove = true;
			isColliding = false;
		}
		else
		{
			isValidMove = false;
			isColliding = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		isColliding = false;
		isValidMove = false;
	}	
}
