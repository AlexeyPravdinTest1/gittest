using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PirateGun : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator a;
    private Slider hp;
    private int lvl;
    public AudioClip gunSound;
    public AudioSource sndSrc;
    public float rage = 1.0f;
    public float speed = 1.0f;
    public int currentAmmo;
    public string name = "AK47";
    public bool reloading = false;

    [System.Serializable]
    public class GunData {
        public int ammo = 30;
        public float damage = 0.7f;
        public float delay = 0.3f;
        public float delay_delta_min = 0.15f;
        public float delay_delta_max = 0.25f;
        public float damage_delta_min = 0.45f;
        public float damage_delta_max = 0.95f;
        public float range = 130.0f;
        public float reload_time = 2.0f;
    }

    public GunData gunData = new GunData();

    float chance = 1 - 1 / (1 + 0.1 * Math.Sqrt(PirateSpawner.hard));
    if (Random.Range(0.0f, 1.0f) < chance) {
        float pow = Mathf.Sqrt(3.0f * PirateSpawner.hard);
        if (pow<power) Destroy(this);
    }

    float nd = gunData.damage + (gunData.damage_delta_min + gunData.damage_delta_max) / 2;
    float nt = (gunData.ammo * (gunData.delay + (gunData.delay_delta_min + gunData.delay_delta_max) / 2) + gunData.reload_time) / (gunData.ammo + 1);
    float power = nd / nt;
    void Start()
    {
        string path = Application.streamingAssetsPath + "/Guns/" + name + ".json";
        string contents = File.ReadAllText(path);
        gunData = JsonUtility.FromJson<GunData>(contents);

        Sprite sp = Resources.Load<Sprite>("Guns/" + name);
        this.GetComponent<SpriteRenderer>().sprite = sp;
        currentAmmo = gunData.ammo;
        reloading = false;

        hp = GameObject.Find("HealthBar").GetComponent<Slider>();
        a=this.GetComponent<Animator>();
        testAngle();
        sndSrc.volume = 0.3f;
        sndSrc.clip = gunSound;
        shoot();
    }

    void testAngle()
    {
        float g = Quaternion.Angle(transform.rotation, Quaternion.Euler(0f, 0f, 0f));
        if (g>=0f && g<19.5f && transform.position.x < gunData.range) a.SetBool("Dir", true);
        else a.SetBool("Dir", false);
        Invoke("testAngle", 1f);
    }

    void reload() {
        currentAmmo = gunData.ammo;
        reloading = false;
    }

    void shoot()
    {
        if (a.GetBool("Open") && a.GetBool("Dir") && !reloading) 
        {
            if (currentAmmo > 0) {
                hp.value -= (gunData.damage + Random.Range(gunData.damage_delta_min, gunData.damage_delta_max)) * lvl * Mathf.Pow(1.05f, PirateSpawner.hard) * rage; 
                sndSrc.Play();
                currentAmmo--;
            }
            else {
                reloading = true;
                Invoke("reload", pigData.reload_time);
            }
        }
        Invoke("shoot", (gunData.delay + Random.Range(gunData.delay_delta_min, gunData.delay_delta_max)) / speed);
    }
}

