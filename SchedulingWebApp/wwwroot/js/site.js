// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
$(document).ready(function () {

});

function GetCourses() {
    $.ajax({
        url:'/SchedulingWebApp/Controllers/ModalController.cs',
        type:'get',
        datatype:'json',
        contentType:'application/json;charset=utf-8',
        success:function(res) {
            if(res == null || res == undefined || res.length == 0) {
                var obj = '';
                obj += '<li>' + 'Courses not available' + '</li>';
                $('#coursesPartial').html(obj);
            }
            else
            {
                var obj ='';
                $.each(res, function(index, item) {
                    obj += '<input type="checkbox">' + item.CourseId + '</input>';

                });
            }
        }
    });
}
*/

$(document).ready(function () {
    console.log("doc ready");
    var modalPlaceHolderElem = $('#coursesPartial');
    $('button[data-toggle="ajax-modal"]').click(function(event){
       var url = $(this).data('url');
        console.log({url});
        $.get(url).done(function (data){
            console.log({data});
            console.log("Button clicked");
            console.log(modalPlaceHolderElem.html(data));
            modalPlaceHolderElem.html(data);
            modalPlaceHolderElem.find('.modal').modal('show');
        });
    });
});




