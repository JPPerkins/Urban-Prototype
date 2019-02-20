using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField] string name = "default";
	[SerializeField] bool isActive = false;
	[SerializeField] float health = 0f;
	[SerializeField] float healthModifier = 10f;
	[SerializeField] float dexterity = 0f;
	[SerializeField] float strength = 0f;
	[SerializeField] float intelligence = 0f;
	[SerializeField] float willpower = 0f;
	[SerializeField] float stamina = 0f;
	[SerializeField] int movement = 0;
	[SerializeField] Weapon currentWeapon = null;

	private void Start()
	{
		isActive = true;
		GenerateStats();
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
	public float Health
	{
		get { return health; }
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
		get { return currentWeapon.GetDamage(strength); }
	}

	public void DealDamage(float damage)
	{
		health -= damage;
		CheckIfDead();
	}

	private void CheckIfDead()
	{
		if (health <= 0)
		{
			isActive = false;
			gameObject.SetActive(false);
		}
	}

	private void GenerateStats()
	{
		if (dexterity == 0 || strength == 0 || intelligence == 0 || willpower == 0 || stamina == 0)
		{
			dexterity = UnityEngine.Random.Range(3, 18);
			strength = UnityEngine.Random.Range(3, 18);
			intelligence = UnityEngine.Random.Range(3, 18);
			willpower = UnityEngine.Random.Range(3, 18);
			stamina = UnityEngine.Random.Range(3, 18);
			health = stamina * healthModifier;
			movement = 6;
			name = Names.GenerateName();
		}
	}
}
