using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1Events : MonoBehaviour
{
    public Transform[] evento1;
    public Transform[] evento2;
    public Transform[] evento3;
    public Transform[] evento4;
    public Transform[] evento5;
    public Transform[] evento6;
    public Transform[] evento7;
    public PlayerDataSO playerData;
    public GameEvent evento6Musica;
    public GameObject[] encierro1;
    public GameObject boss;
    private int evento6Count;
    public GameObject enemigo;

    private void Start()
    {
        evento6Count = 0;
    }
    public void Evento1()
    {
        instanciarEnemigos(evento1);
    }

    public void Evento2()
    {
        instanciarEnemigos(evento2);
    }

    public void Evento3()
    {
        instanciarEnemigos(evento3);
    }

    public void Evento4()
    {
        playerData.checkPointActual = 2;
        instanciarEnemigos(evento4);
        StartCoroutine("evento4Spawn");
    }

    public void Evento5()
    {
        playerData.checkPointActual = 2;
        instanciarEnemigos(evento5);
        StartCoroutine("evento5Spawn");
    }

    public void Evento6()
    {
        playerData.checkPointActual = 3;
        instanciarEnemigos(evento6);
        encierro1[0].gameObject.SetActive(true);
        encierro1[1].gameObject.SetActive(true);
        StartCoroutine("evento6Spawn");
    }

    public void Evento7()
    {
        boss.gameObject.SetActive(true);
        playerData.checkPointActual = 4;
        instanciarEnemigos(evento7);
        encierro1[1].gameObject.SetActive(true);
        StartCoroutine("evento7Spawn");
    }
    public void instanciarEnemigos(Transform[] Puntos)
    {
        for(int i = 0; i < Puntos.Length; i++)
        {
            Instantiate(enemigo, Puntos[i].position, Quaternion.identity);
        }
    }
    public void deternerCorrutinas()
    {
        StopAllCoroutines();
    }
    IEnumerator evento4Spawn()
    {
        yield return new WaitForSeconds(10f);
        instanciarEnemigos(evento4);
        StartCoroutine("evento4Spawn");
    }
    IEnumerator evento5Spawn()
    {
        yield return new WaitForSeconds(10f);
        instanciarEnemigos(evento5);
        StartCoroutine("evento5Spawn");
    }

    IEnumerator evento6Spawn()
    {
        yield return new WaitForSeconds(15f);
        evento6Count++;
        instanciarEnemigos(evento6);
        if(evento6Count < 6)
            StartCoroutine("evento6Spawn");
        else
            StartCoroutine("evento6Part2");
    }

    IEnumerator evento6Part2()
    {
        yield return new WaitForSeconds(20f);
        encierro1[0].gameObject.SetActive(false);
        encierro1[1].gameObject.SetActive(false);
        evento6Musica.Raise();
    }

    IEnumerator evento7Spawn()
    {
        yield return new WaitForSeconds(15f);
        instanciarEnemigos(evento7);
        StartCoroutine("evento7Spawn");
    }
}
