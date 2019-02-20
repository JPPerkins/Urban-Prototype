using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] float bonusDamage = 0;

	public float GetDamage(float strength)
	{
		return bonusDamage + strength;
	}
}
