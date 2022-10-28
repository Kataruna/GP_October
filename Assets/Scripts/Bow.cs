using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    //- จับ ง้าง ปล่อย
    //1. กดค้างเพื่อง้าง
    //2. ปล่อยปุ่มยิง

    public Rigidbody arrowModel;
    public Transform muzzle;
    
    //กำหนด แรงสูงสุด, กำลังที่ใช้ง้าง, ง้างเร็วแค่ไหน
    public float maxPower;
    public float chargePower;
    public float chargeSpeed;

    public bool isCharge;
    
    void Update()
    {
        //กดคลิก
        if (Input.GetMouseButtonDown(0))
        {
            isCharge = true;
        }

        //ยังคลิกอยู่
        if (isCharge && chargePower <= maxPower)
        {
            chargePower += chargeSpeed * Time.deltaTime;
            //chargePower = chargePower + (chargeSpeed * Time.deltaTime);
        }
        
        //ปล่อย
        if (isCharge && Input.GetMouseButtonUp(0))
        {
            Rigidbody shotArrow = Instantiate(arrowModel, muzzle.position, muzzle.rotation);
            
            shotArrow.AddForce(muzzle.forward * chargePower, ForceMode.Impulse);

            chargePower = 0f;
            isCharge = false;
        }
    }
}
