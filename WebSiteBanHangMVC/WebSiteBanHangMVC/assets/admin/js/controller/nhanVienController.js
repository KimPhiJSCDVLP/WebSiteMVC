﻿var nhanVien = {
    init: function () {
        nhanVien.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/NhanVien/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status === true) {
                        btn.text('Nam');
                    }
                    else {
                        btn.text('Nữ');
                    }
                }
            });
        });
    }
}
nhanVien.init();