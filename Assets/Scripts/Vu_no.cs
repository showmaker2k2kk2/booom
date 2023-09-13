using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Vu_no : MonoBehaviour
{
    public AnimationScrip start;
    public AnimationScrip middle;
    public AnimationScrip end;
    public void SetActiveRenderer(AnimationScrip animationrenderer)
    {
        start.enabled = animationrenderer == start;
        middle.enabled = animationrenderer == middle;
        end.enabled = animationrenderer == end;
    }
    #region /*SetActiveRenderer*/
    /* - có chức năng kích hoạt hoặc vô hiệu hóa các đối tượng AnimationScrip 
           dựa trên đối tượng animationrenderer được truyền vào phương thức SetActiveRenderer

         -Bạn đã khai báo ba biến start, middle, và end kiểu AnimationScrip, giả sử đây là các đối tượng kiểu AnimationScrip mà bạn muốn kiểm soát

         -Trong phương thức SetActiveRenderer, bạn truyền một đối tượng animationrenderer kiểu AnimationScrip làm tham số.
              Sau đó, trong phương thức này, bạn kiểm tra xem đối tượng animationrenderer có bằng với start, middle, hoặc end 
              không bằng cách sử dụng toán tử so sánh ==. Nếu animationrenderer bằng với một trong ba biến này, thì thuộc tính 
               enabled của biến tương ứng sẽ được đặt thành true, ngược lại sẽ được đặt thành false.


 Ví dụ:


 Nếu bạn gọi SetActiveRenderer(start), thì start.enabled sẽ được đặt thành true, và middle.enabled và end.enabled sẽ được đặt thành false.

 Nếu bạn gọi SetActiveRenderer(middle), thì middle.enabled sẽ được đặt thành true, và start.enabled và end.enabled sẽ được đặt thành false.

 Mục tiêu chính của mã này là kiểm soát trạng thái enabled của các đối tượng AnimationScrip dựa trên đối tượng animationrenderer được truyền vào.*/
    #endregion
    public void SetDirection(Vector2 direction)
    {
        float goc_quay = Mathf.Atan2(direction.x, direction.y);
        transform.rotation = Quaternion.AngleAxis(goc_quay*Mathf.Rad2Deg, Vector3.forward);
    }
    #region /*Mathf.Atan2()->dùng để tính góc*/
    /*   
        -Hàm Mathf.Atan2() trong Unity được sử dụng để tính toán giá trị góc atan2 
         của hai tham số.Hàm này thường được sử dụng để tính toán góc giữa hai điểm 
          hoặc vector trong không gian 2D. Cú pháp của hàm Mathf.Atan2() như sau:


     cú pháp : float Mathf.Atan2(float y, float x);

                  y: Giá trị của y(điểm hoặc vector) mà bạn muốn tính góc atan2 cho.
                  x: Giá trị của x(điểm hoặc vector) mà bạn muốn tính góc atan2 cho.

    
    
             - Hàm này trả về giá trị góc atan2 trong radian, có thể nằm trong khoảng từ -π đến π.
              Góc này được tính bằng cách tính arctan của y/x.
              Kết quả có thể được chuyển đổi thành độ(degrees) bằng cách sử dụng hàm Mathf.Rad2Deg.
    
    Dưới đây là một ví dụ cơ bản về cách sử dụng Mathf.Atan2() trong Unity:

 


    ví dụ 
using UnityEngine;

public class Atan2Example : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    void /*Update()
    {
        Vector2 direction = pointB.position - pointA.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Debug.Log("Góc giữa hai điểm là: " + angle + " độ");
    }
}
Trong ví dụ này, chúng ta tính góc giữa hai điểm pointA và pointB sử dụng Mathf.Atan2() và sau đó hiển thị nó trong đơn vị độ thông qua Mathf.Rad2Deg.
    */
    #endregion
    public void DestroyAfter(float second)// huỷ đối tương;
    {
        
        Destroy(gameObject, second);
        
    }    
}
