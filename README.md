### Đặc tả:
1. Mỗi sản phẩm có: mã số, tên, mô tả, phân loại, số lượng
2. Kho chứa nhiều sản phẩm
3. Nhân viên tạo ra các phân loại sản phẩm: tên loại, mô tả
4. Nhân viên nhập kho phải có phiếu nhập kho: ngày nhập, nơi nhập (mã số, tên, địa chỉ, sdt), sản phẩm, số lượng, nv nhập
5. Nhân viên xuất kho phải có phiếu xuất kho: ngày xuất, xuất cho ai (mã số, tên, địa chỉ, sdt), sản phẩm, số lượng, nv xuất
6. Nhân viên: mã nv, tên, ngày sinh, sdt
7. Quản lý được phép quản lý nhân viên: xem thông tin, thêm, xóa, cập nhật
### Diagrams


### Xây dựng code console
- Ý tưởng:
	+ Lớp Staff 
	+ Mật khẩu: hash bằng BCrypt
	+ Dùng cấu trúc map lưu nhân sự thành 1 cặp id - value
### Note
+ Newtonsoft: serialize properties nào có public get, nếu muốn serialize property private thì thêm [JsonProperty]

