using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    [Header("Button Transforms")]
    public Transform buttonObject;
    public Transform buttonUpPosition;
    public Transform buttonDownPosition;

    [Header("Button Events")]
    public UnityEvent OnPressed;
    public UnityEvent OnReleased;

    void Start()
    {
        buttonObject.position = buttonUpPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hand"))
        {
            // Button should be pressed
            buttonObject.position = buttonDownPosition.position;

            OnPressed?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("hand"))
        {
            // Button should be released
            buttonObject.position = buttonUpPosition.position;

            OnReleased?.Invoke();
        }
    }
}
