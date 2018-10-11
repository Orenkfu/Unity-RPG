using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class ErrorText : MonoBehaviour {
    TextMeshProUGUI tmp;
	// Use this for initialization
	void Start () {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "";
    }
	public void ShowError(string error) {
        Debug.Log("trying to show error..");
        tmp.text = error;
        StartCoroutine(FadeTextToZeroAlpha(5f));
    }

    public IEnumerator FadeTextToFullAlpha(float t) {
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 0);
        while (tmp.color.a < 1.0f) {
            tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, tmp.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t) {
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 1);
        while (tmp.color.a > 0.0f) {
            tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, tmp.color.a - (Time.deltaTime / t));
            yield return null;
        }
        tmp.text = "";
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 1f);
    }
}
    

