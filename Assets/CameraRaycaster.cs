﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
	[SerializeField] int[] layerPriorities;
	[SerializeField] GameObject mouseHover;
	[SerializeField] GameObject mouseClick;
	//[SerializeField] int yOffset = 1;
	//[SerializeField] Vector3 clickPosition;
	// Update is called once per frame

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] raycastHits = Physics.RaycastAll(ray, 100);
		RaycastHit? priorityHit = FindTopPriorityHit(raycastHits);

		if (priorityHit.HasValue)
		{
			Vector3 gridPosition = FindGridPosition(priorityHit);

			mouseHover.transform.position = gridPosition;
			mouseHover.SetActive(true);
			bool spaceIsUsed = mouseHover.GetComponentInChildren<MouseHover>().IsColliding;
			bool isValidMove = mouseHover.GetComponentInChildren<MouseHover>().IsValidMove;

			if (Input.GetMouseButtonDown(0) && !spaceIsUsed && isValidMove)
			{
				mouseClick.transform.position = gridPosition;
				mouseClick.SetActive(true);
				GameDirector gameDirector = FindObjectOfType<GameDirector>();
				gameDirector.moveCharacter(gridPosition);
				gameDirector.EndTurn();
			}
			else if (Input.GetMouseButtonDown(0) && spaceIsUsed)
			{
				mouseClick.transform.position = gridPosition;
				mouseClick.SetActive(true);
				Debug.Log("Space is Used");
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				mouseClick.SetActive(false);
			}
			mouseHover.SetActive(false);
		}
	}

	private RaycastHit? FindTopPriorityHit(RaycastHit[] raycastHits)
	{
		List<int> layersOfHitColliders = new List<int>();
		foreach (RaycastHit hit in raycastHits)
		{
			layersOfHitColliders.Add(hit.collider.gameObject.layer);
		}

		foreach (int layer in layerPriorities)
		{
			foreach (RaycastHit hit in raycastHits)
			{
				if (hit.collider.gameObject.layer == layer)
				{
					return hit;
				}
			}
		}
		return null;
	}

	private Vector3 FindGridPosition(RaycastHit? priorityHit)
	{
		Vector3 clickPosition = new Vector3
		{
			x = Mathf.FloorToInt(priorityHit.Value.point.x),
			y = Mathf.FloorToInt(priorityHit.Value.point.y),
			z = Mathf.FloorToInt(priorityHit.Value.point.z)
		};
		return clickPosition;
	}
}
