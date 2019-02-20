using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] string name = "default";
	[SerializeField] bool isActive = false;
	[SerializeField] float dexterity = 0f;
	[SerializeField] float strength = 0f;
	[SerializeField] float intelligence = 0f;
	[SerializeField] float willpower = 0f;
	[SerializeField] float stamina = 0f;
	[SerializeField] int movement = 0;

	private void Start()
	{
		isActive = true;
		gameObject.name = name;
	}

	public bool IsActive
	{
		get { return isActive; }
	}

	public string Name
	{
		get { return name; }
	}

	public float Dexterity
	{
		get { return dexterity; }
	}
	public float Strength
	{
		get { return strength; }
	}
	public float Intelligence
	{
		get { return intelligence; }
	}
	public float Willpower
	{ 
		get { return willpower; }
	}
	public float Stamina
	{
		get { return stamina; }
	}
	public int Movement
	{
		get { return movement; }
	}
}
