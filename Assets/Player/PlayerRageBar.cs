using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRageBar : MonoBehaviour{
    public float ragePercent;
    public float decreaseSpeed;
    public float maxTolerance;
    public float minFireVFX;

    public GameObject player;
    public GameObject fireVFX;

    public Color rageBarColorOne;
    public Color rageBarColorTwo;
    public Color rageBarColorThree;

    private RectTransform rageBar;
    private float maxRagePercent;


    // Start is called before the first frame update
    void Start(){
        rageBar = GetComponent<RectTransform>();
        maxRagePercent = ragePercent;
    }

    // Update is called once per frame
    void Update(){
        float halfMaxRagePercent = maxRagePercent / 2;

        if (ragePercent >= 0) ragePercent -= Time.deltaTime * decreaseSpeed;
        else player.GetComponent<Movement>().RageZero();

        if (ragePercent > halfMaxRagePercent)
            GetComponent<Image>().color = Color.Lerp(rageBarColorTwo, rageBarColorThree, (ragePercent - halfMaxRagePercent) / halfMaxRagePercent);
        else
            GetComponent<Image>().color = Color.Lerp(rageBarColorOne, rageBarColorTwo, ragePercent / halfMaxRagePercent);

        if (ragePercent > maxTolerance) SceneManager.LoadScene(3);
        if (ragePercent > minFireVFX) fireVFX.SetActive(true);
        else fireVFX.SetActive(false);

        rageBar.localScale = new Vector3(ragePercent / 100, rageBar.localScale.y, 1f);
        rageBar.anchoredPosition = new Vector2(((ragePercent / 100) - 1) * rageBar.rect.width / 2, rageBar.anchoredPosition.y);
    }
}
