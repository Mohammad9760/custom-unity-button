using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Btn : MonoBehaviour , IPointerClickHandler, IPointerDownHandler
{
    public bool Clicked, DoubleClicked;

    private float doubleclickDelay = 0.5f, passedTimeSinceLastClick;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        passedTimeSinceLastClick += Time.deltaTime;
    }

    private IEnumerator reset()
    {
        yield return new WaitForEndOfFrame();
        Clicked = false;
        DoubleClicked = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked = true;
        StartCoroutine(reset());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (passedTimeSinceLastClick < doubleclickDelay)
        {
            DoubleClicked = true;
            StartCoroutine(reset());
        }
        else
            passedTimeSinceLastClick = 0;
    }
}
