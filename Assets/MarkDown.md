Distadvantages
- Dùng nhiều Resource load, để nhiều thứ trong resource dễ gây kém hiệu năng
- Dùng raycast để detect cell naò được slide và swap cũng không hiệu năng 
- GetComoponent ở những nơi như update 
- Một số biến chưa được clean - tên biến/hàm
Adventages
- tách giữa logic và UI game 
- folder sắp xếp gọn, dễ tìm kiếm
- Không lạm dụng singleton, nên cấu trúc code chặt chẽ, không bị rối 

* Suggestions:
* 
- nếu có thể hãy thử sử dụng tilemap và grid thay thế, như vậy vừa nâng cao hiệu năng,
và tránh việc phải dùng Raycast rồi GetComponent trong update

- ====> Tìm được bug, đó là trong BoardController.cs nếu để như lúc đầu là hàm 
public void Update() thì khi gọi ở Update tổng của gameManager hàm Update này sẽ bị gọi 2 lần, 
nên đã sửa và đặt tên khác để hàm chạy đúng 

- Nếu có thể hãy comment các function logic để biết chúng làm gì để dễ hiểu cho người khác làm 
- Nếu được hãy thử sử dụng Addressable thay thế cho việc sử dụng ResourceLoad để tối ưu hơn 