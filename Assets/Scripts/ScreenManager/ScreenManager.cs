using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    Stack<IScreen> _stack;

    static public ScreenManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;

        _stack = new Stack<IScreen>();
    }

    public void Push(IScreen screen)
    {
        if (_stack.Count > 0)
        {
            _stack.Peek().Deactivate();
        }

        _stack.Push(screen);

        screen.Activate();
    }

    public void Push(string resource)
    {
        var gameObject = Instantiate(Resources.Load<GameObject>(resource));

        if (gameObject.TryGetComponent(out IScreen newScreen))
        {
            Push(newScreen);
        }
    }

    public void Pop()
    {
        if (_stack.Count <= 1) return;

        _stack.Pop().Free();

        if (_stack.Count > 0)
        {
            _stack.Peek().Activate();
        }
    }


}
