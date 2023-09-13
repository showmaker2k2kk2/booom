using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movecharacter : MonoBehaviour
{
    public AnimationScrip animationScripup;// tao ra 1 bien kieu animationScrip de lay hoat anh di chuyen 
    public AnimationScrip animationScripdown;// tao ra 1 bien kieu animationScrip de lay hoat anh di chuyen 
    public AnimationScrip animationScripleft;// tao ra 1 bien kieu animationScrip de lay hoat anh di chuyen 
    public AnimationScrip animationScripRight;// tao ra 1 bien kieu animationScrip de lay hoat anh di chuyen 
    private AnimationScrip activeSpriteRenderer; // xe bien sprite nao hoat dong
    Rigidbody2D rb;
    public float speed;
    Vector2 direction = Vector2.down;// tao ra giá trị mặc đinh của direction=======vector2(0;1),đảm bảo rằng đối tượng sẽ có một hướng di chuyển mặc định khi bắt đầu trò chơi,Điều này giúp tránh các lỗi không mong muốn do giá trị không được khởi tạo.
    public KeyCode inputup = KeyCode.W;
    public KeyCode inputdown = KeyCode.S;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputLeft = KeyCode.A;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = animationScripdown;
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputup))
        {
            SetDirection(Vector2.up,animationScripup);
        }
        else if (Input.GetKey(inputdown))
        {
            SetDirection(Vector2.down,animationScripdown);//(0;-1)

        }
        else if (Input.GetKey(inputRight))
        {
           SetDirection(Vector2.right,animationScripRight);//(1;0)
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left,animationScripleft);//(-1;0)
        }
        else    
        {
            SetDirection(Vector2.zero,activeSpriteRenderer);//(0;0)
        }


    }
    private void FixedUpdate()
    {
        Vector2 position=rb.position;//tao ra biến posion chứa vị trí hiện rại của nhân vạt dựa vào "position của Rigidbody2d trong unity ==> rb.position
        Vector2 transform = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(position + transform);      
    }
    private void SetDirection(Vector2 newdirection,AnimationScrip spriteRenderer)// phuon thuc nay se lam cho newdirection co gia tri (0;1),nó còn có the giup khởi tạo phương thức vd; trên

    {
       direction=newdirection;
        //direction sau đó có thể được thay đổi bằng cách gọi phương thức SetDirection(Vector2 newDirection) dựa trên đầu vào từ người chơi hoặc các sự kiện trong trò chơi, nhưng giá trị ban đầu được thiết lập để đảm bảo tính nhất quán

        animationScripup.enabled = spriteRenderer == animationScripup;
        animationScripdown.enabled = spriteRenderer == animationScripdown;
        animationScripleft.enabled = spriteRenderer == animationScripleft;
        animationScripRight.enabled = spriteRenderer == animationScripRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle= direction ==Vector2.zero;
       



    }
    #region /*giải thích direction*/
    //- direction sau đó có thể được thay đổi bằng cách gọi phương thức SetDirection(Vector2 newDirection)
    //dựa trên đầu vào từ người chơi hoặc các sự kiện trong trò chơi, nhưng giá trị ban đầu được thiết lập để đảm bảo tính nhất quán

    //- Khi bạn gọi SetDirection(Vector2 newDirection) 
    //với một giá trị mới, phương thức này đơn giản gán giá trị newDirection cho 
    //biến direction.Điều này có nghĩa là khi bạn nhấn một phím di chuyển, bạn đang thông
    //báo rằng đối tượng nên di chuyển theo hướng tương ứng với phím được nhấn
    #endregion
}
