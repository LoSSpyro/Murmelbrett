using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour {


	string sliderTextString;

	public Text sliderText; // public is needed to ensure it's available to be assigned in the inspector.

	void Start () {
		sliderTextString = sliderText.text;
		sliderText.text = sliderTextString + "0";
	}

	public void textUpdate (float textUpdateNumber) {
		sliderText.text = sliderTextString + textUpdateNumber.ToString();
	}

}
