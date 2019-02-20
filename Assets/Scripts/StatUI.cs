using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
	[SerializeField] Text healthText;
	[SerializeField] Text dexterityText;
	[SerializeField] Text strengthText;
	[SerializeField] Text intelligenceText;
	[SerializeField] Text willpowerText;
	[SerializeField] Text staminaText;

	public void UpdateStatUI(Character character)
	{
		healthText.text = "Health: " + Mathf.RoundToInt(character.Health).ToString();
		dexterityText.text = "Dexterity: " + Mathf.RoundToInt(character.Dexterity).ToString();
		strengthText.text = "Strength: " + Mathf.RoundToInt(character.Strength).ToString();
		intelligenceText.text = "Intelligence: " + Mathf.RoundToInt(character.Intelligence).ToString();
		willpowerText.text = "Willpower: " + Mathf.RoundToInt(character.Intelligence).ToString();
		staminaText.text = "Stamina: " + Mathf.RoundToInt(character.Stamina).ToString();
	}

	public void ClearStatUI()
	{
		healthText.text = "";
		dexterityText.text = "";
		strengthText.text = "";
		intelligenceText.text = "";
		willpowerText.text = "";
		staminaText.text = "";
	}
}
