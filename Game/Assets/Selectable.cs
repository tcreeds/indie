using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    private Color actualColor;
    private Material material;

	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
        actualColor = material.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void select()
    {
        actualColor = material.color;
        material.color = Color.blue;
    }

    public void deselect()
    {
        material.color = actualColor;
    }
}
