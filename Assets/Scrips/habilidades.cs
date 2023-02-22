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
    private int cont=0;

    // Update is called once per frame
    private void Start()
    {
        tmpbarrera = new GameObject [3];
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(tmpbarrera[cont] != null) 
            {
                Destroy(tmpbarrera[cont]);
            }
            tmpbarrera[cont] = Instantiate(barrera,BarreraLocation.position, Quaternion.identity);
            //tmpbarrera.transform.up = BarreraLocation.right;
            //tmpbarrera.transform.rotation = Quaternion.Euler(90, 0, 0);
            tmpbarrera[cont].transform.right = BarreraLocation.right;
            cont++;
        }
        if (cont == 3)
        {
            cont = 0;
        } 
    }
}
