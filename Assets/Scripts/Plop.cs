﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plop : MonoBehaviour {

	float xPos;
	float zPos;
	Vector3[] vertices;
	float[] distortions;
	public Mesh mesh;

    private WaveController controller;
	public float vscale = 1f;
	public float hscale = 1f;
	public float startTime = 0f;
	public float period = 1f;

    private Vector3[] baseHeight;

	// Use this for initialization
	void Start () {

        Debug.Log("START");
        controller = GameObject.FindObjectOfType<WaveController>();
        controller.bobbers.Add(gameObject);
       
		this.vertices = mesh.vertices;
		this.hscale = 1/this.hscale;
		Vector3 pos = transform.position;

		this.xPos = pos.x;
		this.zPos = pos.z;
	}

	public float[] getDistortions() {
		distortions = new float[vertices.Length];
		startTime += Time.deltaTime;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = vertices[i];
            distortions[i] = vscale * Mathf.Cos((1/period) * 0.5f * Mathf.Sqrt(Mathf.Pow(hscale * (vertex.x - xPos),2f) + Mathf.Pow(hscale * (vertex.z - zPos), 2f)) - 6f * startTime)
                                 / (0.5f * (Mathf.Pow(hscale * (vertex.x - xPos),2f)  + Mathf.Pow(hscale * (vertex.z - zPos), 2)) + 1f + 2f * startTime);
        }
        return distortions;
	}

	public float getDistortionForPoint(float x, float z) {
		return vscale * Mathf.Cos(0.5f * Mathf.Sqrt(Mathf.Pow(hscale * (x - xPos),2f) + Mathf.Pow(hscale * (z - zPos), 2f)) - 6f * startTime)
                                 / (0.5f * (Mathf.Pow(hscale * (x - xPos),2f)  + Mathf.Pow(hscale * (z - zPos), 2)) + 1f + 2f * startTime);
	}
}
