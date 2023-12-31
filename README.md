### Đặc tả:
1. Mỗi sản phẩm có: mã số, tên, mô tả, danh mục, số lượng
2. Kho chứa nhiều sản phẩm
3. Manager tạo các danh mục sản phẩm: mã số, tên, mô tả
4. ~~Nhân viên nhập kho phải có phiếu nhập kho: ngày nhập, nơi nhập (mã số, tên, địa chỉ, sdt), sản phẩm, số lượng, nv nhập~~
5. ~~Nhân viên xuất kho phải có phiếu xuất kho: ngày xuất, xuất cho ai (mã số, tên, địa chỉ, sdt), sản phẩm, số lượng, nv xuất~~
6. Nhân viên: mã nv, tên, ngày sinh, sdt
7. Quản lý được phép quản lý nhân viên: xem thông tin, thêm, xóa, cập nhật
8. Nhân viên và quản lý: xem thông tin, thêm, xóa, cập nhật, xuất, nhập sản phẩm
### Diagrams
![diagram1.png](/diagram1.png)
![diagram2.png](/diagram2.png)
### Xây dựng code console
- Ý tưởng:
	+ Lớp Staff 
	+ Mật khẩu: hash bằng BCrypt
	+ Dùng cấu trúc map lưu nhân sự thành 1 cặp id - value
	+ Lớp DataService - đọc ghi file cơ bản, sử dụng generic
	+ Lớp Controller - các thao tác với đối tượng
	+ Lớp View - mô phỏng các thao tác trên console
	+ 3 lớp này đặt tên theo ý tưởng mô hình MVC - chứ không hẳn project này theo MVC
### Package
+ Newtonsoft: serialize - deserialize JSON
+ BCrypt: mã hóa mật khẩu
### Note
+ Net6
+ Newtonsoft: serialize properties nào có public get, nếu muốn serialize property private thì thêm [JsonProperty]
#### HDSD
+ clone project
+ Chỉnh sửa path to file ở hàm Main (file nằm trong thư mục Public)
+ Build và Run