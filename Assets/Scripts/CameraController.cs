using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  
    So camera doesn't gain any height*/
     
    public float mainSpeed = 25.0f; //regular speed
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun = 1.0f;
     
    void Update () {
        // lastMouse = Input.mousePosition - lastMouse ;
        // lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        // lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        // transform.eulerAngles = lastMouse;
        // lastMouse =  Input.mousePosition;
        //Mouse  camera angle done.  
       
        //Keyboard commands
        var baseInput = GetBaseInput();
        
        totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        baseInput = baseInput * mainSpeed;
       
        baseInput = baseInput * Time.deltaTime;
        
        transform.Translate(baseInput);
    }
     
    private Vector3 GetBaseInput() 
    { 
        // if (Input.GetKey (KeyCode.W))
        //     return new Vector3(0, 1, 0);
        // //
        // if (Input.GetKey (KeyCode.S))
        //     return new Vector3(0, -1, 0);
        
        if (Input.GetKey (KeyCode.A))
            return new Vector3(-1, 0, 0);

        if (Input.GetKey(KeyCode.D)) 
            return new Vector3(1, 0, 0); 
            
        return new Vector3();
    }
}
