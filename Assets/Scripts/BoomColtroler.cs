using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class BoomColtroler : MonoBehaviour
{
    public KeyCode Inputkey = KeyCode.Space;
    [Header("bom")]
    public GameObject bomprefabs;
    public float Thoi_gian_bom_no = 3f;
    public int so_luong_bom_dctha = 1;     //   --- bomAmount 
    public int so_luong_bom_conlai;       //    --bombsRemaining

    [Header("thongtinvuno")]
    public Vu_no vu_noprefabs;
    public float Thoi_gian_de_bom_no = 1f;       //Exploduration
    public int pham_vi_vu_No = 1;   //exploradius
    private void OnEnable()
    {
        so_luong_bom_conlai = so_luong_bom_dctha;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && so_luong_bom_conlai > 0)
        {
            StartCoroutine(datbom());
        }
    }
    private IEnumerator datbom()
    {
        Vector2 position = transform.position;  // khởi tạo vị trí đặt bom --->bất cứ vị trí nào người chơi có mặt 
        //position.x = Mathf.Round(position.x);   /*  Mathf.Round : là 1 hàm làm tròn giá trị  giúp bom dặt vừa với các ô gạch  
        //                                                     nếu không thì giá trị của vị trí đặt bom sẽ bị lẻ kiêu3 thập phân vd 8.77 */
        //position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bomprefabs, position, Quaternion.identity);
        so_luong_bom_conlai = so_luong_bom_conlai - 1;//sl bom giam di 1

        yield return new WaitForSeconds(Thoi_gian_bom_no);/// doi thoi gian de bom no 

        position = bomb.transform.position;// vi tri cua bom

        Vu_no vuno = Instantiate(vu_noprefabs, position, Quaternion.identity);// khoi tao vu no
        vuno.SetActiveRenderer(vuno.start);
        vuno.DestroyAfter(Thoi_gian_de_bom_no);

        phuong_thuc_Vuno(position, Vector2.up, pham_vi_vu_No);
         phuong_thuc_Vuno(position, Vector2.down, pham_vi_vu_No);
        phuong_thuc_Vuno(position, Vector2.left, pham_vi_vu_No);
        phuong_thuc_Vuno(position, Vector2.right, pham_vi_vu_No);



        Destroy(bomb);
        so_luong_bom_conlai = so_luong_bom_conlai + 1;
    }
    #region /*Instantiate*/
    /* 
        
          - Instantiate là một phương thức trong Unity được sử dụng để tạo một bản sao (instance)
              của một đối tượng (GameObject) hoặc một prefab. Điều này cho phép bạn tạo ra nhiều phiên bản của 
              cùng một đối tượng trong trò chơi, thường được sử dụng khi bạn muốn tạo ra nhiều đối tượng giống 
              nhau hoặc khi bạn cần tạo ra đối tượng trong quá trình chạy trò chơi. 
    
     
    
    ---cú pháp :     Instantiate(đối tượng, vector3 or vector2 vị trí , Quaternion.rotation)--- Quaternion,--góc xoay bạn muốn áp dụng cho đối tượng mới
     
            
          
    
    
    
    vd:        public GameObject prefabToInstantiate; // Prefab bạn muốn sao chép

              void Start()
                               {
                  // Tạo một bản sao của prefab tại vị trí (0, 0, 0) và không có xoay
                  GameObject clone = Instantiate(prefabToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);

                 // Sau khi tạo, bạn có thể tùy chỉnh thuộc tính của đối tượng clone
             clone.transform.localScale = new Vector3(2, 2, 2);
                                  }
               
    
             

      
     */
    #endregion
    #region /*Couroutine*/

    /* 
          để có thể chạy được Couroutine thì ta sử dụng thư viện      -----     using System.Collections  -------

         - Couroutine :Coroutine là một khái niệm quan trọng trong Unity cho phép bạn thực hiện
                các tác vụ chạy bất đồng bộ (asynchronous) mà không làm đóng băng hoặc gián đoạn luồng chính 
                (main thread) của trò chơi. Điều này giúp bạn thực hiện các công việc chậm chạp như chờ đợi, đội ngũ animation, 
                hoặc các tác vụ khác mà không gây trở ngại cho trải nghiệm của người chơi.
     
       - Khai báo một phương thức Coroutine: Để khai báo một Coroutine, bạn sử dụng từ khóa IEnumerator trước tên của phương thức
     
    vd1 :
                public class CoroutineExample : MonoBehaviour
                      {
                                                          // Coroutine để thực hiện một tác vụ chạy bất đồng bộ
                             IEnumerator MyCoroutine()
                           {
                             // Thực hiện các công việc trong Coroutine

                          yield return null;                            // Câu lệnh này cho phép Coroutine tạm dừng một frame.
                            
                                 // Tiếp tục thực hiện công việc
                           }
                      }
      

    vd2: 
     
                         
    void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()               ------>        kiểu trả vể của hàm ta sử dung IEnumerator  -------
    {
        int countdownValue = 3;
        while (countdownValue > 0)
        {
            Debug.Log("Countdown: " + countdownValue);
            yield return new WaitForSeconds(1.0f); // Đợi 1 giây
            countdownValue--;
        }

        Debug.Log("Countdown Finished!");
    }
}
           -  Trong ví dụ này, Coroutine Countdown được sử dụng để thực hiện đếm ngược từ 3 xuống 0 và 
              đợi mỗi giây trước khi giảm giá trị đếm. Coroutine này không ảnh hưởng đến luồng chính của trò chơi và 
              cho phép thực hiện các công việc khác trong thời gian đợi.



         - Bắt đầu Coroutine: Bạn sử dụng StartCoroutine để bắt đầu thực thi một Coroutine

         - Sử dụng yield để tạo khoảng thời gian chờ đợi: Trong Coroutine, bạn có thể sử dụng yield để tạm dừng Coroutine 
           và đợi một khoảng thời gian hoặc một sự kiện nào đó. Có nhiều loại yield khác nhau như yield return null (đợi một frame),
           yield return new WaitForSeconds(time) (đợi một khoảng thời gian), và yield return new WaitUntil(condition) (đợi đến khi điều kiện thỏa mãn).
    */

    #endregion
    private void phuong_thuc_Vuno(Vector2 vi_tri, Vector2 huong, int do_dai)
    {
        if (do_dai <= 0)
        {
            return;
        }
        vi_tri = vi_tri + huong;

        Vu_no vuno = Instantiate(vu_noprefabs, vi_tri, Quaternion.identity);
        vuno.SetActiveRenderer(do_dai > 1 ? vu_noprefabs.middle : vu_noprefabs.end); ///  ----> su dung toan tu 3 ngoi de
        vuno.SetDirection(huong);
        vuno.DestroyAfter(Thoi_gian_de_bom_no);
        //sau do se pha huy vu no nay sau khoang thoi gian 

        phuong_thuc_Vuno(vi_tri, huong, do_dai - 1);  // và đây là lúc  gọi hàm đệ quy   phat no tai cung 1 vi tri moi , huong moi nhung do dai giam di 1 
                                                      // và toàn bộ phuong_thuc_Vuno   -- sẽ phát nổ cho đến khi độ dài giảm về 0 và nó ko thể kèo dài hơn nữa
    }
    
    #region /*toan tu 3 ngoi*/ 
    /*
       -- toán tử 3 ngôi  --- 
     

    vD; if(do_dai > 1)
          {
             vu_noprefabs.middle    
          }
        else
    {
        vu_noprefabs.end
    }
   
    
         - Toán tử ba ngôi (ternary operator) trong C# cho phép bạn thực hiện một quyết định dựa 
           trên một điều kiện và trả về một giá trị hoặc biểu thức khác tùy thuộc vào điều kiện đó. 
    
    
       Cú pháp của toán tử ba ngôi trong C# là:   condition ? expression1 : expression2 

            condition: Điều kiện kiểm tra. 

            - Nếu điều kiện này đúng (true), 

                  thì ---- expression1 ----- được thực hiện; nếu điều kiện sai (false), thì ---- expression2 ------ được thực hiện.



                 expression1: Biểu thức được thực hiện nếu điều kiện là true.

                  expression2: Biểu thức được thực hiện nếu điều kiện là false.
     
     */
    #endregion
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }    
}
