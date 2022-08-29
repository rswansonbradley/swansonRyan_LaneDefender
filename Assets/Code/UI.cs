using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static int currentPoint;
    public static int bestPoint;
    public TMP_Text deathText;
    public TMP_Text currentText;
    public TMP_Text bestText;
    public TMP_Text loseText;
    // Start is called before the first frame update
    void Start()
    {
        loseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            currentPoint = 0;
        }
        if (currentPoint > bestPoint)
        {
            bestPoint = currentPoint;
        }
        deathText.text = ("Health: " + GlobalHealth.gameHp);
        currentText.text = ("Current Score: " + currentPoint);
        bestText.text = ("Best Score: " + bestPoint);

        if (GlobalHealth.gameHp == 0)
        {
            loseText.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.R))
        {
            loseText.gameObject.SetActive(false);
        }
    }
}
