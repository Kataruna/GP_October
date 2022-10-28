using UnityEngine;

public class Stat : MonoBehaviour
{

    [SerializeField] private HealthBar hpBar;
    [SerializeField] private int maxHealth; //ประกาศตัวแปรประเภท int ชื่อว่า maxHealth โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    
    private int _health; //ประกาศตัวแปรประเภท int ชื่อว่า maxHealth

    /*
     * หน้าที่ของตัวแปรในโค้ดนี้
     * maxHealth: ระบุจำนวนเต็มของเลือดตัวละคร
     * _health: เลือดของตัวละคร ณ ปัจจุบัน
     */

    // ในตอนแรกสุด
    private void Awake()
    {
        //กำหนดให้ _health มีค่าเท่ากับ maxHealth
        _health = maxHealth;
        
        hpBar.Setup(maxHealth);
    }

    // ประกาศสร้างคำสั่งที่สามารถใช้ได้จากทุกที่ (public) โดยไม่คืนค่าใด ๆ กลับมา (void) โดยให้ชื่อคำสั่งว่า CalculateHealth
    // โดยหากมีการเรียกใช้คำสั่งนี้ จะต้องมีการระบุค่าของ value ในวงเล็บเป็นตัวเลขจำนวนเต็ม (int)
    public void CalculateHealth(int value)
    {
        //ให้เพิ่มค่าลงไปในตัวแปร _health เป็นจำนวน value หน่วย
        _health += value;
        
        //หากว่า _health มากกว่าหรือเท่ากับ maxHealth ให้เปลี่ยนค่า _health เป็น maxHealth (ทำให้เลือดเต็ม)
        if (_health >= maxHealth) _health = maxHealth;
        //หากว่า _health น้อยกว่าหรือเท่ากับ _health ให้เปลี่ยนค่า _health เป็น 0 (ทำให้เลือดหมด)
        else if (_health <= 0) _health = 0;
        
        hpBar.SetValue(_health);
    }

    #region Debug

    [ContextMenu("Health/Set Health to One")]
    void SetHealthToOne()
    {
        _health = 1;
        
        hpBar.SetValue(_health);
    }

    /*
     * Potion ที่พี่อยากได้
     * 1. Poison - ยาพิษ
     * 2. Mana / Stamina - ยาเพิ่มกำลัง (เลือกอันใดอันหนึ่ง)
     *
     * ไฟลที่ต้องแก้
     * • Stat - เพิ่ม Mana หรือ Stamina
     * • Affect - เพิ่มคำสั่งสำหรับยา Mana หรือ Stamina
     * • Potion - เพิ่มลักษณะยา และเรียกใช้คำสั่งตามประเภทยา
     */
    
    #endregion
}
