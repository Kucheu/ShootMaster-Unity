
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 100f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public Transform endOfGun;
    public Animator gunAnimationController;

    public GameManager gameManager;

    public GameObject muzzleFlashPrefab;
    private float destroyTimer = 2f;

    public AudioSource shootSFX;

    public AudioSource hitSFX;

    private float nextTimeToFire;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            RaycastHit hit;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(endOfGun.position, hit.point, Color.red);

                Debug.Log(hit.transform.tag);
                if(hit.transform.tag == "StartRound")
                {
                    gameManager.StartRound();
                } else if(hit.transform.tag == "Target")
                {
                    gameManager.GetPoint();
                    Target target = (Target)hit.transform.GetComponent(typeof(Target));
                    target.GetHit();
                    hitSFX.Play();
                } else
                {
                    gameManager.MissShot();
                }
            }
            
            //Play shoot sound
            shootSFX.Play();

            //Play shoot animation
            gunAnimationController.SetTrigger("Fire");
        }
    }

   

    void Shoot()
    {
        
            if (muzzleFlashPrefab)
            {
                //Create the muzzle flash
                GameObject tempFlash;
                tempFlash = Instantiate(muzzleFlashPrefab, endOfGun.position, endOfGun.rotation);

                //Destroy the muzzle flash effect
                Destroy(tempFlash, destroyTimer);
            }
        

        

    }

    void CasingRelease()
    {
        //none
    }
}
