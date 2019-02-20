using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateValidMoves : MonoBehaviour
{
	[SerializeField] GameObject validMovement = null;
	[SerializeField] List<GameObject> validMovementList = null;

	public void Start()
	{
		validMovementList = new List<GameObject>();
	}

	public void SelectCharacter(Character character)
	{
		Vector3 origin = character.transform.position;
		Debug.Log(character.Movement);

		for (int x = -character.Movement; x <= character.Movement; x++)
		{
			for (int z = -character.Movement; z <= character.Movement; z++)
			{
				if ((Mathf.Abs(x) + Mathf.Abs(z)) <= character.Movement && !(x == 0 && z == 0))
				{
					Vector3 newValidPosition = new Vector3(origin.x + x, origin.y, origin.z + z);
					GameObject newValidMovement = Instantiate(validMovement, newValidPosition, Quaternion.identity, gameObject.transform);
					newValidMovement.name = "New Valid Point: (" + x + ", " + z + ")";
					validMovementList.Add(newValidMovement);
				}
			}
		}
	}

	public void DeselectCharacter()
	{
		foreach (GameObject deleteThis in validMovementList)
		{
			Destroy(deleteThis);
		}
	}
}
