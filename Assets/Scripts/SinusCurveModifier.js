// This script is placed in public domain. The author takes no responsibility for any possible harm.

var scale = 10.0;
var speed = 1.0;
private var baseHeight : Vector3[];
var useOriginal : boolean = false;


function Update () {
	var mesh : Mesh = GetComponent(MeshFilter).mesh;
	
	if (baseHeight == null)
		baseHeight = mesh.vertices;
	
	// gameObject.Destroy(GetComponent(MeshCollider));
	
	var vertices = new Vector3[baseHeight.Length];
	for (var i=0;i<vertices.Length;i++)
	{
		var vertex = baseHeight[i];
		
		if (useOriginal) {
			vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
		} else {
			// Debug.Log(baseHeight[i].x);
			// Debug.Log(baseHeight[i].y);
			vertex.y += Mathf.Cos(scale * 0.5 * Mathf.Sqrt(baseHeight[i].x * baseHeight[i].x + baseHeight[i].z * baseHeight[i].z) - 6 * Time.time) / (scale * 0.5 * (baseHeight[i].x * baseHeight[i].x + baseHeight[i].z * baseHeight[i].z) + 1 + 2*Time.time);
			//vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y) * (scale*.5) + Mathf.Sin(Time.time * speed+ baseHeight[i].z + baseHeight[i].y) * (scale*.5);
		}
		
		vertices[i] = vertex;
	}
	mesh.vertices = vertices;
	mesh.RecalculateNormals();
	
	gameObject.Destroy(GetComponent(MeshCollider));
	
	var collider : MeshCollider = GetComponent(MeshCollider);
	if (collider == null) {
		collider = gameObject.AddComponent(MeshCollider);
		collider.isTrigger = true;
	}
	
}

