using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBeam : MonoBehaviour {

	public void OnBecameInvisible() {
    Destroy(gameObject);
}
}
