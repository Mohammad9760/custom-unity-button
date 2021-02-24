using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Btn : MonoBehaviour ,IPointerDownHandler , IPointerUpHandler, IPointerClickHandler
{
    [HideInInspector]
	public bool Held = false ,Clicked = false , doubleClicked = false;
    [SerializeField]
    private float delay = 0.7f;


    [SerializeField]
    Color color , pressedColor = new Color(200,200,200,255);
    private Image image;
    private Text btnText;
    private void Start()
    {
        image = GetComponent<Image>();
        btnText = transform.Find("Text").GetComponent<Text>();
        color = image.color;
        pressedColor = color * pressedColor;
    }

	private void Update () 
	{
		delay -= (Time.deltaTime);

        if (Held)
            image.color = pressedColor;
        else image.color = color;

	}

    /// <summary>
    /// use this to change the button's text with no need to refrencing the text gameobject
    /// </summary>
    public void ChangeText(string newText) { btnText.text = newText; }

	public void OnPointerDown(PointerEventData eventData)
	{
		Held = true;
		if (delay > 0){
			doubleClicked = true;
            StartCoroutine(reset());
        }
		else
			delay = 0.7f;
	}

	public void OnPointerUp(PointerEventData eventData) {	Held = false;	}

    public void OnPointerClick(PointerEventData eventData) {   Clicked = true; StartCoroutine(reset());}

    private IEnumerator reset()
    {
        if (Clicked)
        {
            yield return new WaitForEndOfFrame();
            Clicked = false;
        }
        if (doubleClicked)
        {
            yield return new WaitForEndOfFrame();
            doubleClicked = false;
        }
    }
}
