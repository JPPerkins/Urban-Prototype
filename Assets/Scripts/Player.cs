using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] string name = "default";
	[SerializeField] Character[] playerForce;

	private void Start()
	{
		playerForce = GetComponentsInChildren<Character>();
		gameObject.name = name;
	}

	public string Name
	{
		get { return name; }
	}


	
	public Character[] PlayerForce
	{
		get { return playerForce;  }
	}

}
