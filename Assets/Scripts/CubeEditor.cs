using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
	[SerializeField] Vector3 position;

	private void Update()
	{
		SnapPosition();
		RenameCube();
	}

	private void SnapPosition()
	{
		position = gameObject.transform.position;
		position.x = Mathf.FloorToInt(position.x);
		position.y = Mathf.FloorToInt(position.y);
		position.z = Mathf.FloorToInt(position.z);

		gameObject.transform.position = position;
	}

	private void RenameCube()
	{
		string newName = transform.position.x + "," + transform.position.z;
		var child = transform.GetChild(0);

		gameObject.name = newName;
		child.name = newName + " Cube";
	}
}
