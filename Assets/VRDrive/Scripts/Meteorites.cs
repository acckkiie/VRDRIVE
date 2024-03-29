﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Meteorites.
/// </summary>
public class Meteorites : MonoBehaviour {

	[SerializeField] private GameObject meteorite;
	[SerializeField] private float interval = 4;

	private float[] createMeteoriteZPositions = new float[5] { -18f, -9f, 0f, 9f, 18f };

	/// <summary>
	/// Starts the rock falling.
	/// </summary>
	public void StartRockFalling() {
		if(meteorite != null) {
			StartCoroutine(CreateMeteorite());
		}
		else {
			Debug.LogWarning("The system cannnot find the meteorite's prefab.");
		}
	}

	/// <summary>
	/// Creates the meteorite.
	/// </summary>
	/// <returns>The meteorite.</returns>
	private IEnumerator CreateMeteorite() {
		while(true) {
			yield return new WaitForSeconds(interval);
			GameObject newMeteorite = Instantiate(meteorite, new Vector3(createMeteoriteZPositions[Random.Range(0, 5)], gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation) as GameObject;
			newMeteorite.transform.parent = gameObject.transform;
		}
	}

}
