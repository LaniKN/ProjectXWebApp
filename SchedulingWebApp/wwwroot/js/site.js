// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function() {
    var placeHolderElemCourses=$('#coursesPartial');
    var placeHolderElemMajors=$('#majorsPartial');


    //for gets
    
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

    //close modals

    $('#coursesClosePopUpBtn').click(function (event) {
        //alert('button clicked');
        var url=$(this).data('url');
        console.log({url});
        $.get(url).done(function (data){
            //file modal and append HTML
            console.log({data});
            //placeHolderElemCourses.html(data);
            placeHolderElemCourses.append(data).find('#coursesModal').modal('show');
        });

    });

    $('#majorsClosePopUpBtn').click(function (data) {
            placeHolderElemMajors.find('.modal').modal('hide');  
    });

    //for posts
    //Major Post
    placeHolderElemMajors.on('click', '[data-save="modal"]', function (event){
        event.preventDefault();
        console.log("prevented default");
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();
        console.log("Form: " + form);
        console.log("actUrl: " + actionUrl);
        console.log("dataSend: " + dataToSend);

        $.post(actionUrl, dataToSend).done(function (data) {
            console.log("posted");
            placeHolderElemMajors.find('#majorsModal').modal('hide');
        });

    });




});





