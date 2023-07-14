using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePooler : MonoBehaviour
{
    [SerializeField] protected GameObject _objectPrefab;
    [SerializeField] protected int _numOfObjects;
    protected List<GameObject> _preloadObjects;

    private void Start()
    {
        _preloadObjects = new List<GameObject>();

        for (int i = 0; i < _numOfObjects; ++i)
        {
            GameObject gameObject = Instantiate(_objectPrefab, Vector3.zero, _objectPrefab.transform.rotation);
            gameObject.SetActive(false);
            gameObject.transform.SetParent(transform);
            _preloadObjects.Add(gameObject);
        }
    }

    public GameObject GetPreloadObject()
    {
        GameObject gameObject = _preloadObjects.Find(obj => !obj.activeInHierarchy);
        return gameObject ? gameObject : null;
    }
}
