using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject panelTutorial;
    public TextMeshProUGUI uno;
    public TextMeshProUGUI dos;
    public TextMeshProUGUI tres;
    public TextMeshProUGUI cuatro;
    public TextMeshProUGUI cinco;
    public TextMeshProUGUI seis;
    public TextMeshProUGUI siete;
    private int tuto;
    private int[] move;

    void Start()
    {
        move = new int[] { 0, 0, 0, 0 };
        tuto = 1;
        panelTutorial.SetActive(false);
        cleanText();
    }

    private void Update()
    {
        panelTutorial.SetActive(true);
        switch (tuto)
        {
            case 1:
                uno.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.W))
                {
                    move[0] = 1;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    move[1] = 1;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    move[2] = 1;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    move[3] = 1;
                }

                if (move[0] == 1 && move[1] == 1 && move[2] == 1 && move[3] == 1)
                    tuto = 2;
                break;
            case 2:
                cleanText();
                dos.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    tuto = 3;
                }
                break;
            case 3:
                cleanText();
                tres.gameObject.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    tuto = 4;
                }
                break;
            case 4:
                cleanText();
                cuatro.gameObject.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    tuto = 5;
                }
                break;
            case 5:
                cleanText();
                cinco.gameObject.SetActive(true);
                StartCoroutine("cincoWait");
                break;
            case 6:
                cleanText();
                seis.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    tuto = 7;
                }
                break;
            case 7:
                cleanText();
                siete.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    panelTutorial.SetActive(false);
                    Destroy(this.gameObject);
                }
                break;
        }
    }

    IEnumerator cincoWait()
    {
        yield return new WaitForSeconds(5f);
        tuto = 6;
    }
    private void cleanText()
    {
        uno.gameObject.SetActive(false);
        dos.gameObject.SetActive(false);
        tres.gameObject.SetActive(false);
        cuatro.gameObject.SetActive(false);
        cinco.gameObject.SetActive(false);
        seis.gameObject.SetActive(false);
        siete.gameObject.SetActive(false);
    }
}
