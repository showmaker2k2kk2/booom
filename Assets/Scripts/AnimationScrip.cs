using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class AnimationScrip : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;// tham chếu đên Spriterendere:có thể thay đổi sprite trên nhân vật
    public Sprite[] mang_animationsprite;
    public Sprite idlesprite;

    public float animationTime = 0.4f;
    private int animationFrame;

   

    public bool Loop = true;// xem hoat anh co lap khong
    public bool  idle = true;//xem hoat anh co o che do cho hay khonng
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    #region/* giải thich OnEable và Disable trên */
    // - khi hành vi "AnimationScrip " được bật và muốn  Spriterenderer cũng đươc bật và
    // tắt "AnimationScrip "  thì tắt Spriterenderer thì ta dùng  OnEnable(),OnDisable()
    #endregion

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    #region/* giải thích OnEanle và OnDisable*/
    // - OnEnable và OnDisable là hai phương thức được sử dụng trong Unity
    // để xử lý sự kiện khi một đối tượng GameObject được kích hoạt (enabled) hoặc bị vô hiệu hóa (disabled)

    //- Phương thức OnEnable được gọi khi một GameObject hoặc một Component trên GameObject đó được bật (enabled).
    //Điều này có thể xảy ra khi bạn bật GameObject trong Hierarchy của Unity hoặc khi nó được tạo ra trong quá trình runtime (thông qua mã).

    //-  OnEnable thường được sử dụng để thực hiện các tác vụ cần thiết khi một đối tượng được kích hoạt.
    //Ví dụ: khởi động âm thanh, thiết lập các sự kiện, hoặc bắt đầu theo dõi các sự kiện ngoại vi.



    //  Phương thức OnDisable được gọi khi một GameObject hoặc một Component trên GameObject đó bị tắt (disabled).
    //  Điều này có thể xảy ra khi bạn tắt GameObject trong Hierarchy hoặc khi nó được vô hiệu hóa thông qua mã.
    //  OnDisable thường được sử dụng để dọn dẹp hoặc ngừng các hoạt động được thực hiện bởi đối tượng khi nó bị tắt.
    //  Ví dụ: dừng âm thanh, hủy đăng ký các sự kiện ngoại vi, giải phóng tài nguyên, và làm sạch dữ liệu liên quan đến đối tượng.
    #endregion

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }
    #region /*InvokeRepeating*/
    /* 
     
     - InvokeRepeating là một phương thức được sử dụng để gọi một phương thức hoặc hàm cụ thể lặp đi lặp lại
     sau một khoảng thời gian xác định. Điều này cho phép bạn thực hiện các hành động hoặc logic theo chu kỳ cố định trong trò chơi.

      - cú pháp : InvokeRepeating("TênPhươngThức", ThờiGianChờBanĐầu, ThờiGianLặpLại); 

                     "TênPhươngThức" là tên của phương thức hoặc hàm bạn muốn gọi lặp đi lặp lại.

                        ThờiGianChờBanĐầu là khoảng thời gian (dưới dạng số giây) bạn muốn chờ trước khi gọi lần đầu tiên
    .
                         ThờiGianLặpLại là khoảng thời gian (dưới dạng số giây) giữa mỗi lần gọi.

                   
                 vd:InvokeRepeating("MyFunction", 2.0f, 1.0f);
                private void MyFunction()
                  {
                       Debug.Log("Phương thức MyFunction được gọi lặp lại.");
                   }

    */
    #endregion
    private void NextFrame()
    {
        animationFrame++;
        if (Loop && animationFrame >= mang_animationsprite.Length)
        {
            animationFrame = 0;
        }
        else if (animationFrame >= 0 && animationFrame < mang_animationsprite.Length)
        {
            spriteRenderer.sprite = mang_animationsprite[animationFrame];   
        }
    }    
}
