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

    private void Update()
    {
		if (Input.GetMouseButtonDown(1))
		{
			DeselectNode();
			turretToBuild = null;
		}
	}

    public GameObject standardTurretPrefab;
	public GameObject anotherTurretPrefab;

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public TurretUI turretUI;

	// This is a property, a function that only gets a value by immediately calling this function. Used by the Node script
	public  bool CanBuild { get { return turretToBuild != null; } }


	public void SelectNode(Node node)
    {
		//if you click a turret twice it unselects it again
		if(selectedNode == node)
        {
			DeselectNode();
			return;
        }
		selectedNode = node;
		turretToBuild = null;

		turretUI.SetTarget(node);
	}

	public void DeselectNode()
    {
		selectedNode = null;
		turretUI.Hide();
    }
	public void SelectTurretToBuild(TurretBlueprint turretBlueprint)
	{
		if (PlayerStats.Money >= turretBlueprint.cost)
		{
			turretToBuild = turretBlueprint;
			DeselectNode();
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
			Debug.Log("hi" + node);
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
