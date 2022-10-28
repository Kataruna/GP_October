using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //ประกาศตัวแปรเก็บ Rigidbody ของตัวลูกธนูเอง
    //Rigidbody คือ Component ตัวหนึ่งที่ใช้ในการบอก Unity ให้คำนวน Physics กับวัตถุชิ้นนั้น ๆ 
    private Rigidbody _rb;

    //เมื่อเริ่มเกมมาในตอนแรกสุด (Awake ทำงาน ก่อน Start)
    private void Awake()
    {
        //กำหนดให้ตัวแปรที่มีชื่อว่า _rb คือ Rigidbody ของวัตถุที่ใส่ Script นี้ไว้
        _rb = GetComponent<Rigidbody>();
    }

    //ทำงานเรื่อย ๆ
    void Update()
    {
        //กำหนดให้การหมุนของวัตถุชิ้นนี้ = หมุนไปที่องศาตาม ความเร่ง ของ _rb
        transform.rotation = Quaternion.LookRotation(_rb.velocity);
    }
}
