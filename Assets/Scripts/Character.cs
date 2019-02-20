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
		generateStats();
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
	public float Attack
	{
		get { return strength; }
	}

	private void generateStats()
	{
		if (dexterity == 0 || strength == 0 || intelligence == 0 || willpower == 0 || stamina == 0)
		{
			dexterity = Random.Range(3, 18);
			strength = Random.Range(3, 18);
			intelligence = Random.Range(3, 18);
			willpower = Random.Range(3, 18);
			stamina = Random.Range(3, 18);
			movement = 6;
		}
	}
}
