var danhMuc = {
    init: function () {
        danhMuc.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/DanhMucSanPham/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status === true) {
                        btn.text('Tồn tại');
                    }
                    else {
                        btn.text('Trống');
                    }
                }
            });
        });
    }
}
danhMuc.init();