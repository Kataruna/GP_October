using System.Collections;
using UnityEngine;

public class Affect : MonoBehaviour
{
    // ประกาศตัวแปรประเภท Stat ชื่อว่า stat โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    [SerializeField] private Stat stat;
    
    [Header("Health Relate Effect")] // เขียนหัวข้อให้กับตัวแปรต่อจากนี้ โดยใช้คำว่า "Health Relate Effect"
    
    // ประกาศตัวแปรประเภท float ชื่อว่า timeBetweenHeal โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    [SerializeField] private float timeBetweenHeal;

    // ประกาศตัวแปรประเภท Coroutine ชื่อว่า _healthFX
    private Coroutine _healthFX;

    private float _healthFXDuration; // ประกาศตัวแปรประเภท float ชื่อว่า _healthFXDuration
    private bool _healthFXInProgress; // ประกาศตัวแปรประเภท bool ชื่อว่า _healthFXInProgress
    
    /*
     * Coroutine คือการใช้งานคำสั่งแบบทำขนานไปกับโปรแกรมหลัก คล้าย ๆ กับโปรแกรมรอง
     *
     * ตัวแปร Coroutine จะใช้ในการเก็บคำสั่งที่ถูกสั่งให้ทำงานแบบขนานไปกับโปรแกรมหลัก
     * เพื่อให้เราสามารถอ้างถึง, สั่งการ, หยุดการทำงานได้เมื่อต้องการ
     */
    
    /*
     * หน้าที่ของตัวแปรในโค้ดนี้
     * stat: เก็บวัตถุที่มีโค้ด stat ที่จะใช้อ้างอิง (ตัวละครผู้เล่น)
     * timeBetweenHeal: ระยะเวลาระหว่างการเพิ่มเลือดแต่ละครั้ง
     * _healthFX: เก็บตัว Coroutine ที่ใช้อ้างถึงสถานะเพิ่มเลือด
     * _healthFXDuration: นับเวลาที่จะใช้เทียบว่า สถานะเพิ่ม/ลดเลือด ยังต้องทำงานอยู่หรือไม่
     * _healthFXInProgress: ใช้บอกว่าสถานะของสถานะ เพิ่ม/ลดเลือด ทำงานอยู่หรือไม่
     */

    // ทำเรื่อย ๆ
    private void Update()
    {
        // หากว่าค่าในตัวแปร _healthFXInProgress เป็นจริง ให้ เพิ่มค่าลงตัวแปร _healthFXDuration ไปเรื่อย ๆ ตามเวลาที่ผ่านไป
        if (_healthFXInProgress) _healthFXDuration += Time.deltaTime;
    }

    // ประกาศสร้างคำสั่งที่สามารถใช้ได้จากทุกที่ (public) โดยไม่คืนค่าใด ๆ กลับมา (void) โดยให้ชื่อคำสั่งว่า HealthBuff
    // โดยหากมีการเรียกใช้คำสั่งนี้ จะต้องมีการระบุค่าของ power เป็นตัวเลขจำนวนเต็ม (int) และค่าของ limiter เป็นจำนวนที่เป็นทศนิยมได้ (float) ในวงเล็บ
    public void HealthBuff(int power, float limiter)
    {
        // หากว่า _healthFX ไม่ได้ว่างอยู่ ให้หยุดการทำงานของโปรแกรมรองที่อ้างถึงใน _healthFX
        if(_healthFX != null) StopCoroutine(_healthFX);
        
        // เริ่มการทำงานโปรแกรมรองที่มีชื่อคำสั่งว่า Adrenaline
        // โดยระบุ เวลาที่สถานะนี้จะทำงาน (limiter) มีระยะระหว่างการเพิ่มเลือดแต่ละครั้ง (timeBetweenHeal) และเพิ่มเลือดทีละ power หน่วย
        // (อ่านรายละเอียดเพิ่มเติมในคำสั่ง Adrenaline)
        _healthFX = StartCoroutine(Adrenaline(limiter, timeBetweenHeal, power));
    }

    // ประกาศสร้าง IEnumerator ซึ่งจะเป็นคำสั่งที่สามารถเรียกใช้เป็นโปรแกรมรองได้ โดยใช้ชื่อคำสั่งว่า Adrenaline
    // โดยหากมีการเรียกใช้คำสั่งนี้ จะต้องมีการระบุค่าของ limiter เป็นจำนวนที่เป็นทศนิยมได้ (float)
    // ค่าของ timeBetweenFX เป็นจำนวนที่เป็นทศนิยมได้ (float)
    // และ ค่าของ power เป็นตัวเลขจำนวนเต็ม (int) ในวงเล็บ
    IEnumerator Adrenaline(float limiter, float timeBetweenFX, int power)
    {
        _healthFXDuration = 0f; // กำหนดให้ค่าในตัวแปร _healthFXDuration มีค่าคือ 0
        _healthFXInProgress = true; // กำหนดให้ค่าในตัวแปร _healthFXInProgress คือ จริง

        /*
         * Loop ประเภท while คือการสั่งให้วนซ้ำตราบเท่าที่เงื่อนไขใน while ยังเป็นจริง
         * โดย Loop มีหลายประเภท แต่ while จะนิยมใช้กับ Loop ที่ไม่รู้จำนวนที่ต้องทำซ้ำแบบแน่นอน
         * หรือ Loop ที่ไม่ต้องยุ่งกับค่าใน Array
         */
        
        // ในขณะที่ _healthFXDuration ยังมีค่าน้อยกว่า limiter (กำหนดเวลา)
        // ให้ทำคำสั่งดังต่อไปนี้
        while (_healthFXDuration <= limiter)
        {
            // เรียกใช้คำสั่งจาก Stat ของวัตถุที่ stat อ้างถึง
            // คำสั่งที่ว่าคือ CalculateHealth โดยให้ใช้ค่าจาก power
            // (โปรดอ่านไฟล์ Stat เพิ่มเติม)
            stat.CalculateHealth(power);
            
            //ให้รอ เป็นเวลาทั้งสิ้น timeBetweenFX วินาที
            yield return new WaitForSeconds(timeBetweenFX);
        }

        // ทำค่าในตัวแปร _healthFX ให้ว่างเปล่า
        _healthFX = null;
        
        // กำหนดให้ค่าในตัวแปร _healthFXInProgress คือ เท็จ
        _healthFXInProgress = false;
    }
}
