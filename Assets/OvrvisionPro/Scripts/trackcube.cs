using UnityEngine;
using System.Collections;

public class trackcube : MonoBehaviour {
    private GameObject _parent;

	Renderer cuberenderer;

	[SerializeField]
	private Color __cubecolor;
	public Color cubecolor
	{
	    get { return this.__cubecolor; } 
	    set { this.__cubecolor = value; }
	}

	[SerializeField][Range(0.0f, 1.0f)]
	private float r;
	public float R
	{
	    get { return this.r; } 
	    set { this.r = value; }
	}
	[SerializeField][Range(0.0f, 1.0f)]
	private float g;
	public float G
	{
	    get { return this.g; } 
	    set { this.g = value; }
	}
	[SerializeField][Range(0.0f, 1.0f)]
	private float b;
	public float B
	{
	    get { return this.b; } 
	    set { this.b = value; }
	}
	[SerializeField][Range(0.0f, 1.0f)]
	private float a;
	public float A
	{
	    get { return this.a; } 
	    set { this.a = value; }
	}


	// Use this for initialization
	void Start () {
	    _parent = transform.parent.gameObject;
        cuberenderer = gameObject.GetComponent<Renderer>();
        Debug.Log("Parent:" + _parent.name);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Parent:" + _parent.transform.position);
        transform.position = _parent.transform.position;
//		cuberenderer.material.color = new Color (this.r, this.g/255.0f, this.b/255.0f,this.a);
		cuberenderer.material.color = Color.HSVToRGB(this.r,this.g,this.b);
		Debug.Log (this.r +"and"+ this.g +"and"+ this.b);
	}
}
