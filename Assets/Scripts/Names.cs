using UnityEngine;

public static class Names
{
	static string[] names = null;
	private static void CreateArray()
	{
		names = new string[] {"Emma", "Liam", "Noah", "Olivia","Ava","Isabella","Sophia","Elijah","Logan","Mia",
			"Mason","James","Aiden","Ethan","Lucas","Jacob","Michael","Matthew","Benjamin","Amelia","Charlotte","Alexander",
			"William","Daniel","Jayden","Oliver","Carter","Sebastian","Joseph","David","Abigail","Emily","Gabriel","Julian",
			"Jackson","Anthony","Harper","Evelyn","Dylan","Wyatt","Madison","Grayson","Isaiah","Christopher","Joshua","Victoria",
			"Christian","Samuel","Andrew","Mateo"};
	}

	public static string GenerateName()
	{
		if (names == null)
		{
			CreateArray();
		}
		return names[UnityEngine.Random.Range(0, names.Length)];
	}
}
