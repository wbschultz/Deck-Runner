using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // holds all pools of objects, keyed off of InstanceID
    private Dictionary<int, Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>>();

    // singleton pattern
    static ObjectPooler _instance;

    public static ObjectPooler instance {
        get {
            if (_instance == null){
                _instance = FindObjectOfType<ObjectPooler>();
            }
            return _instance;
        }
    }

    ///<summary>
    ///Create a new pool of objects
    ///</summary>
    ///<param name="prefab">Object prefab for which to create pool</param>
    ///<param name="poolSize">Maximum number of objects in pool</param>
    //TODO dynamically sized pools?
    public void CreatePool(GameObject prefab, int poolSize){
        // get key by instance ID
        int poolKey = prefab.GetInstanceID();
        
        // if no pool exists yet, create one
        if (!poolDictionary.ContainsKey(poolKey)){
            poolDictionary.Add(poolKey, new Queue<ObjectInstance>());

            GameObject poolHolder = new GameObject(prefab.name + "Pool");
            poolHolder.transform.parent = transform;

            for (int i = 0; i < poolSize; i++){
                ObjectInstance newObject = new ObjectInstance(Instantiate(prefab) as GameObject);
                poolDictionary[poolKey].Enqueue(newObject);
                newObject.SetParent(poolHolder.transform);
            }
        }
    }

    ///<summary>
    ///Reuse an object in a pool
    ///</summary>
    ///<param name="prefab">Object to reuse</param>
    ///<param name="position">Reset to this position</param>
    ///<param name="rotation">Reset to this rotation</param>
    public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation) {
		int poolKey = prefab.GetInstanceID ();

		if (poolDictionary.ContainsKey (poolKey)) {
			ObjectInstance objectToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (objectToReuse);

			objectToReuse.Reuse (position, rotation);
		} else {
            Debug.LogError("Could not find pool for that object");
        }
	}


    ///<summary>
    ///Interface for object pooler to wrap pooled objects in
    ///</summary>
    public class ObjectInstance {

        GameObject gameObject;
        Transform transform;

        bool hasPoolObjectComponent;
        PoolObject poolObjectScript;

        public ObjectInstance(GameObject objectInstance){
            gameObject = objectInstance;
            transform = objectInstance.transform;

            if (gameObject.GetComponent<PoolObject>()) {
				hasPoolObjectComponent = true;
				poolObjectScript = gameObject.GetComponent<PoolObject>();
			}
        }

        public void Reuse(Vector3 position, Quaternion rotation){
            gameObject.SetActive(true);
            transform.position = position; 
            transform.rotation = rotation;

            if (hasPoolObjectComponent){
                poolObjectScript.OnObjectReuse();
            }
        }

        public void SetParent(Transform parent){
            transform.parent = parent;
        }
    }
}
