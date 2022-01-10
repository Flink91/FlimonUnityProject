using UnityEngine;

public class Shop : MonoBehaviour
{

	public TurretBlueprint standardTurret;
	public TurretBlueprint turtleTurret;
	public TurretBlueprint missileLauncherTurret;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectTurtleTurret()
	{
		Debug.Log("Turtle Turret Selected");
		buildManager.SelectTurretToBuild(turtleTurret);
	}

	public void SelectMissileLauncherTurret()
	{
		Debug.Log("Missile Launcher Turret Selected");
		buildManager.SelectTurretToBuild(missileLauncherTurret);
	}

}