using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class HintModel : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Image image;
    [SerializeField] SceneModel scene;
    public bool isHint;
    float fadeSec = 1f, hintSec = 10f, alpha;

    void Awake() =>
        isHint = System.Convert.ToBoolean(PlayerPrefs.GetString("hint", "true"));

    public void BreakAndChangeHint()
    {
        StopAllCoroutines();
        if (!isHint && alpha > 0) StartCoroutine(SmoothChange(1, 0));
        else if (isHint) ShowHint();
        scene.isHintChange = false;
    }

    public void ShowHint()
    {
        if (isHint) StartCoroutine(Hint());
    }

    IEnumerator Hint()
    {
        StartCoroutine(SmoothChange(0, 1));
        yield return new WaitForSeconds(hintSec);
        StartCoroutine(SmoothChange(1, 0));
        isHint = false;
        SaveSettings();
    }

    IEnumerator SmoothChange(float startValue, float endValue)
    {
        float time = 0;
        while (time < fadeSec)
        {
            time += Time.deltaTime;
            alpha = Mathf.Lerp(startValue, endValue, 1f / fadeSec * time);
            text.color = ChangeAlpha();
            image.color = ChangeAlpha();
            yield return null;
        }
    }

    Color ChangeAlpha() => new Color(255, 255, 255, alpha);

    public void SaveSettings()
    {
        PlayerPrefs.SetString("hint", isHint.ToString());
        PlayerPrefs.Save();
    }

    public void ChangeHintsAvailable() 
    {
        isHint = !isHint;
        scene.isHintChange = true;
    }
}

