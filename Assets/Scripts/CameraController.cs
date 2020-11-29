using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  
    So camera doesn't gain any height*/
     
    public float mainSpeed = 25.0f; //regular speed
    public float scrollSpeed = 25.0f;

    private void Update ()
    {
        // lastMouse = Input.mousePosition - lastMouse ;
        // lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        // lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        // transform.eulerAngles = lastMouse;
        // lastMouse =  Input.mousePosition;
        //Mouse  camera angle done.  
       
        //Keyboard commands
        CameraMove();
        MouseScroll();
    }

    private void CameraMove()
    {
        var baseInput = GetBaseInput();
        baseInput *= mainSpeed;
        baseInput *= Time.deltaTime;
        transform.Translate(baseInput);
    }

    private void MouseScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") == 0f)
            return;

        var scroll = new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") > 0f ? 1 : -1);
        
        scroll *= scrollSpeed;
        scroll *= Time.deltaTime;
        transform.Translate(scroll);
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
