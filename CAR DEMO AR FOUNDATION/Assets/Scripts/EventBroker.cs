using System;
using UnityEngine;

public class EventBroker 
{
    public static Action<GameObject> CarSelectedByUser;
    public static Action ShowMainUI;
    public static Action ShowHandUI;
    public static Action HideHandUI;

    public static void OnCarSelected()
    {
        CarSelectedByUser?.Invoke(CarPlacement.selectedCar);
    }

    public static void FireShowMainUIEvent()
    {
        ShowMainUI?.Invoke();
    }

    public static void FireShowHandUIEvent()
    {
        ShowHandUI?.Invoke();
    }

    public static void FireHideHandUIEvent()
    {
        HideHandUI?.Invoke();
    }

}
