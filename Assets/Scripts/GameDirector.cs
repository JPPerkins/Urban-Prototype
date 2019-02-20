using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
	enum State {
		Start_Encounter,	// Start the round
		Start_Round,		// Find the characters
		Character_Turn,		// assign next character
		End_Round,			// check to see if game won
		End_Encounter,		// check to see if round is over 

	}

	[SerializeField] State state = State.Start_Encounter;
	[SerializeField] Player[] currentPlayers = null;
	[SerializeField] List<Character> currentCharacters = null;
	[SerializeField] Text playerText, turnText;
	[SerializeField] Player activePlayer = null;
	[SerializeField] Character activeCharacter = null;
	[SerializeField] int turnsTaken;
	[SerializeField] int currentRound = 1;
	[SerializeField] int maxRounds = 10;
	[SerializeField] GameObject selectedCharacter = null;
	[SerializeField] StatUI selectedCharacterStats = null;
	[SerializeField] GenerateValidMoves validMoveParent = null;
	[SerializeField] CameraRaycaster cameraRaycaster = null;

	// Start is called before the first frame update
	void Start()
    {
		currentPlayers = FindObjectsOfType<Player>();
		cameraRaycaster = FindObjectOfType<CameraRaycaster>();
		ProcessState();
	}

	// Update is called once per frame
	void Update()
    {
		UpdateInterface();
    }

	void ProcessState()
	{
		switch (state)
		{
			case State.Start_Encounter:
				StartEncounter();
				break;
			case State.Start_Round:
				StartRound();
				break;
			case State.Character_Turn:
				CharacterTurn();
				break;
			case State.End_Round:
				EndRound();
				break;
			case State.End_Encounter:
				EndEncounter();
				break;
			default:
				break;
		}
	}

	private void StartEncounter()
	{
		currentRound = 1;
		state = State.Start_Round;
		ProcessState();
	}

	private void StartRound()
	{
		currentCharacters.Clear();
		GetActiveCharacters();
		state = State.Character_Turn;
		ProcessState();
	}

	private void CharacterTurn()
	{
		validMoveParent.DeselectCharacter();
		activeCharacter = GetNextCharacter();
		if (activeCharacter == null)
		{
			state = State.End_Round;
			ProcessState();
		}
		validMoveParent.SelectCharacter(activeCharacter);
		cameraRaycaster.SetCharacter(activeCharacter);
		selectedCharacter.transform.position = activeCharacter.transform.position;
		selectedCharacter.SetActive(true);
	}

	private void EndRound()
	{
		state = State.Start_Round;
		currentRound++;
		ProcessState();
	}

	private void EndEncounter()
	{
		Debug.Log("Ending Encounter");
		state = State.Start_Encounter;
		ProcessState();
	}

	private void GetActiveCharacters()
	{
		turnsTaken = 0;

		foreach (Player player in FindObjectsOfType<Player>())
		{
			foreach (Character character in player.PlayerForce)
			{
				if (character.IsActive)
				{
					currentCharacters.Add(character);
				}
			}
		}
		currentCharacters.Sort((x, y) => y.Dexterity.CompareTo(x.Dexterity));
	}

	private Character GetNextCharacter()
	{
		if (turnsTaken < currentCharacters.Count)
		{
			return currentCharacters[turnsTaken];
		}
		return null;
	}

	private void UpdateInterface()
	{
		playerText.text = activeCharacter.Name;
		turnText.text = "Round: " + currentRound.ToString();
		if (activeCharacter != null)
		{
			selectedCharacterStats.UpdateStatUI(activeCharacter);
		}
		else
		{
			selectedCharacterStats.ClearStatUI();
		}
	}

	private void ProcessPlayerInput()
	{
		//Debug.Log("Character " + activeCharacter.Name + " Ended Turn");
		turnsTaken++;
	}

	public void EndTurn()
	{
		ProcessPlayerInput();
		ProcessState();
	}

	public void moveCharacter(Vector3 newPosition)
	{
		activeCharacter.transform.position = newPosition;
	}
}
