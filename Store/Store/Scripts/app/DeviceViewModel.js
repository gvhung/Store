﻿function DeviceViewModel() {

    self = this;

    self.getDevices = function () {
        $.ajax({
            url: '/api/Devices/',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                alert(data);
            },
            error: function () {
                alert("error");
            }
        });
    };

}