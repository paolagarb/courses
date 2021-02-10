// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function(){
    $("#filtrar").change(function(){        
        var index = $(this).parent().index();
        var nth = "#div-cursos:nth-child("+(index+1).toString()+")";
        var valor = $(this).val().toUpperCase();
        $("#div-cursos div").show();
        $(nth).each(function(){
            if($(this).text().toUpperCase().indexOf(valor) < 0){
                $(this).parent().hide();
            }
        });
    });
 
    $("#filtrar").blur(function(){
        $(this).val("");
    }); 
});
