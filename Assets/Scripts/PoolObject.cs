using System.Collections;
using UnityEngine;

// parent class for pooled objects
public class PoolObject : MonoBehaviour {

	///<summary>
	/// override this to do specific stuff on reuse
	///</summary>
	public virtual void OnObjectReuse() {

	}

	///<summary>
	/// set gameObject inactive
	///</summary>
	protected void Destroy() {
		gameObject.SetActive (false);
	}
}
