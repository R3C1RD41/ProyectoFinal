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
    private bool wall;

    public Transform iniPocition;
    public Transform endPocition;
    public float radio;
    public GameEvent noColocaBarrera;
    public GameEvent colocaBarrera;

    // Update is called once per frame
    private void Start()
    {
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
}
