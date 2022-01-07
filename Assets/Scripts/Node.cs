using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Vector3 positionOffset;
    [Header("Optional")]
	public GameObject turret;

	private Renderer rend;
	private Color startColor;

    BuildManager buildManager;

    void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

	void OnMouseDown ()
    {

        // prevent UI clicks to also go through to the game world
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        // prevent building with turret as null
        if (!buildManager.CanBuild)
            return;
 
        buildManager.buildTurretOn(this);
        
    }

    void OnMouseEnter ()
	{

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

}
