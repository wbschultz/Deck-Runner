using System.Collections;
using UnityEngine;

// parent class for pooled objects
public class PoolObject : MonoBehaviour {

	// override this to do specific stuff on reuse
	public virtual void OnObjectReuse() {

	}

	// set false
	protected void Destroy() {
		gameObject.SetActive (false);
	}
}
