using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilidades : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barrera;
    private GameObject[] tmpbarrera;
    public Transform BarreraLocation;
    public Transform orientacion;
    public PlayerDataSO playerData;
    public LayerMask wallLayer;
    private int cont = 0;
    private bool timeStop;
    private bool timeStopKey;
    private bool wall;

    public Transform iniPocition;
    public Transform endPocition;
    public float radio;
    public GameEvent noColocaBarrera;
    public GameEvent colocaBarrera;
    public GameEvent stopTime;

    // Update is called once per frame
    private void Start()
    {
        timeStop = false;
        timeStopKey = true;
        wall = true;
        tmpbarrera = new GameObject[3];
    }
    void Update()
    {
        if (playerData.playing)
        {
            if (Input.GetKeyDown(KeyCode.Q) && wall)
            {
                //Debug.Log("Condicion" + obstaculo());
                if (!obstaculo())
                {
                    colocaBarrera.Raise();
                    if (tmpbarrera[cont] != null)
                    {
                        Destroy(tmpbarrera[cont]);
                    }
                    tmpbarrera[cont] = Instantiate(barrera, BarreraLocation.position, Quaternion.identity);
                    //tmpbarrera.transform.up = BarreraLocation.right;
                    //tmpbarrera.transform.rotation = Quaternion.Euler(90, 0, 0);
                    tmpbarrera[cont].transform.right = BarreraLocation.right;
                    cont++;

                    if (cont == 3)
                    {
                        cont = 0;
                    }
                    wall = false;
                    StartCoroutine("wallWait");
                }
                else
                {
                    noColocaBarrera.Raise();
                }

            }
            if (Input.GetKey(KeyCode.LeftShift) && playerData.stopTimeHability > 0)
            {
                Time.timeScale = 0.5f;
                if (!timeStop)
                {
                    StopCoroutine("stopTimeUp");
                    StartCoroutine("stopTimeDown");
                    timeStop = true;
                }
            }
            if(playerData.stopTimeHability == 0)
            {
                Time.timeScale = 1;
            }
            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                timeStop = false;
                StopCoroutine("stopTimeDown");
                Time.timeScale = 1;
                StartCoroutine("stopTimeUp");
            }     
        }
    }


    public bool obstaculo()
    {
        return Physics.CheckCapsule(iniPocition.position,endPocition.position,radio,wallLayer);
    }

    IEnumerator wallWait()
    {
        yield return new WaitForSeconds(30f);
        wall = true;
    }

    IEnumerator stopTimeDown()
    {
        yield return new WaitForSecondsRealtime(1f);
        playerData.stopTimeHability -= 1;
        if(playerData.stopTimeHability > 0)
        {
            StartCoroutine("stopTimeDown");
        }
    }

    IEnumerator stopTimeUp()
    {
        yield return new WaitForSeconds(1f);
        playerData.stopTimeHability += 1;
        if(playerData.stopTimeHability < 30)
        {
            StartCoroutine("stopTimeUp");
        }
    }
}
