using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
	[SerializeField] Text dexterityText;
	[SerializeField] Text strengthText;
	[SerializeField] Text intelligenceText;
	[SerializeField] Text willpowerText;
	[SerializeField] Text staminaText;

	public void UpdateStatUI(float dexterity, float strength, float intelligence, float willpower, float stamina)
	{
		dexterityText.text = "Dexterity: " + Mathf.RoundToInt(dexterity).ToString();
		strengthText.text = "Strength: " + Mathf.RoundToInt(strength).ToString();
		intelligenceText.text = "Intelligence: " + Mathf.RoundToInt(intelligence).ToString();
		willpowerText.text = "Willpower: " + Mathf.RoundToInt(willpower).ToString();
		staminaText.text = "Stamina: " + Mathf.RoundToInt(stamina).ToString();
	}

	public void ClearStatUI()
	{
		dexterityText.text = "";
		strengthText.text = "";
		intelligenceText.text = "";
		willpowerText.text = "";
		staminaText.text = "";
	}
}
