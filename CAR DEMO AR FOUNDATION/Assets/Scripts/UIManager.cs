using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;
    public GameObject mainUI;
    public GameObject[] handUI;


    Vector3 carRot;
    float yRot;

    GameObject carInstance;
    Color blue = Color.blue;
    Color yellow = Color.yellow;
    Color red = Color.red;
    public GameObject colorPanel; 
    private void OnEnable()
    {
        EventBroker.CarSelectedByUser += CarRotation;
        EventBroker.ShowMainUI += ShowMainUI;
        EventBroker.ShowMainUI += HideHandUI;
        EventBroker.ShowHandUI += ShowHandUI;
    }

    private void Start()
    {
        mainUI.gameObject.SetActive(false);
        HideHandUI();
    }

    public void OnSlide(float val)
    {
        if (CarPlacement.selectedCar)
        {
            yRot = carRot.y;
            yRot += val;
            CarPlacement.selectedCar.transform.eulerAngles = new Vector3(carRot.x, yRot, carRot.z);
        }
    }

    void CarRotation(GameObject obj)
    {
        CarPlacement.selectedCar = obj;
        carRot = CarPlacement.selectedCar.transform.localEulerAngles;
        slider.value = 0f;
    }


    public void PlaceOnPlane()
    {
        if (CarPlacement.selectedCar != null)
        {
            CarPlacement.selectedCar = null;
        }

        Debug.Log(CarPlacement.selectedCar.name);
    }

    void ShowMainUI()
    {
        mainUI.gameObject.SetActive(true);
    }

    void ShowHandUI()
    {
        foreach (var obj in handUI)
        {
            obj.gameObject.SetActive(true);
        }
    }

    void HideHandUI()
    {
        foreach (var obj in handUI)
        {
            obj.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        EventBroker.CarSelectedByUser += CarRotation;
        EventBroker.ShowMainUI -= ShowMainUI;
        EventBroker.ShowMainUI -= HideHandUI;
        EventBroker.ShowHandUI -= ShowHandUI;
    }

    public void OnColor(Color color)
    {
        if(CarPlacement.selectedCar != null)
        {
            MeshRenderer[] meshRenderers = CarPlacement.selectedCar.GetComponentsInChildren<MeshRenderer>();

            foreach(MeshRenderer mr in meshRenderers)
            {
                mr.material.color = color;
            }

        }
    }

    public void OnBlue()
    {
        OnColor(blue);
    }

    public void OnRed()
    {
        OnColor(red);
    }

    public void OnYellow()
    {
        OnColor(yellow);
    }
    public void ShowHideColorPanel()
    {
        colorPanel.gameObject.SetActive(!colorPanel.gameObject.activeSelf);
    }
}

