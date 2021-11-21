using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text TextTimer;
    public float waktu = 100;

    public bool Gameaktif = true;
    public GameObject gameover;

    float s;

    private void SetText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        TextTimer.text = menit.ToString("00") + ":" + detik.ToString("00");
    }

    private void Update()
    {
        if (Gameaktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                waktu--;
                s = 0;
            }
        }

        if(Gameaktif && waktu <= 0)
        {
            Debug.Log("Game Over");
            gameover.SetActive(true);
            Gameaktif = false;
        }

        SetText();
    }
}
