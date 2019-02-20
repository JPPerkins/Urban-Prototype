using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateValidMoves : MonoBehaviour
{
	[SerializeField] GameObject validMovement = null;
	[SerializeField] Dictionary<Vector2, GameObject> validMovementPairs = null;
	[SerializeField] int validMoveSize = 0;

	public void Start()
	{
		validMovementPairs = new Dictionary<Vector2, GameObject>();
	}

	public void SelectCharacter(Character character)
	{
		Vector3 origin = character.transform.position;
		

		for (int x = -character.Movement; x <= character.Movement; x++)
		{
			for (int z = -character.Movement; z <= character.Movement; z++)
			{
				if ((Mathf.Abs(x) + Mathf.Abs(z)) <= character.Movement && !(x == 0 && z == 0))
				{
					if (!validMovementPairs.ContainsKey(new Vector2(x,z)))
					{
						Vector3 newValidPosition = new Vector3(origin.x + x, origin.y, origin.z + z);
						GameObject newValidMovement = Instantiate(validMovement, newValidPosition, Quaternion.identity, gameObject.transform);
						newValidMovement.name = x + ", " + z;
						validMovementPairs.Add(new Vector2(x, z), newValidMovement);
					}
				}
			}
		}
		validMoveSize = validMovementPairs.Count;
	}

	public void DeselectCharacter()
	{
		foreach (KeyValuePair<Vector2, GameObject> deleteThis in validMovementPairs)
		{
			Destroy(deleteThis.Value);
		}
		validMovementPairs.Clear();
		validMoveSize = 0;
	}
}
