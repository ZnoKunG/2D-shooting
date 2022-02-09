using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiManager : MonoBehaviour
{
    [HideInInspector] public int ultiGage;
    public int ulti;
    [SerializeField] private float increasedFireRate;
    [SerializeField] private int UltiPeriod;
    [HideInInspector] public bool ultiActive;

    public Weapon gun;
    public GameObject ultiEffect;

    private void Update()
    {
        if (ultiGage == ulti)
            ActivateUlti();
    }

    private IEnumerator UltiPower()
    {
        ultiActive = true;
        ultiEffect.SetActive(true);
        float FireRateBeforeUlt = gun.startTimebtwShots;
        float ShotPowerBeforeUlt = gun.shotPower;
        gun.startTimebtwShots = 0;
        gun.shotPower *= increasedFireRate;
        yield return new WaitForSeconds(UltiPeriod);
        gun.shotPower = ShotPowerBeforeUlt;
        gun.startTimebtwShots = FireRateBeforeUlt;
        ultiEffect.SetActive(false);
        ultiActive = false;
    }

    private void ActivateUlti()
    {
        Debug.Log("Ultimate!!");
        StartCoroutine(UltiPower());
        ultiGage = 0;
    }
}
