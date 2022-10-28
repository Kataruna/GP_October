using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] private float distance; // ประกาศตัวแปรประเภท float ชื่อว่า distance โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    [SerializeField] private int damage; // ประกาศตัวแปรประเภท int ชื่อว่า damage โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])
    [SerializeField] private Transform face; // ประกาศตัวแปรประเภท Transform ชื่อว่า face โดยเรียกใช้จากที่อื่นไม่ได้ (private) แต่แก้จาก Inspector ได้ ([SerializeField])

    private RaycastHit _hit; // ประกาศตัวแปรประเภท RaycastHit (ตัวเก็บวัตถุที่โดน Raycast ยิงใส่) ชื่อว่า _hit

    // ทำเรื่อย ๆ
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // หากมีการกดเมาส์ซ้าย
        {
            // Physics.Raycast ด้วยตัวคำสั่งเองสามารถส่งผลลัพธ์ออกมาเป็นจริงหรือเท็จได้ ซึ่งคือ ชน/ไม่ชน วัตถุใด ๆ
            // Physics.Raycast(จุดเริ่มต้น, หันไปทางไหน, out เก็บวัตถุที่โดนยิงไว้ในตัวแปรแบบ RaycastHit, ระยะของลำแสง)
            // ยิง Raycast ออกไป จากตำแหน่งของ face, หันไปทางด้านหน้าของ face, เก็บผลลง _hit, ระยะของเส้นนี้คือ distance เมตร
            if (Physics.Raycast(face.position, face.forward, out _hit, distance))
            {
                // หากวัตถุที่โดน Raycast ยิงมี tag คือ Enemy
                if (_hit.transform.tag == "Enemy")
                {
                    Enemy enemy; // สร้างตัวแปรชั่วคราว ประเภท Enemy ชื่อ enemy
                    // ลองดึง Component ออกมาจากวัตถุ _hit แล้วเก็บลง enemy
                    // โดยอิงจากประเภทของ enemy เลย
                    _hit.transform.TryGetComponent(out enemy);
                    
                    // เรียกใช้คำสั่ง TakeDamage ในวัตถุที่อ้างถึงใน enemy ด้วยค่า damage (อ่านไฟล์ Enemy ควบคู่ด้วยจะเข้าใจมากขึ้น)
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    /*
     คำสั่งให้วาดเส้น Gizmos เมื่อวัตถุนี้ถูกเลือก
        Gizmos เป็นเส้นที่ใข้ในการสร้างเกมเป็นหลัก มักใช้กับการ Debug ระยะที่จะส่งผลจากคำสั่งบางอย่าง
        ผู้เล่นจะไม่เห็นเส้นนี้ในขณะเล่น
    */
    private void OnDrawGizmosSelected()
    {
        // กำหนดสีของเส้น Gizmo เป็นสีแดง
        Gizmos.color = Color.red;
        
        // วาดเส้นขึ้นมา (จุดเริ่มต้นของเส้น, จากจุดเริ่มต้น + หันไปทางไหน * ระยะทาง)
        Debug.DrawLine(face.position, face.position + face.forward * distance);
    }
}
