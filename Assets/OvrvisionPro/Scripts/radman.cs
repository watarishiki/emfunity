using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class radman : MonoBehaviour {
    SerialPort port = new SerialPort("COM3", 2400, Parity.None, 8, StopBits.One);

	// Use this for initialization
	void Start () {
        try{
        port.Open();
        port.DtrEnable = true;
        port.RtsEnable = true;
        Debug.Log("portopen");
        }
        catch (System.Exception e) {
            Debug.LogWarning (e.Message);
        }
 
	}
	
	// Update is called once per frame
    void Update()
    {
        try
        {
            port.Write("MT\r");
            System.Threading.Thread.Sleep(100);
            string buff = port.ReadTo("\r");

            Debug.Log(buff);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

    void OnDestroy() {
        port.Close();
    }
}
