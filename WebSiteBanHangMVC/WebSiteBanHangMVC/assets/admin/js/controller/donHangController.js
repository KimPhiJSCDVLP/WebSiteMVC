var donHang = {
    init: function () {
        donHang.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/DonHang/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status === true) {
                        btn.text('Đã giao hàng/Thanh toán');
                    }
                    else {
                        btn.text('Chưa thanh toán');
                    }
                }
            });
        });
    }
}
donHang.init();