using UnityEngine;
using EmeraldAI;
public class Shooting : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public Camera fpsCum;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    [SerializeField]
    private Weapon weapon;
    public New_Weapon_Recoil_Script recoil;


    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && weapon.isHavingEnoughBulletsToShot())
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            weapon.DecreaseBulletsCountByShot();
            recoil.Fire();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCum.transform.position, fpsCum.transform.forward, out hit, range))
        {
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                rigidbody.AddForce(transform.forward * 50);
            }

            if (hit.collider.tag.Contains("target"))
            {
                hit.collider.GetComponent<Grenade>().MakeExplosion();
            }
            if (hit.collider.tag.Contains("AI"))
            {
                var hittedEnemy = hit.collider.gameObject.GetComponent<Enemy>();
                hittedEnemy.GetDamage(damage, EmeraldAISystem.TargetType.Player, transform);
            }
        }

    }
}
