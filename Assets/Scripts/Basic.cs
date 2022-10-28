#region • Library

//คู่มือคำสั่ง
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#endregion

#region • Class

//หนังสือ

public class Basic : MonoBehaviour
{
    //Access-Modifier Type Name = Initial-Value;
    //ระดับเข้าถึง ประเภท/ชนิด ชื่อ = ค่าเริ่มต้น;
    
    /*Access-Modifier
    • private = ส่วนตัว - ใช้ได้ภายในคลาสเท่านั้น
    • public = สาธารณะ - ใช้ได้จากทุกคลาส
    */
    
    /*Basic Type
     int = ตัวเลข 
     float = ตัวเลขทศนิยม
     string = "คำพูด / ข้อความ"
     bool = true/false
    */

    private GameObject _gameObject; //Everything in Hierarchy
    private Transform _transform; //การเคลื่อนที่
    private Rigidbody _rb;


    #region Method / Function / Command

    #region Unity Method - Unity มีให้ และทำงานในบางโอกาสอยู่แล้ว

    private void Awake()
    {
        Setup();
    }

    #endregion
    
    // Custom Method
    //Access-Modifier Return-TypeOf Name(Contructor)
    //ระดับการเข้าถึง คืนค่ากลับมาเป็นอะไร ชื่อ(ต้องการค่าอะไรบ้าง)
    public void Setup()
    {
        _rb = GetComponent<Rigidbody>();
    }

    #endregion
    
}

#endregion

