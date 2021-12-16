using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public GameObject standardTurretPrefab;
	public GameObject anotherTurretPrefab;

	private TurretBlueprint turretToBuild;

	// This is a property, a function that only gets a value by immediately calling this function. Used by the Node script
	public  bool CanBuild { get { return turretToBuild != null; } }

	public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
	{
		if (PlayerStats.Money >= turretBlueprint.cost)
		{
			turretToBuild = turretBlueprint;
        }
        else
        {
			// don't select turret if not enough money
			return;
        }
	}

	public void buildTurretOn(Node node)

    {
		if (PlayerStats.Money >= turretToBuild.cost)
		{
			PlayerStats.Money -= turretToBuild.cost;
			GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
			node.turret = turret;
			turretToBuild = null;
        }
        else
        {
			// not enough money
			return;
        }
	}

}
