// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function() {
    var placeHolderElemCourses=$('#coursesPartial');
    var placeHolderElemMajors=$('#majorsPartial');

    $('#coursesPopUpBtn').click(function (event) {
        //alert('button clicked');
        var url=$(this).data('url');
        console.log({url});
        $.get(url).done(function (data){
            //file modal and append HTML
            console.log({data});
            placeHolderElemCourses.html(data);
            placeHolderElemCourses.append(data).find('#coursesModal').modal('show');
        });

    });

    $('#majorsPopUpBtn').click(function (event) {
        var url=$(this).data('url');
        console.log({url});
        $.get(url).done(function (data){
            console.log({data});
            placeHolderElemMajors.html(data);
            placeHolderElemMajors.append(data).find('#majorsModal').modal('show');
        });
    });

});





