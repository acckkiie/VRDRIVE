﻿using UnityEngine;
using System.Collections;

public abstract class Incident : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		int result = GameController.instance.UpdateGameState(gameObject.transform.root.gameObject, collider.gameObject.transform.root.gameObject);
		if(result > -1) {
			CollidedActionForMyself();
		}
		if(result > 0) {
			ColliderActionForUser(collider);
		}
	}

	void OnCollisionEnter(Collision collision) {
		int result = GameController.instance.UpdateGameState(gameObject.transform.root.gameObject, collision.gameObject.transform.root.gameObject);
		if(result > -1) {
			CollidedActionForMyself();
		}
		if(result > 0) {
			CollisionActionForUser(collision);
		}
	}

	protected IEnumerator AfterTriggerEnter(float delayLength, string carName, int carStatus, Collider collider) {  
		yield return new WaitForSeconds(delayLength);
		AfterTriggerEnterAction(collider);
		GameController.instance.UpdateUserStatus(carName, carStatus);
	}

	protected IEnumerator AfterCollisionEnter(float delayLength, string carName, int carStatus, Collision collision) {  
		yield return new WaitForSeconds(delayLength);
		AfterCollisionEnterAction(collision);
		GameController.instance.UpdateUserStatus(carName, carStatus);
	}

	/// <summary>When collider/collision occurs, do Object's action.</summary>
	protected abstract void CollidedActionForMyself();

	/// <summary>When collider occurs, do User's action.</summary>
	/// <param name="collider">User's collider</param>
	protected abstract void ColliderActionForUser(Collider collider);

	/// <summary>After collider occurs, do  action.</summary>
	protected abstract void AfterTriggerEnterAction(Collider collider);

	/// <summary>When collision occurs, do User's action.</summary>
	/// <param name="collision">User's collision</param>
	protected abstract void CollisionActionForUser(Collision collision);

	/// <summary>After collision occurs, do action.</summary>
	protected abstract void AfterCollisionEnterAction(Collision collision);

}