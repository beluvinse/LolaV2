using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenGameObjects : IScreen
{
    Dictionary<Behaviour, bool> _beforeActivation;

    Transform _root;

    public ScreenGameObjects(Transform root)
    {
        _root = root;

        _beforeActivation = new Dictionary<Behaviour, bool>();
    }

    public void Activate()
    {
        foreach (var keyValue in _beforeActivation)
        {
            keyValue.Key.enabled = keyValue.Value;
        }

        _beforeActivation.Clear();
    }

    public void Deactivate()
    {
        foreach (var behavior in _root.GetComponentsInChildren<Behaviour>())
        {
            _beforeActivation[behavior] = behavior.enabled;
            behavior.enabled = false;
        }
    }

    public void Free()
    {
        GameObject.Destroy(_root.gameObject);
    }
}
