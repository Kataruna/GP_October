using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    // ประกาศตัวแปรประเภท GameObject เป็น Array ชื่อว่า distance โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    [SerializeField] private GameObject[] weapons;
    
    /*
     * Array คือวิธีการประกาศตัวแปรรูปแบบหนึ่ง ที่แทนที่เราจะประกาศตัวแปรที่เก็บค่าตัวแปรที่มีจุดประสงค์เดียวกัน เช่น คะแนนของนักเรียน
     * เราก็เปลี่ยนไปประกาศตัวแปรเพียง 1 ตัวแต่ให้เป็น Array ที่สามารถเก็บค่าประเภทใดประเภทหนึ่งได้หลายค่า
     * แล้วใช้การระบุ Index (เลขดัชนีบ่งชี้ มีค่า = ตำแหน่ง - 1) เพื่อเรียกค่าจากตัวแปรในตำแหน่งนั้น ๆ แทน
     * เช่น int[] score = {10, 20, 30, 25, 28}
     * score[2] จะมีค่าคือตำแหน่งที่ 3 ซึ่งมีค่า = 30
     */

    // ประกาศตัวแปรประเภท int ชื่อ _weaponQuantity
    private int _weaponQuantity;

    private int _activeWeapon = 0; // ประกาศตัวแปรประเภท int ชื่อ _activeWeapon โดยกำหนดค่าพื้นฐานเป็น 0
    private int _lastWeapon; // ประกาศตัวแปรประเภท int ชื่อ _lastWeapon
    
    /*
     * หน้าที่ของตัวแปรในโค้ดนี้
     * weapons: เก็บวัตถุทุกชิ้นที่ใช้เป็นอาวุธ
     * _weaponQuantity: เก็บจำนวนของอาวุธ
     * _activeWeapon: เลขชี้ตำแหน่ง (Index) ของอาวุธปัจจุบัน
     * _lastWeapon: เลขชี้ตำแหน่ง (Index) ของอาวุธก่อนหน้า
     */
    
    // เมื่อเริ่มต้น
    void Start()
    {
        _weaponQuantity = weapons.Length; // ให้ _weaponQuantity มีค่าเท่ากับ ขนาดของ Array ของตัวแปร weapons
        _lastWeapon = _activeWeapon; // ให้ _lastWeapon มีค่าเท่ากับ ค่าของ _activeWeapon
    }

    // ทำเรื่อย ๆ
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) //ถ้าหากว่า ลูกกลิ้งเมาส์ มีการขยับ แล้วค่า มากกว่า 0
        {
            _lastWeapon = _activeWeapon; // กำหนดให้ _lastWeapon มีค่าเท่ากับ ค่าของ _activeWeapon
            
            _activeWeapon++; // เพิ่มค่าใน _activeWeapon ไป 1 หน่วย
            
            // หากว่า _activeWeapon มีค่ามากกว่า _weaponQuantity ให้เปลี่ยนค่าใน _activeWeapon เป็น 0
            if (_activeWeapon >= _weaponQuantity) _activeWeapon = 0;
            
            weapons[_lastWeapon].SetActive(false); // ให้ ซ่อน วัตถุใน weapons ตำแหน่งที่ _lastWeapon (อาวุธก่อนหน้า)
            weapons[_activeWeapon].SetActive(true); // ให้ แสดง วัตถุใน weapons ตำแหน่งที่ _lastWeapon (อาวุธปัจจุบัน)
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f) //ถ้าหากว่า ลูกกลิ้งเมาส์ มีการขยับ แล้วค่า น้อยกว่า 0
        {
            _lastWeapon = _activeWeapon; // กำหนดให้ _lastWeapon มีค่าเท่ากับ ค่าของ _activeWeapon
            
            _activeWeapon--; // ลดค่าใน _activeWeapon ไป 1 หน่วย
            
            // หากว่า _activeWeapon มีค่าน้อยกว่า 0 ให้เปลี่ยนค่าใน _activeWeapon เป็น ค่าใน _weaponQuantity - 1 (จำนวนอาวุธ - 1)
            if (_activeWeapon <= 0) _activeWeapon = _weaponQuantity - 1;
            
            weapons[_lastWeapon].SetActive(false); // ให้ ซ่อน วัตถุใน weapons ตำแหน่งที่ _lastWeapon (อาวุธก่อนหน้า)
            weapons[_activeWeapon].SetActive(true); // ให้ แสดง วัตถุใน weapons ตำแหน่งที่ _lastWeapon (อาวุธปัจจุบัน)
        }
    }
}
