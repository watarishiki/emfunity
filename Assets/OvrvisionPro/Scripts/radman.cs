using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions; //数値抽出用   

public class radman : MonoBehaviour {
    SerialPort port = new SerialPort("COM3", 2400, Parity.None, 8, StopBits.One);

	// Use this for initialization
	void Start () {
        try{
        port.Open();
        port.DtrEnable = true;
        port.RtsEnable = true;
        Debug.Log("portopen");
        port.Write("MT\r");
        System.Threading.Thread.Sleep(100);

        }
        catch (System.Exception e) {
            Debug.LogWarning ("start error and" + e.Message);
        }
 
	}
	
	// Update is called once per frame
    void Update()
    {
       
        try
        {
            if (Input.GetKey(KeyCode.R))
            {
                float check_time = Time.realtimeSinceStartup;

                string m_buff = port.ReadTo(" ");
                Regex re = new Regex(@"[^0-9]");//数字のみを抽出
                string m_buff2 = re.Replace(m_buff, "");//QTの除外
                string e_buff = port.ReadTo("\r");
                Debug.Log(m_buff2 + "and" + e_buff);

                int m_field = Convert.ToInt16(m_buff2, 16) * 5 / 8;
                int e_field = Convert.ToInt16(e_buff, 16) * 5 / 8;
                Debug.Log(m_field + "and" + e_field);


                //string[] splitbuff = buff2.Split(' ');
                //Debug.Log(splitbuff);
                //if (splitbuff.Length == 2)
                //{
                //    foreach (String hex in splitbuff)
                //    {
                //        int value = Convert.ToInt16(hex, 16);
                //        Console.WriteLine("hexadecimal = {0}, 10進値 :{1}", hex, value);
                //    }
                //}
                //else
                //{
                //    Debug.Log("scan error");
                //}
               
                check_time = 1000 * (Time.realtimeSinceStartup - check_time);
                Debug.Log("routine_time = " + check_time.ToString("0.000") + "ms");
            }
            port.DiscardInBuffer();
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }

       

        if (Input.GetKey(KeyCode.U))
        {
            transform.position = new Vector3(0f, transform.position.y + 0.01f, 0f);
        }
        if (Input.GetKey(KeyCode.N))
        {
            transform.position = new Vector3(0f, transform.position.y - 0.01f, 0f);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.position = new Vector3(transform.position.x + 0.01f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.H))
        {
            transform.position = new Vector3(transform.position.x - 0.01f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.position = new Vector3( 0f, 0f,transform.position.z + 0.01f);
        }
        if (Input.GetKey(KeyCode.M))
        {
            transform.position = new Vector3(0f, 0f, transform.position.z - 0.01f);
        }
  
  
    }

    void OnDestroy() {
        port.Close();
    }
}
