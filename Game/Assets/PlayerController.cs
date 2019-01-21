using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject selectedObject;

    public delegate GameObject OnSelected(GameObject go);
    public OnSelected OnSelectedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            GameObject selected = getClickSelection(Physics.RaycastAll(ray));
            if (selectedObject != null)
            {
                selectedObject.GetComponent<Selectable>().deselect();
            }
            if (selected != null)
            {
                selected.GetComponent<Selectable>().select();
            }
            selectedObject = selected;
            OnSelectedObject(selected);
            Debug.Log(selected);
        }
    }

    private GameObject getClickSelection(RaycastHit[] hits)
    {
        float distance = float.MaxValue;
        GameObject selected = null;
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            if (hit.transform.GetComponent<Selectable>() != null) {
                if (hit.distance < distance)
                {
                    distance = hit.distance;
                    selected = hit.transform.gameObject;
                }
            }
        }
        return selected;
    }
}
