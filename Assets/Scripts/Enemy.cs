using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] [Tooltip("Health of enemy")] private int health; // ประกาศตัวแปรประเภท int ชื่อว่า health โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    [SerializeField, Tooltip("Enemy's Movement Speed")] private float speed; // ประกาศตัวแปรประเภท float ชื่อว่า speed โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])

    /// <summary>
    /// Method of enemy to reduce health point by assign damage
    /// </summary>
    /// <param name="damage">Value of damage that going to reduce health</param>
    // ประกาศสร้างคำสั่งที่สามารถใช้ได้จากทุกที่ (public) โดยไม่คืนค่าใด ๆ กลับมา (void) โดยให้ชื่อคำสั่งว่า TakeDamage
    // โดยหากมีการเรียกใช้คำสั่งนี้ จะต้องมีการระบุค่าของ damage ในวงเล็บเป็นตัวเลขจำนวนเต็ม (int)
    public void TakeDamage(int damage)
    {
        // ลบเลือด ออกจาก health ตามค่าของ damage
        health -= damage;
        // ความหมายของคำสั่ง / วิธีเขียนอีกแบบ: health = health - damage;
    }
}
