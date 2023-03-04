using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public int numVidas;
    public int numEnemigos;
    public float valueLife;
    public bool playing = false;
    public UnityEvent OnDataChange;

    public void ChangeVidas(int change)
    {
        numVidas += change;
        OnDataChange.Invoke();
    }

    public void ChangeEnemigos(int change)
    {
        numEnemigos += change;
        OnDataChange.Invoke();
    }

    public void ChangeValueLife(float change)
    {
        valueLife += change;
        if (valueLife < 0)
        {
            numVidas--;
            valueLife = 1;
        }
        OnDataChange.Invoke();
    }

    public void NoPlayin()
    {
        playing = false;
    }

    public void Playin()
    {
        playing = true;
    }
}
