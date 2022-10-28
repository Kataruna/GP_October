using System;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private int power; //ประกาศตัวแปรประเภท int ชื่อว่า power โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    [SerializeField] private float duration; //ประกาศตัวแปรประเภท float ชื่อว่า duration โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])

    [SerializeField] private Affect affect; //ประกาศตัวแปรประเภท Affect ชื่อว่า affect โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])

    [SerializeField] private PotionType type; //ประกาศตัวแปรประเภท PotionType ชื่อว่า type โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    
    /*
     * หน้าที่ของตัวแปรในโค้ดนี้
     * power: เก็บค่าความแรงของยาตัวนี้
     * duration: เก็บระยะเวลาของยาตัวนี้
     * affect: เก็บวัตถุที่มี Component Affect อยู่ และต้องการให้ส่งผลกับวัตถุที่ว่านั้น
     * type: ใช้ระบุประเภทของยา
     */
    
    /*
     * Enum คือลักษณะการประกาศตัวแปรรูปแบบหนึ่ง ที่ใช้ในการประกาศตัวเลือกลงไปเลย
     * เพื่อให้ง่ายต่อการเรียกใช้ เนื่องจากค่าใน Enum ไม่ได้มีสถานะเป็น string ฉะนั้น
     * เมื่อมีการเรียกใช้ ก็สามารถดึงมาใช้ได้เลย โปรแกรมส่วนใหญ่จะแนะนำค่าใน enum ขึ้นมาให้
     * เพื่อให้ง่ายต่อการเขียน
     */
    
    // ประกาศตัวแปรประเภท enum ชื่อว่า PotionType ใช้ในการเก็บประเภทของยาที่เป็นไปได้ ไว้สำหรับอ้างถึง
    private enum PotionType
    {
        Heal,
        Stamina,
        FireResistance,
        Poison
    }

    private void UsePotion()
    {
        // หากว่า ประเภทของยาตัวนี้คือ Health ให้สั่งคำสั่ง HealthBuff ในวัตถุที่ affect อ้างถึง ด้วยค่าของ power และ duration
        // (โปรดอ่านรายละเอียดเพิ่มเติมที่ไฟล์ Affect)
        //if(type == PotionType.Health) affect.HealthBuff(power, duration);
        /*
             * Switch เป็นหนึ่งในวิธีการเปรียบเทียบ คล้าย ๆ กับ if-else
             * โดย Switch จะเหมาะใช้งานกับอะไรที่ค่อนข้างเฉพาะเจาะจง ในขณะที่ if จะเหมาะกับการตรวจสอบช่วงมากกว่า (1 ถึง 10)
             * โดยหลักการเขียน switch คือ
             * switch (ตัวแปรที่ต้องการพิจารณา)
             * {
             *      case ค่าที่ 1:
             *          คำสั่ง
             *          break;
             *      case ค่าที่ 2:
             *          คำสั่ง
             *          break;
             *      case ค่าที่ 3: 
             *      case ค่าที่ 4: (กรณีจะใช้ หรือ ก็สามารถใส่ case ซ้อนกันแบบนี้ได้เลย)
             *          คำสั่ง
             *          break;
             *      default: (default มีลักษณะเหมือน else คือหากไม่ตรงกับกรณีใด ๆ จะมาทำกรณีนี้)
             *          break;
             * }
             * ** switch จะต้องมี case และ break เสมอ **
             */
        switch (type)
        {
            case PotionType.Heal:
                affect.HealthBuff(power, duration);
                break;
            case PotionType.Stamina:
                break;
            case PotionType.FireResistance:
                break;
            case PotionType.Poison:
                break;
        }
    }

    // New Input System
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _playerInput.Player.Interact.started += _ => UsePotion();
    } 
}
