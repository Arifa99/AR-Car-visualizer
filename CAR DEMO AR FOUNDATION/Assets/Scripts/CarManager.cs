using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class CarManager : MonoBehaviour
{
    public static Action OnCarTouched;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject(0))
        {
            return;
        }

        CarPlacement.selectedCar = transform.parent.gameObject;
        EventBroker.OnCarSelected();
    }
}
