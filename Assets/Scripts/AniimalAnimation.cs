using UnityEngine;

public class AniimalAnimation : MonoBehaviour
{
    private Animator _anim; //ประกาศตัวแปรประเภท Animator ชื่อว่า _anim
    
    //เมื่อเริ่มเกมมาในตอนแรกสุด (Awake ทำงาน ก่อน Start)
    void Awake()
    {
        //กำหนดให้ตัวแปรที่มีชื่อว่า _anim คือ Animator ของวัตถุที่ใส่ Script นี้ไว้
        _anim = this.gameObject.GetComponent<Animator>();
    }
    
    //ทำงานเรื่อย ๆ
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //หากมีการกดปุ่ม A
        {
            //ใน Animator ที่ _anim อ้างถึงให้ตั้งค่า bool ที่มีชื่อว่า isWalk ให้เป็นจริง (true)
            _anim.SetBool("isWalk", true);
        }
        
        if (Input.GetKeyUp(KeyCode.A)) //หากมีการปล่อยปุ่ม A
        {
            //ใน Animator ที่ _anim อ้างถึงให้ตั้งค่า bool ที่มีชื่อว่า isWalk ให้เป็นจริง (true)
            _anim.SetBool("isWalk", false);
        }
    }
}
