using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameEvent OnStartEvent;
    public GameObject bullet;
    public Transform originBullet;
    public float bulletForce;
    private Animator playerAnimator;
    private GameObject tmpBullet;
    public PlayerDataSO playerData;

    // Update is called once per frame
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (playerData.playing)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shootin();
                playerAnimator.SetTrigger("DisparoPistola");
            }
        }
        
    }
    public void shootin()
    {
        tmpBullet = Instantiate(bullet,
                                    originBullet.position,
                                    Quaternion.identity);
        tmpBullet.transform.up = originBullet.forward;

        tmpBullet.GetComponent<Rigidbody>().AddForce(
            originBullet.forward * bulletForce,
            ForceMode.VelocityChange
            );
        OnStartEvent.Raise();
        //tmpBullet.transform.position = originBullet.position;
    }
}
